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
    public static class ComponentModelStereotypeExtensions
    {
        public static ComponentSettings GetComponentSettings(this ComponentModel model)
        {
            var stereotype = model.GetStereotype("9d350135-b53e-4ae7-86fd-eb7004522d79");
            return stereotype != null ? new ComponentSettings(stereotype) : null;
        }


        public static bool HasComponentSettings(this ComponentModel model)
        {
            return model.HasStereotype("9d350135-b53e-4ae7-86fd-eb7004522d79");
        }

        public static bool TryGetComponentSettings(this ComponentModel model, out ComponentSettings stereotype)
        {
            if (!HasComponentSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new ComponentSettings(model.GetStereotype("9d350135-b53e-4ae7-86fd-eb7004522d79"));
            return true;
        }

        public class ComponentSettings
        {
            private IStereotype _stereotype;

            public ComponentSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public bool SeparateTemplate()
            {
                return _stereotype.GetProperty<bool>("Separate Template");
            }

        }

    }
}