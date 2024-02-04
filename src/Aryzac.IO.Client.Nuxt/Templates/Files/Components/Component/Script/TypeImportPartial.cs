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

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Components.Component.Script
{
    partial class TypeImport : ComponentTemplate
    {
        public TypeImport(IOutputTarget outputTarget, ComponentModel model) : base(outputTarget, model)
        {
        }
    }
}