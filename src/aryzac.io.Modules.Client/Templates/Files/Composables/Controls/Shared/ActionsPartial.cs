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
    partial class Actions
    {
        public Actions(IElement element)
        {
            Element = element;
        }

        public IElement Element { get; set; }

        public IEnumerable<ActionDefinitionModel> GetActions()
        {
            var actions = Element.ChildElements.Where(x => x.SpecializationTypeId == "ccc50dcf-42e3-4b91-8772-bb48739c17e8")
                .Select(x => x.AsActionsModel())
                .FirstOrDefault();

            if (actions is null) yield break;
            if (actions.Actions is null) yield break;

            foreach (var action in actions.Actions)
            {
                var actionSettings = action.GetActionSettingss().FirstOrDefault();
                var actionModel = new ActionDefinitionModel
                {
                    Label = $"{Element.Name.ToPascalCase().ToCamelCase()}.actions.{action.Name.ToPascalCase().ToCamelCase()}.label",
                    ActionFunction = GenerateActionFunction(action)
                };

                if (actionSettings?.Icon() is not null)
                {
                    actionModel.Icon = $"{Element.Name.ToPascalCase().ToCamelCase()}.actions.{action.Name.ToPascalCase().ToCamelCase()}.icon";
                }

                yield return actionModel;
            }
        }

        private string GenerateActionFunction(ActionModel action)
        {
            if (action.Navigation != null)
            {
                return GenerateNavigationActionFunction(action);
            }
            else if (action.Command != null)
            {
                return GenerateCommandActionFunction(action);
            }

            return string.Empty; // Fallback for unsupported action types
        }

        private string GenerateNavigationActionFunction(ActionModel action)
        {
            var page = action.Navigation.TypeReference.Element.AsPageModel();
            var pageUrl = page.GetRoutePath();

            var navigation = action.Navigation;
            var functionParameters = new Dictionary<string, string>();

            foreach (var mapping in navigation.InternalElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    var source = "";

                    switch (mappedEnd.SourceElement.SpecializationType)
                    {
                        case "Component Parameter":
                            source = "props";
                            break;
                        case "Component Model Field":
                            source = "model";
                            if (!functionParameters.ContainsKey(source))
                                functionParameters.Add(source, ((IElement)mappedEnd.SourceElement).ParentElement.Name.ToPascalCase().ToCamelCase());
                            break;
                        case "DTO-Field":
                            source = "item";
                            if (!functionParameters.ContainsKey(source))
                                functionParameters.Add(source, ((IElement)mappedEnd.SourceElement).ParentElement.Name.ToPascalCase().ToCamelCase());
                            break;
                    }

                    source += ".";

                    pageUrl = pageUrl.Replace($"[{mappedEnd.TargetElement.Name}]", $"${{{source}{mappedEnd.SourceElement.Name.ToPascalCase().ToCamelCase()}}}");
                }
            }

            return $@"action: async ({ string.Join(", ", functionParameters.Select(kv => $"{kv.Key}: {kv.Value}")) }) => {{
      const localeRoute = useLocaleRoute();
      await navigateTo(localeRoute(`{pageUrl}`));
    }},";
        }

        private string GenerateCommandActionFunction(ActionModel action)
        {
            var parameterMappings = action.Command.InternalElement.Mappings
                .Where(m => m.TypeId == "0ca6626b-5dc2-42f4-a0dd-2ff7aabd684b")
                .SelectMany(m => m.MappedEnds)
                .Select(mappedEnd => $"item.{mappedEnd.TargetElement.Name.ToPascalCase().ToCamelCase()}")
                .ToList();

            var parameters = string.Join(", ", parameterMappings);

            return $@"action: async (item: {((IElement)action.Command.InternalElement.Mappings.First().MappedEnds.First().SourceElement).ParentElement.Name}) => {{
      await {action.Command.Mapping.Element.Name.ToPascalCase().ToCamelCase()}({parameters});
    }},";
        }


        public class ActionDefinitionModel
        {
            public string Label { get; set; }
            public string Icon { get; set; }
            public string ActionFunction { get; set; }
        }
    }
}
