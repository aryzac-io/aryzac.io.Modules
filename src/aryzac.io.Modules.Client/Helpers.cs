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
                    paths.Add(currentElement.Name.ToPascalCase().ToCamelCase());
                }

                currentElement = currentElement.ParentElement;
            }

            paths.Reverse();

            return string.Join(".", paths);
        }
    }
}
