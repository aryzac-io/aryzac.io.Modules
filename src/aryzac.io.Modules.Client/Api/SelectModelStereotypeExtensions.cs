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
    public static class SelectModelStereotypeExtensions
    {
        public static SelectSettings GetSelectSettings(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Select Settings");
            return stereotype != null ? new SelectSettings(stereotype) : null;
        }


        public static bool HasSelectSettings(this SelectModel model)
        {
            return model.HasStereotype("Select Settings");
        }

        public static bool TryGetSelectSettings(this SelectModel model, out SelectSettings stereotype)
        {
            if (!HasSelectSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new SelectSettings(model.GetStereotype("Select Settings"));
            return true;
        }

        public class SelectSettings
        {
            private IStereotype _stereotype;

            public SelectSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Label()
            {
                return _stereotype.GetProperty<string>("Label");
            }

        }

    }
}