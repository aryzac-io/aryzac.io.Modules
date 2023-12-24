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
    public static class BorderModelStereotypeExtensions
    {
        public static BorderSettings GetBorderSettings(this BorderModel model)
        {
            var stereotype = model.GetStereotype("Border Settings");
            return stereotype != null ? new BorderSettings(stereotype) : null;
        }


        public static bool HasBorderSettings(this BorderModel model)
        {
            return model.HasStereotype("Border Settings");
        }

        public static bool TryGetBorderSettings(this BorderModel model, out BorderSettings stereotype)
        {
            if (!HasBorderSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new BorderSettings(model.GetStereotype("Border Settings"));
            return true;
        }

        public class BorderSettings
        {
            private IStereotype _stereotype;

            public BorderSettings(IStereotype stereotype)
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