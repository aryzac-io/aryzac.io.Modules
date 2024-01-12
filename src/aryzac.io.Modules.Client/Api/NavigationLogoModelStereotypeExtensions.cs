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
    public static class NavigationLogoModelStereotypeExtensions
    {
        public static NavigationLogoSettings GetNavigationLogoSettings(this NavigationLogoModel model)
        {
            var stereotype = model.GetStereotype("Navigation Logo Settings");
            return stereotype != null ? new NavigationLogoSettings(stereotype) : null;
        }


        public static bool HasNavigationLogoSettings(this NavigationLogoModel model)
        {
            return model.HasStereotype("Navigation Logo Settings");
        }

        public static bool TryGetNavigationLogoSettings(this NavigationLogoModel model, out NavigationLogoSettings stereotype)
        {
            if (!HasNavigationLogoSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new NavigationLogoSettings(model.GetStereotype("Navigation Logo Settings"));
            return true;
        }

        public class NavigationLogoSettings
        {
            private IStereotype _stereotype;

            public NavigationLogoSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string ImageUrl()
            {
                return _stereotype.GetProperty<string>("Image Url");
            }

        }

    }
}