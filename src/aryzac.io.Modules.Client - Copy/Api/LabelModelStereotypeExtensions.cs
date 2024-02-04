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
    public static class LabelModelStereotypeExtensions
    {
        public static LabelSettings GetLabelSettings(this LabelModel model)
        {
            var stereotype = model.GetStereotype("ea62dc6f-ed7c-46c5-bcd9-c717d616f590");
            return stereotype != null ? new LabelSettings(stereotype) : null;
        }

        public static IReadOnlyCollection<LabelSettings> GetLabelSettingss(this LabelModel model)
        {
            var stereotypes = model
                .GetStereotypes("ea62dc6f-ed7c-46c5-bcd9-c717d616f590")
                .Select(stereotype => new LabelSettings(stereotype))
                .ToArray();

            return stereotypes;
        }


        public static bool HasLabelSettings(this LabelModel model)
        {
            return model.HasStereotype("ea62dc6f-ed7c-46c5-bcd9-c717d616f590");
        }

        public static bool TryGetLabelSettings(this LabelModel model, out LabelSettings stereotype)
        {
            if (!HasLabelSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new LabelSettings(model.GetStereotype("ea62dc6f-ed7c-46c5-bcd9-c717d616f590"));
            return true;
        }

        public class LabelSettings
        {
            private IStereotype _stereotype;

            public LabelSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public IElement Locale()
            {
                return _stereotype.GetProperty<IElement>("Locale");
            }

            public string Label()
            {
                return _stereotype.GetProperty<string>("Label");
            }

        }

    }
}