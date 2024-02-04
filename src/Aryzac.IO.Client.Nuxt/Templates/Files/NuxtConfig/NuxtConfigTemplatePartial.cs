using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.WebApi.Api;
using Intent.Modelers.Types.ServiceProxies.Api;
using Intent.Modelers.WebClient.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Client.Nuxt.Templates.Files.NuxtConfig
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class NuxtConfigTemplate : TypeScriptTemplateBase<object>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Client.Nuxt.Files.NuxtConfig";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public NuxtConfigTemplate(IOutputTarget outputTarget, object model = null) : base(TemplateId, outputTarget, model)
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

        public IList<ServiceProxyModel> GetServiceProxies()
        {
            return ExecutionContext.MetadataManager.WebClient(ExecutionContext.GetApplicationConfig().Id).GetServiceProxyModels().ToList();
        }

        public IList<LocalesModel> GetLocales()
        {
            return ExecutionContext.MetadataManager.WebClient(ExecutionContext.GetApplicationConfig().Id).GetLocalesModels().ToList();
        }
    }
}