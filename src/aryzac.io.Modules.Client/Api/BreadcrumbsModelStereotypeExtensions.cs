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
    public static class BreadcrumbsModelStereotypeExtensions
    {
        public static BreadcrumbSettings GetBreadcrumbSettings(this BreadcrumbsModel model)
        {
            var stereotype = model.GetStereotype("Breadcrumb Settings");
            return stereotype != null ? new BreadcrumbSettings(stereotype) : null;
        }


        public static bool HasBreadcrumbSettings(this BreadcrumbsModel model)
        {
            return model.HasStereotype("Breadcrumb Settings");
        }

        public static bool TryGetBreadcrumbSettings(this BreadcrumbsModel model, out BreadcrumbSettings stereotype)
        {
            if (!HasBreadcrumbSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new BreadcrumbSettings(model.GetStereotype("Breadcrumb Settings"));
            return true;
        }

        public class BreadcrumbSettings
        {
            private IStereotype _stereotype;

            public BreadcrumbSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public bool IncludeCurrentPage()
            {
                return _stereotype.GetProperty<bool>("Include Current Page");
            }

        }

    }
}