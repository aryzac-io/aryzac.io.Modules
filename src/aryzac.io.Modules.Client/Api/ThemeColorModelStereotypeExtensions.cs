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
    public static class ThemeColorModelStereotypeExtensions
    {
        public static ThemeColorSettings GetThemeColorSettings(this ThemeColorModel model)
        {
            var stereotype = model.GetStereotype("Theme Color Settings");
            return stereotype != null ? new ThemeColorSettings(stereotype) : null;
        }


        public static bool HasThemeColorSettings(this ThemeColorModel model)
        {
            return model.HasStereotype("Theme Color Settings");
        }

        public static bool TryGetThemeColorSettings(this ThemeColorModel model, out ThemeColorSettings stereotype)
        {
            if (!HasThemeColorSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new ThemeColorSettings(model.GetStereotype("Theme Color Settings"));
            return true;
        }

        public class ThemeColorSettings
        {
            private IStereotype _stereotype;

            public ThemeColorSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Color()
            {
                return _stereotype.GetProperty<string>("Color");
            }

        }

    }
}