using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModelExtensions", Version = "1.0")]

namespace Aryzac.Io.Modules.Client.Api
{
    public static class CssPropertyModelStereotypeExtensions
    {
        public static CssPropertySettings GetCssPropertySettings(this CssPropertyModel model)
        {
            var stereotype = model.GetStereotype("Css Property Settings");
            return stereotype != null ? new CssPropertySettings(stereotype) : null;
        }


        public static bool HasCssPropertySettings(this CssPropertyModel model)
        {
            return model.HasStereotype("Css Property Settings");
        }

        public static bool TryGetCssPropertySettings(this CssPropertyModel model, out CssPropertySettings stereotype)
        {
            if (!HasCssPropertySettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new CssPropertySettings(model.GetStereotype("Css Property Settings"));
            return true;
        }

        public class CssPropertySettings
        {
            private IStereotype _stereotype;

            public CssPropertySettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Value()
            {
                return _stereotype.GetProperty<string>("Value");
            }

        }

    }
}