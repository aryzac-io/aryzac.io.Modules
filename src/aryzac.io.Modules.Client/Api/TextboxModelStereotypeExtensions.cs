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
            var stereotype = model.GetStereotype("Textbox Settings");
            return stereotype != null ? new TextboxSettings(stereotype) : null;
        }


        public static bool HasTextboxSettings(this TextboxModel model)
        {
            return model.HasStereotype("Textbox Settings");
        }

        public static bool TryGetTextboxSettings(this TextboxModel model, out TextboxSettings stereotype)
        {
            if (!HasTextboxSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new TextboxSettings(model.GetStereotype("Textbox Settings"));
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

            public string Label()
            {
                return _stereotype.GetProperty<string>("Label");
            }

        }

    }
}