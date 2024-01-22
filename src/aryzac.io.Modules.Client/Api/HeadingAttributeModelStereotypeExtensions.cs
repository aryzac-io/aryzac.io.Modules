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
    public static class HeadingAttributeModelStereotypeExtensions
    {
        public static AttributeSettings GetAttributeSettings(this HeadingAttributeModel model)
        {
            var stereotype = model.GetStereotype("Attribute Settings");
            return stereotype != null ? new AttributeSettings(stereotype) : null;
        }


        public static bool HasAttributeSettings(this HeadingAttributeModel model)
        {
            return model.HasStereotype("Attribute Settings");
        }

        public static bool TryGetAttributeSettings(this HeadingAttributeModel model, out AttributeSettings stereotype)
        {
            if (!HasAttributeSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new AttributeSettings(model.GetStereotype("Attribute Settings"));
            return true;
        }

        public class AttributeSettings
        {
            private IStereotype _stereotype;

            public AttributeSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Icon()
            {
                return _stereotype.GetProperty<string>("Icon");
            }

        }

    }
}