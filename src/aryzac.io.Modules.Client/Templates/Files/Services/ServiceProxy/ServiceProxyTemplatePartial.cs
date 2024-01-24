using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Aryzac.IO.Modules.Client.Templates.Files.Structs.DTOs.DTO;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.Types.Api;
using Intent.Modules.Common.TypeScript.Builder;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.Modules.Metadata.WebApi.Models;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;
using Intent.Utils;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Services.ServiceProxy
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public partial class ServiceProxyTemplate : TypeScriptTemplateBase<Intent.Modelers.Types.ServiceProxies.Api.ServiceProxyModel>, ITypescriptFileBuilderTemplate
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Services.ServiceProxy";

        [IntentManaged(Mode.Ignore, Signature = Mode.Fully)]
        public ServiceProxyTemplate(IOutputTarget outputTarget, Intent.Modelers.Types.ServiceProxies.Api.ServiceProxyModel model) : base(TemplateId, outputTarget, model)
        {
            AddTypeSource(DTOTemplate.TemplateId);

            TypescriptFile = new TypescriptFile("")
                .AddImport("AsyncData", "nuxt/app")
                .AddClass(Model.Name, @class =>
                {
                    @class.Export();

                    foreach (var operation in Model.Operations)
                    {
                        var endpoint = HttpEndpointModelFactory.GetEndpoint((IElement)operation.Mapping.Element);
                        if (endpoint is null)
                        {
                            Logging.Log.Warning($"Operation [{operation.Name}] on {ServiceProxyModel.SpecializationType} [{Model.Name}] is not mapped to an Http-exposed service");
                            continue;
                        }
                        AddOperationMethod(@class, operation.Name.ToCamelCase(), endpoint);
                    }
                });
        }

        private void AddOperationMethod(TypescriptClass @class, string name, IHttpEndpointModel endpoint)
        {
            var returnType = GetReturnType(endpoint);

            var returnTypeSignature = $"Promise<AsyncData<{returnType} | null, any>>";
            var useFetchSignature = $"useLazyFetch<{returnType}>";

            if (returnType == "void")
            {
                returnTypeSignature = $"Promise<AsyncData<any, any>>";
                useFetchSignature = $"useFetch";
            }

            @class.AddMethod(name, returnTypeSignature, method =>
            {
                method.Async();
                method.Public();

                method.AddStatement("const config = useRuntimeConfig();");

                foreach (var input in endpoint.Inputs)
                {
                    AddTypeSource(GetTypeName(input.TypeReference));
                    method.AddParameter(input.Name.ToCamelCase(), base.GetTypeName(input.TypeReference));
                }

                var url = $"/{endpoint.Route.Replace("{", "${")}";

                if (endpoint.Inputs.Any(x => x.Source == HttpInputSource.FromQuery))
                {
                    var queryParams = string.Join("&", endpoint.Inputs.Where(m => m.Source == HttpInputSource.FromQuery).Select(m => m.Name).Select(p => $"{p}=${{{p}}}"));
                    url += $"?{queryParams}";
                }

                method.AddStatement($"let url = `${{config.public.{Model.Name.ToCamelCase()}ApiBaseUri}}{url}`;");

                method.AddStatement($"return await {useFetchSignature}(url,");

                method.AddStatement($"  {{");
                method.AddStatement($"      method: '{endpoint.Verb.ToString().ToUpper()}',");

                method.AddStatement($"      headers: {{ ");
                method.AddStatement($"         'Content-Type': 'application/json', ");
                foreach (var header in endpoint.Inputs.Where(x => x.Source == HttpInputSource.FromHeader))
                {
                    method.AddStatement($"         '{header.Name}': {header.Name.ToCamelCase()} ?? {header.Value},");
                }
                method.AddStatement($"      }},");

                if (endpoint.Inputs.FirstOrDefault(x => x.Source == HttpInputSource.FromBody) != null)
                {
                    var bodyParam = endpoint.Inputs.First(x => x.Source == HttpInputSource.FromBody);
                    method.AddStatement($"      body: JSON.stringify({bodyParam.Name.ToCamelCase()}),");
                }

                method.AddStatement($"  }}");

                method.AddStatement($");");
            });
        }

        private string GetReturnType(IHttpEndpointModel operation)
        {
            if (operation.ReturnType == null)
            {
                return "boolean";
            }

            return GetTypeName(operation.ReturnType);
        }

        private string UseType(string type, string location)
        {
            this.AddImport(type, location);
            return type;
        }

        public List<string> GetEndpointQueryParameters()
        {
            var endpoint = HttpEndpointModelFactory.GetEndpoint((IElement)Model.Mapping.Element);
            if (endpoint is null) { return null; }

            var parameters = new List<string>();

            if (endpoint.Inputs.Any(x => x.Source == HttpInputSource.FromQuery))
            {
                parameters = endpoint.Inputs.Where(m => m.Source == HttpInputSource.FromQuery).Select(m => m.Name).ToList();
            }

            return parameters;
        }

        [IntentManaged(Mode.Fully)]
        public TypescriptFile TypescriptFile { get; }

        [IntentManaged(Mode.Ignore)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return TypescriptFile.GetConfig($"{Model.Name}.proxy");
        }

        [IntentManaged(Mode.Fully)]
        public override string TransformText()
        {
            return TypescriptFile.ToString();
        }
    }
}