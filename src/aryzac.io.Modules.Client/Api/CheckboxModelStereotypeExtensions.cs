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
    public static class CheckboxModelStereotypeExtensions
    {
        public static CheckboxSettings GetCheckboxSettings(this CheckboxModel model)
        {
            var stereotype = model.GetStereotype("1fafd144-4893-4a55-835a-487ad4b41bfe");
            return stereotype != null ? new CheckboxSettings(stereotype) : null;
        }

        public static IReadOnlyCollection<CheckboxSettings> GetCheckboxSettingss(this CheckboxModel model)
        {
            var stereotypes = model
                .GetStereotypes("1fafd144-4893-4a55-835a-487ad4b41bfe")
                .Select(stereotype => new CheckboxSettings(stereotype))
                .ToArray();

            return stereotypes;
        }


        public static bool HasCheckboxSettings(this CheckboxModel model)
        {
            return model.HasStereotype("1fafd144-4893-4a55-835a-487ad4b41bfe");
        }

        public static bool TryGetCheckboxSettings(this CheckboxModel model, out CheckboxSettings stereotype)
        {
            if (!HasCheckboxSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new CheckboxSettings(model.GetStereotype("1fafd144-4893-4a55-835a-487ad4b41bfe"));
            return true;
        }

        public class CheckboxSettings
        {
            private IStereotype _stereotype;

            public CheckboxSettings(IStereotype stereotype)
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

            public string Description()
            {
                return _stereotype.GetProperty<string>("Description");
            }

        }

    }
}