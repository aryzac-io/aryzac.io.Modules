using System;
using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.Modules.Common.TypeScript.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.TypeScript.Templates.TypescriptTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Composables.Controls.UseLabelOptions
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class UseLabelOptionsTemplate : TypeScriptTemplateBase<Aryzac.IO.Modules.Client.Api.LabelModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Composables.Controls.UseLabelOptions";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public UseLabelOptionsTemplate(IOutputTarget outputTarget, Aryzac.IO.Modules.Client.Api.LabelModel model) : base(TemplateId, outputTarget, model)
        {
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TypeScriptFileConfig(
                className: $"{Model.Name}",
                fileName: $"{Model.Name.ToKebabCase()}"
            );
        }
    }
}