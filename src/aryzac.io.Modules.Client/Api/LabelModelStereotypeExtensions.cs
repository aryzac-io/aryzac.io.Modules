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
    public static class LabelModelStereotypeExtensions
    {
        public static LabelSettings GetLabelSettings(this LabelModel model)
        {
            var stereotype = model.GetStereotype("Label Settings");
            return stereotype != null ? new LabelSettings(stereotype) : null;
        }


        public static bool HasLabelSettings(this LabelModel model)
        {
            return model.HasStereotype("Label Settings");
        }

        public static bool TryGetLabelSettings(this LabelModel model, out LabelSettings stereotype)
        {
            if (!HasLabelSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new LabelSettings(model.GetStereotype("Label Settings"));
            return true;
        }

        public class LabelSettings
        {
            private IStereotype _stereotype;

            public LabelSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Label()
            {
                return _stereotype.GetProperty<string>("Label");
            }

            public string Body()
            {
                return _stereotype.GetProperty<string>("Body");
            }

        }

    }
}