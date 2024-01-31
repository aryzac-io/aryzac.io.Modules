using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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

namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseTableOptions
{
    partial class TableActions
    {
        public TableActions(IElement element)
        {
            Element = element;
        }

        public IElement Element { get; set; }

        public IEnumerable<ActionDefinitionModel> GetActions()
        {
            var table = Element.AsTableModel();
            if (table.Actions == null) yield break;

            foreach (var action in table.Actions.Actions)
            {
                action.TryGetActionSettings(out var actionSettings);
                var actionModel = new ActionDefinitionModel
                {
                    Label = $"{table.Name.ToPascalCase().ToCamelCase()}.actions.{action.Name.ToPascalCase().ToCamelCase()}.label",
                    Icon = actionSettings.Icon() != null ? $"{table.Name.ToPascalCase().ToCamelCase()}.actions.{action.Name.ToPascalCase().ToCamelCase()}.icon" : null,
                    ActionFunction = GenerateActionFunction(action)
                };

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

            foreach (var mapping in action.Navigation.InternalElement.Mappings)
            {
                foreach (var mappingEnd in mapping.MappedEnds)
                {
                    pageUrl = pageUrl.Replace($"[{mappingEnd.TargetElement.Name}]", $"${{item.{mappingEnd.SourceElement.Name.ToPascalCase().ToCamelCase()}}}");
                }
            }

            return $@"action: async (item: {((IElement)action.Navigation.InternalElement.Mappings.First().MappedEnds.First().SourceElement).ParentElement.Name}) => {{
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
