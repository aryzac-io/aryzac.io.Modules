using System;
using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modelers.WebClient.Api;
using Intent.Modules.Common;
using Intent.Modules.Common.Registrations;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TemplateRegistration.FilePerModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseSelectOptions
{
    [IntentManaged(Mode.Merge, Body = Mode.Merge, Signature = Mode.Fully)]
    public class UseSelectOptionsTemplateRegistration : FilePerModelTemplateRegistration<SelectModel>
    {
        private readonly IMetadataManager _metadataManager;

        public UseSelectOptionsTemplateRegistration(IMetadataManager metadataManager)
        {
            _metadataManager = metadataManager;
        }

        public override string TemplateId => UseSelectOptionsTemplate.TemplateId;

        [IntentManaged(Mode.Fully)]
        public override ITemplate CreateTemplateInstance(IOutputTarget outputTarget, SelectModel model)
        {
            return new UseSelectOptionsTemplate(outputTarget, model);
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public override IEnumerable<SelectModel> GetModels(IApplication application)
        {
            return _metadataManager.WebClient(application).GetSelectModels();
        }
    }
}