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
            var stereotype = model.GetStereotype("3fc958c7-8c35-42f6-8f40-388ad0494fbb");
            return stereotype != null ? new HeadingSettings(stereotype) : null;
        }


        public static bool HasHeadingSettings(this HeadingModel model)
        {
            return model.HasStereotype("3fc958c7-8c35-42f6-8f40-388ad0494fbb");
        }

        public static bool TryGetHeadingSettings(this HeadingModel model, out HeadingSettings stereotype)
        {
            if (!HasHeadingSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new HeadingSettings(model.GetStereotype("3fc958c7-8c35-42f6-8f40-388ad0494fbb"));
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