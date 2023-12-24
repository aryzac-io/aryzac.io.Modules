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
    public static class PaddingModelStereotypeExtensions
    {
        public static PaddingSettings GetPaddingSettings(this PaddingModel model)
        {
            var stereotype = model.GetStereotype("Padding Settings");
            return stereotype != null ? new PaddingSettings(stereotype) : null;
        }


        public static bool HasPaddingSettings(this PaddingModel model)
        {
            return model.HasStereotype("Padding Settings");
        }

        public static bool TryGetPaddingSettings(this PaddingModel model, out PaddingSettings stereotype)
        {
            if (!HasPaddingSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new PaddingSettings(model.GetStereotype("Padding Settings"));
            return true;
        }

        public class PaddingSettings
        {
            private IStereotype _stereotype;

            public PaddingSettings(IStereotype stereotype)
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