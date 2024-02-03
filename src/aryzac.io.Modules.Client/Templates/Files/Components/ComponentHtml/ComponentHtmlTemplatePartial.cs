using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Modules.Client.Templates.Files.Components.Shared;
using Aryzac.IO.Modules.Client.Templates.Files.Components.Shared.Controls;
using Intent.Engine;
using Intent.Metadata.Models;
using Intent.Modules.Common.Html.Templates;
using Intent.Modules.Common.Templates;
using Intent.RoslynWeaver.Attributes;
using Intent.Templates;

[assembly: DefaultIntentManaged(Mode.Merge)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Html.Templates.HtmlFileTemplatePartial", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Templates.Files.Components.ComponentHtml
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    partial class ComponentHtmlTemplate : HtmlTemplateBase<Aryzac.IO.Modules.Client.Api.ComponentModel>
    {
        [IntentManaged(Mode.Fully)]
        public const string TemplateId = "Aryzac.IO.Modules.Client.Files.Components.ComponentHtml";

        [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
        public ComponentHtmlTemplate(IOutputTarget outputTarget, Aryzac.IO.Modules.Client.Api.ComponentModel model) : base(TemplateId, outputTarget, model)
        {
            htmlTemplate = new HtmlTemplate(model.InternalElement);
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new HtmlFileConfig(
                fileName: $"{Model.GetPath()}/{Model.Name}.template",
                relativeLocation: ""
            );
        }

        private HtmlTemplate htmlTemplate;
        public string HtmlTemplate => htmlTemplate.TransformText();
    }
}