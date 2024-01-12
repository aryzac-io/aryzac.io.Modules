using System;
using System.Collections.Generic;
using System.Linq;
using Aryzac.IO.Modules.Client.Api;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.ProjectItemTemplate.Partial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Pages.Page
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class PageTemplate : IntentTemplateBase<PageModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Pages.Page";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public PageTemplate(IOutputTarget outputTarget, PageModel model) : base(TemplateId, outputTarget, model)
        {
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