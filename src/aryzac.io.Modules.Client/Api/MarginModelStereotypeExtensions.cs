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
    public static class MarginModelStereotypeExtensions
    {
        public static MarginSettings GetMarginSettings(this MarginModel model)
        {
            var stereotype = model.GetStereotype("Margin Settings");
            return stereotype != null ? new MarginSettings(stereotype) : null;
        }


        public static bool HasMarginSettings(this MarginModel model)
        {
            return model.HasStereotype("Margin Settings");
        }

        public static bool TryGetMarginSettings(this MarginModel model, out MarginSettings stereotype)
        {
            if (!HasMarginSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new MarginSettings(model.GetStereotype("Margin Settings"));
            return true;
        }

        public class MarginSettings
        {
            private IStereotype _stereotype;

            public MarginSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public int? All()
            {
                return _stereotype.GetProperty<int?>("All");
            }

            public int? Top()
            {
                return _stereotype.GetProperty<int?>("Top");
            }

            public int? Left()
            {
                return _stereotype.GetProperty<int?>("Left");
            }

            public int? Right()
            {
                return _stereotype.GetProperty<int?>("Right");
            }

            public int? Bottom()
            {
                return _stereotype.GetProperty<int?>("Bottom");
            }

        }

    }
}