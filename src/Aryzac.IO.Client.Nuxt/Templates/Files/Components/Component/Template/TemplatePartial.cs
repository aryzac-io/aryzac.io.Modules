using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Xml.Linq;
using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Client.Nuxt.Templates.Files.Components.Shared;
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

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Components.Component.Template
{
    partial class Template : ComponentTemplate
    {
        public Template(IOutputTarget outputTarget, ComponentModel model) : base(outputTarget, model)
        {
            htmlTemplate = new HtmlTemplate(model.InternalElement);
        }

        private HtmlTemplate htmlTemplate;
        public string HtmlTemplate => htmlTemplate.TransformText();
    }
}