using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModelExtensions", Version = "1.0")]

namespace Aryzac.Io.Modules.Client.Api
{
    public static class CommandModelStereotypeExtensions
    {
        public static CommandSettings GetCommandSettings(this CommandModel model)
        {
            var stereotype = model.GetStereotype("Command Settings");
            return stereotype != null ? new CommandSettings(stereotype) : null;
        }

        public static IReadOnlyCollection<CommandSettings> GetCommandSettingss(this CommandModel model)
        {
            var stereotypes = model
                .GetStereotypes("Command Settings")
                .Select(stereotype => new CommandSettings(stereotype))
                .ToArray();

            return stereotypes;
        }


        public static bool HasCommandSettings(this CommandModel model)
        {
            return model.HasStereotype("Command Settings");
        }

        public static bool TryGetCommandSettings(this CommandModel model, out CommandSettings stereotype)
        {
            if (!HasCommandSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new CommandSettings(model.GetStereotype("Command Settings"));
            return true;
        }

        public class CommandSettings
        {
            private IStereotype _stereotype;

            public CommandSettings(IStereotype stereotype)
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

            public InteractionOptions Interaction()
            {
                return new InteractionOptions(_stereotype.GetProperty<string>("Interaction"));
            }

            public class InteractionOptions
            {
                public readonly string Value;

                public InteractionOptions(string value)
                {
                    Value = value;
                }

                public InteractionOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "On Click":
                            return InteractionOptionsEnum.OnClick;
                        case "On Hover":
                            return InteractionOptionsEnum.OnHover;
                        case "On Key Press":
                            return InteractionOptionsEnum.OnKeyPress;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsOnClick()
                {
                    return Value == "On Click";
                }
                public bool IsOnHover()
                {
                    return Value == "On Hover";
                }
                public bool IsOnKeyPress()
                {
                    return Value == "On Key Press";
                }
            }

            public enum InteractionOptionsEnum
            {
                OnClick,
                OnHover,
                OnKeyPress
            }
        }

    }
}