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
            var stereotype = model.GetStereotype("d4e49575-65a5-472a-8c4b-a4fb12c162bc");
            return stereotype != null ? new NavigationItemSettings(stereotype) : null;
        }


        public static bool HasNavigationItemSettings(this NavigationItemModel model)
        {
            return model.HasStereotype("d4e49575-65a5-472a-8c4b-a4fb12c162bc");
        }

        public static bool TryGetNavigationItemSettings(this NavigationItemModel model, out NavigationItemSettings stereotype)
        {
            if (!HasNavigationItemSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new NavigationItemSettings(model.GetStereotype("d4e49575-65a5-472a-8c4b-a4fb12c162bc"));
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

            public IElement Locale()
            {
                return _stereotype.GetProperty<IElement>("Locale");
            }

            public string Icon()
            {
                return _stereotype.GetProperty<string>("Icon");
            }

            public string Label()
            {
                return _stereotype.GetProperty<string>("Label");
            }

        }

    }
}