using System;
using System.Collections.Generic;
using Intent.Engine;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Composables.UseServiceProxy
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class UseServiceProxyTemplate : TypeScriptTemplateBase<Intent.Modelers.Types.ServiceProxies.Api.ServiceProxyModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Client.Nuxt.Files.Composables.UseServiceProxy";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public UseServiceProxyTemplate(IOutputTarget outputTarget, Intent.Modelers.Types.ServiceProxies.Api.ServiceProxyModel model) : base(TemplateId, outputTarget, model)
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TypeScriptFileConfig(
                className: $"{Model.Name}",
                fileName: $"use{Model.Name.ToPascalCase()}Proxy"
            );
        }
    }
}