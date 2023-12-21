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

            public string LogoUrl()
            {
                return _stereotype.GetProperty<string>("Logo Url");
            }

            public string SmallLogoUrl()
            {
                return _stereotype.GetProperty<string>("Small Logo Url");
            }

            public bool IsDark()
            {
                return _stereotype.GetProperty<bool>("Is Dark");
            }

        }

    }
}