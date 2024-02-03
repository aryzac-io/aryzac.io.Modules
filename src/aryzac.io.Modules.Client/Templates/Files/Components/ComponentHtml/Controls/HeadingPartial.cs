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

namespace Aryzac.IO.Modules.Client.Templates.Files.Components.ComponentHtml.Controls
{
    partial class Heading
    {
        public Heading(IElement element)
        {
            Element = element;
        }

        public IElement Element { get; set; }

        public HeadingModel HeadingModel => Element.AsHeadingModel();

        public bool HasAttributes()
        {
            if (HeadingModel.Attributes is null) return false;

            return HeadingModel.Attributes.Any();
        }

        public bool HasActions()
        {
            if (HeadingModel.Actions is null) return false;

            return HeadingModel.Actions.Actions.Any();
        }

        public string GetHeadingOptionsComposableName()
        {
            return $"{HeadingModel.Name.ToPascalCase().ToCamelCase()}Options";
        }
    }
}
