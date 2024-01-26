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
    public static class TextAreaModelStereotypeExtensions
    {
        public static TextAreaSettings GetTextAreaSettings(this TextAreaModel model)
        {
            var stereotype = model.GetStereotype("7c3e71c5-7d9d-47eb-b0fc-8473359257bb");
            return stereotype != null ? new TextAreaSettings(stereotype) : null;
        }

        public static IReadOnlyCollection<TextAreaSettings> GetTextAreaSettingss(this TextAreaModel model)
        {
            var stereotypes = model
                .GetStereotypes("7c3e71c5-7d9d-47eb-b0fc-8473359257bb")
                .Select(stereotype => new TextAreaSettings(stereotype))
                .ToArray();

            return stereotypes;
        }


        public static bool HasTextAreaSettings(this TextAreaModel model)
        {
            return model.HasStereotype("7c3e71c5-7d9d-47eb-b0fc-8473359257bb");
        }

        public static bool TryGetTextAreaSettings(this TextAreaModel model, out TextAreaSettings stereotype)
        {
            if (!HasTextAreaSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new TextAreaSettings(model.GetStereotype("7c3e71c5-7d9d-47eb-b0fc-8473359257bb"));
            return true;
        }

        public class TextAreaSettings
        {
            private IStereotype _stereotype;

            public TextAreaSettings(IStereotype stereotype)
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