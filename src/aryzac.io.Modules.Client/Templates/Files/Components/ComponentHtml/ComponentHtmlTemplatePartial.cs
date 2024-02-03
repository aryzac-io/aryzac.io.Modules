using System.Collections.Generic;
using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Modules.Client.Templates.Files.Components.ComponentHtml.Controls;
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
        }

        [IntentManaged(Mode.Merge, Body = Mode.Ignore, Signature = Mode.Fully)]
        public override ITemplateFileConfig GetTemplateFileConfig()
        {
            return new HtmlFileConfig(
                fileName: $"{Model.GetPath()}/{Model.Name}.template",
                relativeLocation: ""
            );
        }

        public string Generate(HeadingModel model)
        {
            var template = new Heading(model.InternalElement);
            return template.TransformText();
        }

        public string Generate(TableModel model)
        {
            var template = new Table(model.InternalElement);
            return template.TransformText();
        }

        public string Generate(TextboxModel model)
        {
            var template = new InputTextbox(model.InternalElement);
            return template.TransformText();
        }

        public string Generate(TextAreaModel model)
        {
            var template = new InputTextArea(model.InternalElement);
            return template.TransformText();
        }
        public string Generate(CheckboxModel model)
        {
            var template = new InputCheckbox(model.InternalElement);
            return template.TransformText();
        }

        public string GetMappedRadioButtonName(RadioButtonModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }

        public string GetMappedSelectName(SelectModel field)
        {
            foreach (var mapping in field.InternalElement.ParentElement.ParentElement.Mappings)
            {
                foreach (var mappedEnd in mapping.MappedEnds)
                {
                    if (mappedEnd.TargetElement.Id == field.Id)
                    {
                        return mappedEnd.SourceElement.Name.ToCamelCase();
                    }
                }
            }

            return field.Name.ToCamelCase();
        }
    }
}