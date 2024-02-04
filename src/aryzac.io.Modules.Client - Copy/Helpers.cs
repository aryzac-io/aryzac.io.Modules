using Aryzac.IO.Modules.Client.Api;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aryzac.IO.Modules.Client
{
    public static class Helpers
    {
        public static string GetI18nPath(this IElement element)
        {
            var skippedSpecializationTypes = new List<string>()
            {
                ComponentViewModel.SpecializationTypeId,
            };

            var attributedSpecializationTypes = new List<string>()
            {
                TableModel.SpecializationTypeId,
                SectionModel.SpecializationTypeId,
                ActionModel.SpecializationTypeId,
                SelectModel.SpecializationTypeId,
                RadioButtonModel.SpecializationTypeId,
                LabelModel.SpecializationTypeId,
                CheckboxModel.SpecializationTypeId,
                TextAreaModel.SpecializationTypeId,
                TextboxModel.SpecializationTypeId,
                HeadingModel.SpecializationTypeId,
                HeadingAttributeModel.SpecializationTypeId,
            };

            var parentElement = element.GetFirstParentOfType(
                ComponentModel.SpecializationTypeId,
                PageModel.SpecializationTypeId,
                LayoutModel.SpecializationTypeId
            );

            var currentElement = element;
            var paths = new List<string>();

            while (currentElement != parentElement)
            {
                if (!skippedSpecializationTypes.Contains(currentElement.SpecializationTypeId))
                {
                    var path = currentElement.Name.ToPascalCase().ToCamelCase();

                    if (path.StartsWith("[") && path.EndsWith("]"))
                    {
                        path = path.Substring(1, path.Length - 2);
                    }

                    switch (currentElement.SpecializationTypeId)
                    {
                        case TableModel.SpecializationTypeId:
                            path = "table-" + path;
                            break;
                        case SectionModel.SpecializationTypeId:
                            path = "section-" + path;
                            break;
                        case ActionModel.SpecializationTypeId:
                            path = "action-" + path;
                            break;
                        case SelectModel.SpecializationTypeId:
                            path = "select-" + path;
                            break;
                        case RadioButtonModel.SpecializationTypeId:
                            path = "radio-" + path;
                            break;
                        case LabelModel.SpecializationTypeId:
                            path = "label-" + path;
                            break;
                        case CheckboxModel.SpecializationTypeId:
                            path = "checkbox-" + path;
                            break;
                        case TextAreaModel.SpecializationTypeId:
                            path = "text-area-" + path;
                            break;
                        case TextboxModel.SpecializationTypeId:
                            path = "textbox-" + path;
                            break;
                        case HeadingModel.SpecializationTypeId:
                            path = "heading-" + path;
                            break;
                        case HeadingAttributeModel.SpecializationTypeId:
                            path = "attribute-" + path;
                            break;
                    }   

                    paths.Add(path);
                }

                currentElement = currentElement.ParentElement;
            }

            paths.Reverse();

            return string.Join(".", paths);
        }
    }
}
