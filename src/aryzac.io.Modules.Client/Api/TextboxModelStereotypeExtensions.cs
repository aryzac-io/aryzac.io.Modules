using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModelExtensions", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Api
{
    public static class TextboxModelStereotypeExtensions
    {
        public static TextboxSettings GetTextboxSettings(this TextboxModel model)
        {
            var stereotype = model.GetStereotype("76a05306-e432-445c-a3ef-1bc5b4869a7d");
            return stereotype != null ? new TextboxSettings(stereotype) : null;
        }

        public static IReadOnlyCollection<TextboxSettings> GetTextboxSettingss(this TextboxModel model)
        {
            var stereotypes = model
                .GetStereotypes("76a05306-e432-445c-a3ef-1bc5b4869a7d")
                .Select(stereotype => new TextboxSettings(stereotype))
                .ToArray();

            return stereotypes;
        }


        public static bool HasTextboxSettings(this TextboxModel model)
        {
            return model.HasStereotype("76a05306-e432-445c-a3ef-1bc5b4869a7d");
        }

        public static bool TryGetTextboxSettings(this TextboxModel model, out TextboxSettings stereotype)
        {
            if (!HasTextboxSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new TextboxSettings(model.GetStereotype("76a05306-e432-445c-a3ef-1bc5b4869a7d"));
            return true;
        }

        public class TextboxSettings
        {
            private IStereotype _stereotype;

            public TextboxSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public IElement Locale()
            {
                return _stereotype.GetProperty<IElement>("Locale");
            }

            public string Label()
            {
                return _stereotype.GetProperty<string>("Label");
            }

        }

    }
}