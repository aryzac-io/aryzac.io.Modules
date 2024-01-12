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

namespace Aryzac.IO.Modules.Client.Templates.Layouts.Layout
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class LayoutTemplate : IntentTemplateBase<LayoutModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Layouts.Layout";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public LayoutTemplate(IOutputTarget outputTarget, LayoutModel model) : base(TemplateId, outputTarget, model)
        {
            foreach (var child in Model.TopNavigation.InternalElement.ChildElements)
            {
                if (child.IsTopNavigationSectionModel())
                {
                    foreach (var section in Model.TopNavigation.Sections)
                    {
                        foreach (var item in section.Items)
                        {

                            item.TryGetNavigationItemSettings(out var navigationSettings);
                            var page = navigationSettings.NavigateTo().AsPageModel();
                        }
                    }
                }
            }
        }

        [IntentManaged(Mode.Fully, Body = Mode.Ignore)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new TemplateFileConfig(
                fileName: $"{Model.Name}",
                fileExtension: "vue"
            );
        }

    }
}