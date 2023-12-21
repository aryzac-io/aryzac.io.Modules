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
    public static class NavigationModelStereotypeExtensions
    {
        public static NavigationSettings GetNavigationSettings(this NavigationModel model)
        {
            var stereotype = model.GetStereotype("Navigation Settings");
            return stereotype != null ? new NavigationSettings(stereotype) : null;
        }


        public static bool HasNavigationSettings(this NavigationModel model)
        {
            return model.HasStereotype("Navigation Settings");
        }

        public static bool TryGetNavigationSettings(this NavigationModel model, out NavigationSettings stereotype)
        {
            if (!HasNavigationSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new NavigationSettings(model.GetStereotype("Navigation Settings"));
            return true;
        }

        public class NavigationSettings
        {
            private IStereotype _stereotype;

            public NavigationSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public IElement Page()
            {
                return _stereotype.GetProperty<IElement>("Page");
            }

        }

    }
}