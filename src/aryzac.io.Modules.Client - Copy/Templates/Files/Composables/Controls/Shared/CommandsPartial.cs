using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.Services.CQRS.Api;
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
    partial class Commands
    {
        public Commands(IElement element, Func<ITypeReference, string> getTypeName)
        {
            Element = element;
            GetTypeName = getTypeName;
        }

        public IElement Element { get; set; }
        public Func<ITypeReference, string> GetTypeName { get; }

        private IEnumerable<ComponentCommandModel> GetCommandModels()
        {
            return Element.ChildElements
                .GetElementsOfType(ComponentCommandModel.SpecializationTypeId, true)
                .Select(x => new ComponentCommandModel(x))
                .ToList();
        }

        public string GetMappedName(IElement field, ComponentCommandModel command)
        {
            foreach (var mapping in command.InternalElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }

        public IHttpEndpointModel GetEndpointModel(ComponentCommandModel command)
        {
            return HttpEndpointModelFactory.GetEndpoint((IElement)command.Mapping.Element.AsOperationModel().Mapping.Element);
        }

        // Method to generate the TypeScript function parameters for a command.
        public IEnumerable<string> GenerateFunctionParameters(ComponentCommandModel command)
        {
            var parameters = new List<string>();

            // Iterate through mappings intended for function parameters.
            var parameterMappings = command.InternalElement.Mappings
                .Where(m => m.TypeId == "0ca6626b-5dc2-42f4-a0dd-2ff7aabd684b");

            foreach (var mapping in parameterMappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    var parameterType = GetTypeName(mappedEnd.TargetElement.TypeReference);
                    var parameterName = mappedEnd.TargetElement.Name.ToPascalCase().ToCamelCase();
                    parameters.Add($"{parameterName}: {parameterType}");
                }
            }

            return parameters.Distinct();
        }

        public IEnumerable<IHttpEndpointInputModel> GetInputParameters(IHttpEndpointModel endpoint)
        {
            return endpoint.Inputs.Where(m => m.TypeReference.Element.SpecializationType == "Command");
        }

        public IEnumerable<IElement> GetProperties(ComponentCommandModel command)
        {
            var commandParameter = command.InternalElement.ChildElements.FirstOrDefault(m => m.SpecializationType == "Parameter" && m.Name == "command");

            return ((IElement)commandParameter.TypeReference.Element).ChildElements;
        }

        public IEnumerable<IElementToElementMapping> GetCommandMappings(ComponentCommandModel command)
        {
            return command.InternalElement.Mappings.Where(m => m.TypeId == "0ca6626b-5dc2-42f4-a0dd-2ff7aabd684b");
        }

        public IEnumerable<IElementToElementMappedEnd> GetCommandMappingMappedEnds(IElementToElementMapping mapping)
        {
            return mapping.MappedEnds.Where(m => m.SourceElement.SpecializationType != "DTO-Field");
        }

        public string GetSource(IElementToElementMappedEnd mappedEnd)
        {
            var source = "props";

            switch (mappedEnd.SourceElement.SpecializationType)
            {
                case "Component Parameter":
                    source = "props";
                    break;
                case "Component Model Field":
                    source = "model";
                    break;
            }

            return source;
        }
    }
}
