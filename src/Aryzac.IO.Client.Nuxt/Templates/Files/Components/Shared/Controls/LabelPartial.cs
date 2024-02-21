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

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Components.Shared.Controls
{
    partial class Label
    {
        public Label(IElement element)
        {
            Element = element;
        }

        public IElement Element { get; set; }

        public LabelModel Model => Element.AsLabelModel();

        public string GetHeadingOptionsComposableName()
        {
            return $"{Model.Name.ToPascalCase().ToCamelCase()}Options";
        }
    }
}