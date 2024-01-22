using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Engine;
using Intent.Metadata.WebApi.Api;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.NuxtConfig
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class NuxtConfigTemplate : TypeScriptTemplateBase<IList<Intent.Modelers.Types.ServiceProxies.Api.ServiceProxyModel>>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.NuxtConfig";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public NuxtConfigTemplate(IOutputTarget outputTarget, IList<Intent.Modelers.Types.ServiceProxies.Api.ServiceProxyModel> model) : base(TemplateId, outputTarget, model)
        {

        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TypeScriptFileConfig(
                className: $"nuxt.config",
                fileName: $"nuxt.config"
            );
        }
    }
}