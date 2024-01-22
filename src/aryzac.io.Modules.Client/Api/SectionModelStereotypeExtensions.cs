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
    public static class SectionModelStereotypeExtensions
    {
        public static SectionSettings GetSectionSettings(this SectionModel model)
        {
            var stereotype = model.GetStereotype("Section Settings");
            return stereotype != null ? new SectionSettings(stereotype) : null;
        }


        public static bool HasSectionSettings(this SectionModel model)
        {
            return model.HasStereotype("Section Settings");
        }

        public static bool TryGetSectionSettings(this SectionModel model, out SectionSettings stereotype)
        {
            if (!HasSectionSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new SectionSettings(model.GetStereotype("Section Settings"));
            return true;
        }

        public class SectionSettings
        {
            private IStereotype _stereotype;

            public SectionSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Title()
            {
                return _stereotype.GetProperty<string>("Title");
            }

            public string Description()
            {
                return _stereotype.GetProperty<string>("Description");
            }

        }

    }
}