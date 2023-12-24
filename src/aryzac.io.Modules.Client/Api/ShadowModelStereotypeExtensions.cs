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
    public static class ShadowModelStereotypeExtensions
    {
        public static ShadowSettings GetShadowSettings(this ShadowModel model)
        {
            var stereotype = model.GetStereotype("Shadow Settings");
            return stereotype != null ? new ShadowSettings(stereotype) : null;
        }


        public static bool HasShadowSettings(this ShadowModel model)
        {
            return model.HasStereotype("Shadow Settings");
        }

        public static bool TryGetShadowSettings(this ShadowModel model, out ShadowSettings stereotype)
        {
            if (!HasShadowSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new ShadowSettings(model.GetStereotype("Shadow Settings"));
            return true;
        }

        public class ShadowSettings
        {
            private IStereotype _stereotype;

            public ShadowSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public SizeOptions Size()
            {
                return new SizeOptions(_stereotype.GetProperty<string>("Size"));
            }

            public class SizeOptions
            {
                public readonly string Value;

                public SizeOptions(string value)
                {
                    Value = value;
                }

                public SizeOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "none":
                            return SizeOptionsEnum.None;
                        case "xs":
                            return SizeOptionsEnum.Xs;
                        case "sm":
                            return SizeOptionsEnum.Sm;
                        case "md":
                            return SizeOptionsEnum.Md;
                        case "lg":
                            return SizeOptionsEnum.Lg;
                        case "xl":
                            return SizeOptionsEnum.Xl;
                        case "2xl":
                            return SizeOptionsEnum._2xl;
                        case "inner":
                            return SizeOptionsEnum.Inner;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsNone()
                {
                    return Value == "none";
                }
                public bool IsXs()
                {
                    return Value == "xs";
                }
                public bool IsSm()
                {
                    return Value == "sm";
                }
                public bool IsMd()
                {
                    return Value == "md";
                }
                public bool IsLg()
                {
                    return Value == "lg";
                }
                public bool IsXl()
                {
                    return Value == "xl";
                }
                public bool Is2xl()
                {
                    return Value == "2xl";
                }
                public bool IsInner()
                {
                    return Value == "inner";
                }
            }

            public enum SizeOptionsEnum
            {
                None,
                Xs,
                Sm,
                Md,
                Lg,
                Xl,
                _2xl,
                Inner
            }
        }

    }
}