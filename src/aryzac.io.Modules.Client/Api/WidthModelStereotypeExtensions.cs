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
    public static class WidthModelStereotypeExtensions
    {
        public static WidthSettings GetWidthSettings(this WidthModel model)
        {
            var stereotype = model.GetStereotype("Width Settings");
            return stereotype != null ? new WidthSettings(stereotype) : null;
        }


        public static bool HasWidthSettings(this WidthModel model)
        {
            return model.HasStereotype("Width Settings");
        }

        public static bool TryGetWidthSettings(this WidthModel model, out WidthSettings stereotype)
        {
            if (!HasWidthSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new WidthSettings(model.GetStereotype("Width Settings"));
            return true;
        }

        public class WidthSettings
        {
            private IStereotype _stereotype;

            public WidthSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public WidthOptions Width()
            {
                return new WidthOptions(_stereotype.GetProperty<string>("Width"));
            }

            public class WidthOptions
            {
                public readonly string Value;

                public WidthOptions(string value)
                {
                    Value = value;
                }

                public WidthOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Full":
                            return WidthOptionsEnum.Full;
                        case "Screen":
                            return WidthOptionsEnum.Screen;
                        case "SVW":
                            return WidthOptionsEnum.SVW;
                        case "LVW":
                            return WidthOptionsEnum.LVW;
                        case "DVW":
                            return WidthOptionsEnum.DVW;
                        case "Min":
                            return WidthOptionsEnum.Min;
                        case "Max":
                            return WidthOptionsEnum.Max;
                        case "Fit":
                            return WidthOptionsEnum.Fit;
                        case "1":
                            return WidthOptionsEnum._1;
                        case "2":
                            return WidthOptionsEnum._2;
                        case "3":
                            return WidthOptionsEnum._3;
                        case "4":
                            return WidthOptionsEnum._4;
                        case "5":
                            return WidthOptionsEnum._5;
                        case "6":
                            return WidthOptionsEnum._6;
                        case "7":
                            return WidthOptionsEnum._7;
                        case "8":
                            return WidthOptionsEnum._8;
                        case "9":
                            return WidthOptionsEnum._9;
                        case "10":
                            return WidthOptionsEnum._10;
                        case "11":
                            return WidthOptionsEnum._11;
                        case "12":
                            return WidthOptionsEnum._12;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsFull()
                {
                    return Value == "Full";
                }
                public bool IsScreen()
                {
                    return Value == "Screen";
                }
                public bool IsSVW()
                {
                    return Value == "SVW";
                }
                public bool IsLVW()
                {
                    return Value == "LVW";
                }
                public bool IsDVW()
                {
                    return Value == "DVW";
                }
                public bool IsMin()
                {
                    return Value == "Min";
                }
                public bool IsMax()
                {
                    return Value == "Max";
                }
                public bool IsFit()
                {
                    return Value == "Fit";
                }
                public bool Is1()
                {
                    return Value == "1";
                }
                public bool Is2()
                {
                    return Value == "2";
                }
                public bool Is3()
                {
                    return Value == "3";
                }
                public bool Is4()
                {
                    return Value == "4";
                }
                public bool Is5()
                {
                    return Value == "5";
                }
                public bool Is6()
                {
                    return Value == "6";
                }
                public bool Is7()
                {
                    return Value == "7";
                }
                public bool Is8()
                {
                    return Value == "8";
                }
                public bool Is9()
                {
                    return Value == "9";
                }
                public bool Is10()
                {
                    return Value == "10";
                }
                public bool Is11()
                {
                    return Value == "11";
                }
                public bool Is12()
                {
                    return Value == "12";
                }
            }

            public enum WidthOptionsEnum
            {
                Full,
                Screen,
                SVW,
                LVW,
                DVW,
                Min,
                Max,
                Fit,
                _1,
                _2,
                _3,
                _4,
                _5,
                _6,
                _7,
                _8,
                _9,
                _10,
                _11,
                _12
            }
        }

    }
}