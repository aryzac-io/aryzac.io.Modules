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
            var stereotype = model.GetStereotype("aff6bbb9-c26b-4a01-b8d3-d7ccc5f61da8");
            return stereotype != null ? new AttributeSettings(stereotype) : null;
        }

        public static IReadOnlyCollection<AttributeSettings> GetAttributeSettingss(this HeadingAttributeModel model)
        {
            var stereotypes = model
                .GetStereotypes("aff6bbb9-c26b-4a01-b8d3-d7ccc5f61da8")
                .Select(stereotype => new AttributeSettings(stereotype))
                .ToArray();

            return stereotypes;
        }


        public static bool HasAttributeSettings(this HeadingAttributeModel model)
        {
            return model.HasStereotype("aff6bbb9-c26b-4a01-b8d3-d7ccc5f61da8");
        }

        public static bool TryGetAttributeSettings(this HeadingAttributeModel model, out AttributeSettings stereotype)
        {
            if (!HasAttributeSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new AttributeSettings(model.GetStereotype("aff6bbb9-c26b-4a01-b8d3-d7ccc5f61da8"));
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

            public IElement Locale()
            {
                return _stereotype.GetProperty<IElement>("Locale");
            }

            public string Icon()
            {
                return _stereotype.GetProperty<string>("Icon");
            }

        }

    }
}