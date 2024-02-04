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

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Components.Shared.Controls
{
    partial class InputTextbox
    {
        public InputTextbox(IElement element)
        {
            Element = element;
        }

        public IElement Element { get; set; }

        public TextboxModel Model => Element.AsTextboxModel();

        public string GetMappedTextboxName(TextboxModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToPascalCase().ToCamelCase();
                    }
                }
            }

            return field.Name.ToPascalCase().ToCamelCase();
        }
    }
}
