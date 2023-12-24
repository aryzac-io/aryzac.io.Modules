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
    public static class BorderRadiusModelStereotypeExtensions
    {
        public static BorderRadiusSettings GetBorderRadiusSettings(this BorderRadiusModel model)
        {
            var stereotype = model.GetStereotype("Border Radius Settings");
            return stereotype != null ? new BorderRadiusSettings(stereotype) : null;
        }


        public static bool HasBorderRadiusSettings(this BorderRadiusModel model)
        {
            return model.HasStereotype("Border Radius Settings");
        }

        public static bool TryGetBorderRadiusSettings(this BorderRadiusModel model, out BorderRadiusSettings stereotype)
        {
            if (!HasBorderRadiusSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new BorderRadiusSettings(model.GetStereotype("Border Radius Settings"));
            return true;
        }

        public class BorderRadiusSettings
        {
            private IStereotype _stereotype;

            public BorderRadiusSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public SizeOptions Size()
            {
                return new SizeOptions(_stereotype.GetProperty<string>("Size"));
            }

            public PropertyOptions Property()
            {
                return new PropertyOptions(_stereotype.GetProperty<string>("Property"));
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
                        case "full":
                            return SizeOptionsEnum.Full;
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
                public bool IsFull()
                {
                    return Value == "full";
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
                Full
            }
            public class PropertyOptions
            {
                public readonly string Value;

                public PropertyOptions(string value)
                {
                    Value = value;
                }

                public PropertyOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "All":
                            return PropertyOptionsEnum.All;
                        case "Left":
                            return PropertyOptionsEnum.Left;
                        case "Right":
                            return PropertyOptionsEnum.Right;
                        case "Top":
                            return PropertyOptionsEnum.Top;
                        case "Bottom":
                            return PropertyOptionsEnum.Bottom;
                        case "Start":
                            return PropertyOptionsEnum.Start;
                        case "End":
                            return PropertyOptionsEnum.End;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsAll()
                {
                    return Value == "All";
                }
                public bool IsLeft()
                {
                    return Value == "Left";
                }
                public bool IsRight()
                {
                    return Value == "Right";
                }
                public bool IsTop()
                {
                    return Value == "Top";
                }
                public bool IsBottom()
                {
                    return Value == "Bottom";
                }
                public bool IsStart()
                {
                    return Value == "Start";
                }
                public bool IsEnd()
                {
                    return Value == "End";
                }
            }

            public enum PropertyOptionsEnum
            {
                All,
                Left,
                Right,
                Top,
                Bottom,
                Start,
                End
            }
        }

    }
}