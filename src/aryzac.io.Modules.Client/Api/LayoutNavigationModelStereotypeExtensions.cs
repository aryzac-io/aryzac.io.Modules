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
    public static class LayoutNavigationModelStereotypeExtensions
    {
        public static FooterNavigationSettings GetFooterNavigationSettings(this LayoutNavigationModel model)
        {
            var stereotype = model.GetStereotype("Footer Navigation Settings");
            return stereotype != null ? new FooterNavigationSettings(stereotype) : null;
        }


        public static bool HasFooterNavigationSettings(this LayoutNavigationModel model)
        {
            return model.HasStereotype("Footer Navigation Settings");
        }

        public static bool TryGetFooterNavigationSettings(this LayoutNavigationModel model, out FooterNavigationSettings stereotype)
        {
            if (!HasFooterNavigationSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new FooterNavigationSettings(model.GetStereotype("Footer Navigation Settings"));
            return true;
        }

        public static SidebarNavigationSettings GetSidebarNavigationSettings(this LayoutNavigationModel model)
        {
            var stereotype = model.GetStereotype("Sidebar Navigation Settings");
            return stereotype != null ? new SidebarNavigationSettings(stereotype) : null;
        }


        public static bool HasSidebarNavigationSettings(this LayoutNavigationModel model)
        {
            return model.HasStereotype("Sidebar Navigation Settings");
        }

        public static bool TryGetSidebarNavigationSettings(this LayoutNavigationModel model, out SidebarNavigationSettings stereotype)
        {
            if (!HasSidebarNavigationSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new SidebarNavigationSettings(model.GetStereotype("Sidebar Navigation Settings"));
            return true;
        }

        public static TopNavigationSettings GetTopNavigationSettings(this LayoutNavigationModel model)
        {
            var stereotype = model.GetStereotype("Top Navigation Settings");
            return stereotype != null ? new TopNavigationSettings(stereotype) : null;
        }


        public static bool HasTopNavigationSettings(this LayoutNavigationModel model)
        {
            return model.HasStereotype("Top Navigation Settings");
        }

        public static bool TryGetTopNavigationSettings(this LayoutNavigationModel model, out TopNavigationSettings stereotype)
        {
            if (!HasTopNavigationSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new TopNavigationSettings(model.GetStereotype("Top Navigation Settings"));
            return true;
        }

        public class FooterNavigationSettings
        {
            private IStereotype _stereotype;

            public FooterNavigationSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class SidebarNavigationSettings
        {
            private IStereotype _stereotype;

            public SidebarNavigationSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public bool Collapsible()
            {
                return _stereotype.GetProperty<bool>("Collapsible");
            }

        }

        public class TopNavigationSettings
        {
            private IStereotype _stereotype;

            public TopNavigationSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

    }
}