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

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.UseTableOptions
{
    partial class TableHeaders
    {
        public TableHeaders(IElement element)
        {
            Element = element;
        }

        public IElement Element { get; set; }

        public IEnumerable<HeaderDefinitionModel> GetHeaders()
        {
            var table = Element.AsTableModel();
            foreach (var column in table.Columns)
            {
                var mappedColumn = table.InternalElement.Mappings
                    .FirstOrDefault()?.MappedEnds
                    .FirstOrDefault(m => m.TargetElement.Id == column.Id);

                if (mappedColumn == null || !mappedColumn.Sources.Any())
                    continue;

                var header = new HeaderDefinitionModel
                {
                    Key = column.Name.ToPascalCase().ToCamelCase(),
                    Label = $"{Helpers.GetI18nPath(column.InternalElement)}", // $"{table.Name.ToPascalCase().ToCamelCase()}.{column.Name.ToPascalCase().ToCamelCase()}",
                    DataFunction = GenerateDataFunction(mappedColumn),
                    ItemDataType = ((IElement)mappedColumn.Sources.First().Element).ParentElement.Name
                };

                yield return header;
            }
        }

        private string GenerateDataFunction(IElementToElementMappedEnd mappedColumn)
        {
            var expressions = mappedColumn.Sources.Select(source =>
            {
                var sourceName = source.Element.Name.ToPascalCase().ToCamelCase();
                return $"      const {sourceName} = item.{sourceName} || '';";
            });

            var expressionLines = string.Join(Environment.NewLine, expressions);
            var mappedExpression = ReplaceIdentifiersWithExpressions(mappedColumn.MappingExpression, mappedColumn.Sources);

            var functionBody = $"{expressionLines}\n      const mappedExpression = `{mappedExpression}`;\n      return mappedExpression;";

            return $"\r\n        if (!pending.value) {{\r\n          {functionBody}\r\n        }} else {{\r\n          return '';\r\n        }}";
        }

        private string ReplaceIdentifiersWithExpressions(string mappingExpression, IEnumerable<IElementToElementMappedEndSource> sources)
        {
            foreach (var source in sources)
            {
                mappingExpression = mappingExpression.Replace(
                    $"{{{source.ExpressionIdentifier}}}",
                    $"${{{source.Element.Name.ToPascalCase().ToCamelCase()}}}");
            }

            return mappingExpression;
        }

        public class HeaderDefinitionModel
        {
            public string Key { get; set; }
            public string Label { get; set; }
            public string DataFunction { get; set; }
            public string ItemDataType { get; set; } // Added property
        }
    }
}
