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
    public static class RadioButtonModelStereotypeExtensions
    {
        public static RadioButtonSettings GetRadioButtonSettings(this RadioButtonModel model)
        {
            var stereotype = model.GetStereotype("e5b364b7-563a-4bef-9968-d5ec50947a67");
            return stereotype != null ? new RadioButtonSettings(stereotype) : null;
        }


        public static bool HasRadioButtonSettings(this RadioButtonModel model)
        {
            return model.HasStereotype("e5b364b7-563a-4bef-9968-d5ec50947a67");
        }

        public static bool TryGetRadioButtonSettings(this RadioButtonModel model, out RadioButtonSettings stereotype)
        {
            if (!HasRadioButtonSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new RadioButtonSettings(model.GetStereotype("e5b364b7-563a-4bef-9968-d5ec50947a67"));
            return true;
        }

        public class RadioButtonSettings
        {
            private IStereotype _stereotype;

            public RadioButtonSettings(IStereotype stereotype)
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