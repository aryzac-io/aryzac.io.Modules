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
    public static class LocaleModelStereotypeExtensions
    {
        public static DefaultLocale GetDefaultLocale(this LocaleModel model)
        {
            var stereotype = model.GetStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d");
            return stereotype != null ? new DefaultLocale(stereotype) : null;
        }


        public static bool HasDefaultLocale(this LocaleModel model)
        {
            return model.HasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d");
        }

        public static bool TryGetDefaultLocale(this LocaleModel model, out DefaultLocale stereotype)
        {
            if (!HasDefaultLocale(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new DefaultLocale(model.GetStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d"));
            return true;
        }

        public static LocaleSettings GetLocaleSettings(this LocaleModel model)
        {
            var stereotype = model.GetStereotype("73ce4f91-9a92-485f-856f-6fc2331cf475");
            return stereotype != null ? new LocaleSettings(stereotype) : null;
        }


        public static bool HasLocaleSettings(this LocaleModel model)
        {
            return model.HasStereotype("73ce4f91-9a92-485f-856f-6fc2331cf475");
        }

        public static bool TryGetLocaleSettings(this LocaleModel model, out LocaleSettings stereotype)
        {
            if (!HasLocaleSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new LocaleSettings(model.GetStereotype("73ce4f91-9a92-485f-856f-6fc2331cf475"));
            return true;
        }

        public class DefaultLocale
        {
            private IStereotype _stereotype;

            public DefaultLocale(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class LocaleSettings
        {
            private IStereotype _stereotype;

            public LocaleSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string ISOCode()
            {
                return _stereotype.GetProperty<string>("ISO Code");
            }

        }

    }
}