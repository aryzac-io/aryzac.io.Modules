using Aryzac.IO.Modules.Client.Api;
using Aryzac.IO.Client.Nuxt.Templates.Files.Components.Shared.Controls;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Templates;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aryzac.IO.Client.Nuxt.Templates.Files.Components.Shared
{
    public static class GenerateHelpers
    {
        public static string Generate(HeadingModel model)
        {
            var template = new Heading(model.InternalElement);
            return template.TransformText();
        }

        public static string Generate(TableModel model)
        {
            var template = new Table(model.InternalElement);
            return template.TransformText();
        }

        public static string Generate(SectionModel model)
        {
            var template = new Section(model.InternalElement);
            return template.TransformText();
        }

        public static string Generate(TextboxModel model)
        {
            var template = new InputTextbox(model.InternalElement);
            return template.TransformText();
        }

        public static string Generate(TextAreaModel model)
        {
            var template = new InputTextArea(model.InternalElement);
            return template.TransformText();
        }

        public static string Generate(CheckboxModel model)
        {
            var template = new InputCheckbox(model.InternalElement);
            return template.TransformText();
        }

        public static string Generate(SelectModel model)
        {
            var template = new InputSelect(model.InternalElement);
            return template.TransformText();
        }

        public static string Generate(LabelModel model)
        {
            var template = new Label(model.InternalElement);
            return template.TransformText();
        }
    }
}
