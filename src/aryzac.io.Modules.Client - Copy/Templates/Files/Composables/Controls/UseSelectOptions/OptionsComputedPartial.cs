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

namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseSelectOptions
{
    partial class OptionsComputed
    {
        public OptionsComputed(IElement element)
        {
            Element = element;

            Initialize(element);
        }

        public IElement Element { get; set; }

        public string ValueField { get; set; }

        public void Initialize(IElement select)
        {
            foreach (var mapping in select.Mappings)
            {
                foreach (var mappingEnd in mapping.MappedEnds)
                {
                    if (mappingEnd.TargetElement.SpecializationType == "Value")
                    {
                        ValueField = mappingEnd.SourceElement.Name;
                    }
                }
            }
        }

        public IElementToElementMappedEnd GetMappedColumn(SelectModel select)
        {
            return select.InternalElement.Mappings.FirstOrDefault()?.MappedEnds.FirstOrDefault(m => m.MappingTypeId == "74330c09-3675-4796-b7c9-8f5132b9c59b");
        }
    }
}
