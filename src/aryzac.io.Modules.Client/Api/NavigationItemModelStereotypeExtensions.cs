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
    public static class NavigationItemModelStereotypeExtensions
    {
        public static NavigationItemSettings GetNavigationItemSettings(this NavigationItemModel model)
        {
            var stereotype = model.GetStereotype("Navigation Item Settings");
            return stereotype != null ? new NavigationItemSettings(stereotype) : null;
        }


        public static bool HasNavigationItemSettings(this NavigationItemModel model)
        {
            return model.HasStereotype("Navigation Item Settings");
        }

        public static bool TryGetNavigationItemSettings(this NavigationItemModel model, out NavigationItemSettings stereotype)
        {
            if (!HasNavigationItemSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new NavigationItemSettings(model.GetStereotype("Navigation Item Settings"));
            return true;
        }

        public class NavigationItemSettings
        {
            private IStereotype _stereotype;

            public NavigationItemSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Icon()
            {
                return _stereotype.GetProperty<string>("Icon");
            }

            public IElement NavigateTo()
            {
                return _stereotype.GetProperty<IElement>("Navigate To");
            }

        }

    }
}