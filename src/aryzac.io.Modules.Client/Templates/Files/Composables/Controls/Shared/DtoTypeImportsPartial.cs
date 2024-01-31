using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modelers.WebClient.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.TypeResolvers;
using Intent.Modules.Metadata.WebApi.Models;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;
using static Aryzac.IO.Modules.Client.Api.LocaleModelStereotypeExtensions;

namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.Shared
{
    partial class DtoTypeImports
    {
        public DtoTypeImports(IElement element)
        {
            Element = element;
        }

        public IElement Element { get; set; }

        public List<ComponentQueryModel> Queries => Element.ChildElements
            .GetElementsOfType(ComponentQueryModel.SpecializationTypeId, true)
            .Select(x => new ComponentQueryModel(x))
        .ToList();

        public List<ComponentCommandModel> Commands => Element.ChildElements
            .GetElementsOfType(ComponentCommandModel.SpecializationTypeId, true)
            .Select(x => new ComponentCommandModel(x))
            .ToList();

        // Helper method to get import statement for queries
        public string GetQueryImportStatement(ComponentQueryModel query)
        {
            var endpoint = GetEndpoint((IElement)query.Mapping.Element.AsOperationModel().Mapping.Element);
            var importPath = GetImportPath((IElement)endpoint.ReturnType.Element);
            return $"import type {{ {endpoint.ReturnType.Element.Name} }} from '{importPath}';";
        }

        // Helper method to get import statement for commands
        public string GetCommandImportStatement(ComponentCommandModel command)
        {
            var endpoint = GetEndpoint((IElement)command.Mapping.Element.AsOperationModel().Mapping.Element);
            if (HasBodyParameter(endpoint))
            {
                var bodyParam = GetBodyParameter(endpoint);
                var importPath = GetImportPath((IElement)bodyParam.TypeReference.Element);
                return $"import type {{ {endpoint.InternalElement.Name} }} from '{importPath}';";
            }
            return null;
        }

        private IHttpEndpointModel GetEndpoint(IElement element)
        {
            var endpoint = HttpEndpointModelFactory.GetEndpoint(element);
            if (endpoint is null) { return null; }

            return endpoint;
        }

        private bool HasBodyParameter(IHttpEndpointModel endpoint)
        {
            return endpoint.Inputs.Any(x => x.Source == HttpInputSource.FromBody);
        }

        private IHttpEndpointInputModel GetBodyParameter(IHttpEndpointModel endpoint)
        {
            return endpoint.Inputs.First(x => x.Source == HttpInputSource.FromBody);
        }

        private string GetImportPath(IElement element)
        {
            return $"~/structs/dto/{element.ParentElement.Name.ToPascalCase().ToCamelCase()}/{element.MappedElement.Element.Name.ToKebabCase()}.dto";
        }
    }
}
