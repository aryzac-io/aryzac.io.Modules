using System;
using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.TypeResolvers;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.ProjectItemTemplate.Partial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Components.Component
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class ComponentTemplate : IntentTemplateBase<ComponentModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Components.Component";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public ComponentTemplate(IOutputTarget outputTarget, ComponentModel model) : base(TemplateId, outputTarget, model)
        {
            Types = new TypeScriptTypeResolver();
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TemplateFileConfig(
                fileName: $"{Model.GetPath()}/{Model.Name}",
                fileExtension: "vue"
            );
        }

    }
}