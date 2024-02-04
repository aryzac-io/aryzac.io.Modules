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

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Composables.Controls.Shared
{
    partial class Queries
    {
        public Queries(IElement element)
        {
            Element = element;
        }

        public IElement Element { get; set; }

        private IEnumerable<ComponentQueryModel> GetQueryModels()
        {
            return Element.ChildElements
                .GetElementsOfType(ComponentQueryModel.SpecializationTypeId, true)
                .Select(x => new ComponentQueryModel(x))
                .ToList();
        }
    }
}
