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
    public static class ActionModelStereotypeExtensions
    {
        public static ActionSettings GetActionSettings(this ActionModel model)
        {
            var stereotype = model.GetStereotype("ea0f9d89-8d52-4d58-b4d2-9095a9bf5606");
            return stereotype != null ? new ActionSettings(stereotype) : null;
        }


        public static bool HasActionSettings(this ActionModel model)
        {
            return model.HasStereotype("ea0f9d89-8d52-4d58-b4d2-9095a9bf5606");
        }

        public static bool TryGetActionSettings(this ActionModel model, out ActionSettings stereotype)
        {
            if (!HasActionSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new ActionSettings(model.GetStereotype("ea0f9d89-8d52-4d58-b4d2-9095a9bf5606"));
            return true;
        }

        public class ActionSettings
        {
            private IStereotype _stereotype;

            public ActionSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public string Icon()
            {
                return _stereotype.GetProperty<string>("Icon");
            }

            public string Label()
            {
                return _stereotype.GetProperty<string>("Label");
            }

        }

    }
}