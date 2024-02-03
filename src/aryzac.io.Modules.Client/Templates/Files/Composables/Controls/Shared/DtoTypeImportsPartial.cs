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
using static System.Collections.Specialized.BitVector32;
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

        public List<ActionModel> Actions => Element.ChildElements
            .GetElementsOfType(ActionModel.SpecializationTypeId, true)
            .Select(x => new ActionModel(x))
            .ToList();

        public List<ComponentParameterModel> Parameters => GetComponent().InternalElement.ChildElements
            .GetElementsOfType(ComponentParameterModel.SpecializationTypeId, true)
            .Select(x => new ComponentParameterModel(x))
            .ToList();

        public List<ComponentModelModel> Models => GetComponent().InternalElement.ChildElements
            .GetElementsOfType(ComponentModelModel.SpecializationTypeId, true)
            .Select(x => new ComponentModelModel(x))
            .ToList();

        // Helper method to get import statement for queries
        public string GetQueryImportStatement(ComponentQueryModel query)
        {
            var endpoint = GetEndpoint((IElement)query.Mapping.Element.AsOperationModel().Mapping.Element);
            var importPath = $"~/structs/dto/{((IElement)endpoint.ReturnType.Element).ParentElement.Name.ToPascalCase().ToCamelCase()}/{((IElement)endpoint.ReturnType.Element).MappedElement.Element.Name.ToKebabCase()}.dto";
            return $"import type {{ {endpoint.ReturnType.Element.Name} }} from '{importPath}';";
        }

        // Helper method to get import statement for commands
        public string GetCommandImportStatement(ComponentCommandModel command)
        {
            var endpoint = GetEndpoint((IElement)command.Mapping.Element.AsOperationModel().Mapping.Element);
            if (HasBodyParameter(endpoint))
            {
                var bodyParam = GetBodyParameter(endpoint);
                // var importPath = GetImportPath((IElement)bodyParam.TypeReference.Element);
                // ((IElement)endpoint.ReturnType.Element).MappedElement.Element.Name.ToKebabCase()
                var importPath = $"~/structs/dto/{((IElement)bodyParam.TypeReference.Element).ParentElement.Name.ToPascalCase().ToCamelCase()}/{ endpoint.InternalElement.Name.ToKebabCase() }.dto";
                return $"import type {{ { endpoint.InternalElement.Name } }} from '{importPath}';";
            }
            return null;
        }

        public string GetParameterImportStatement()
        {
            var component = GetComponent();
            return $"import type {{ {component.Name.ToPascalCase()}Props }} from '~/structs/components/{component.InternalElement.ParentElement.Name.ToPascalCase().ToCamelCase()}/{component.Name.ToKebabCase()}.props';";
        }

        public string GetModelImportStatement()
        {
            var component = GetComponent();
            return $"import type {{ {component.Name.ToPascalCase()}Model }} from '~/structs/components/{component.InternalElement.ParentElement.Name.ToPascalCase().ToCamelCase()}/{component.Name.ToKebabCase()}.model';";
        }

        public ComponentModel GetComponent()
        {
            return Element.GetFirstParentOfType(ComponentModel.SpecializationTypeId).AsComponentModel();
        }

        public string GetActionImportStatement(ActionModel action)
        {
            return default;
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
    }
}
