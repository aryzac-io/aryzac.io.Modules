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
    public static class HeadingModelStereotypeExtensions
    {
        public static HeadingSettings GetHeadingSettings(this HeadingModel model)
        {
            var stereotype = model.GetStereotype("Heading Settings");
            return stereotype != null ? new HeadingSettings(stereotype) : null;
        }


        public static bool HasHeadingSettings(this HeadingModel model)
        {
            return model.HasStereotype("Heading Settings");
        }

        public static bool TryGetHeadingSettings(this HeadingModel model, out HeadingSettings stereotype)
        {
            if (!HasHeadingSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new HeadingSettings(model.GetStereotype("Heading Settings"));
            return true;
        }

        public class HeadingSettings
        {
            private IStereotype _stereotype;

            public HeadingSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Title()
            {
                return _stereotype.GetProperty<string>("Title");
            }

        }

    }
}