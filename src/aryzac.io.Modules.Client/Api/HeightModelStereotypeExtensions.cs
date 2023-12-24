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
    public static class HeightModelStereotypeExtensions
    {
        public static HeightSettings GetHeightSettings(this HeightModel model)
        {
            var stereotype = model.GetStereotype("Height Settings");
            return stereotype != null ? new HeightSettings(stereotype) : null;
        }


        public static bool HasHeightSettings(this HeightModel model)
        {
            return model.HasStereotype("Height Settings");
        }

        public static bool TryGetHeightSettings(this HeightModel model, out HeightSettings stereotype)
        {
            if (!HasHeightSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new HeightSettings(model.GetStereotype("Height Settings"));
            return true;
        }

        public class HeightSettings
        {
            private IStereotype _stereotype;

            public HeightSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public HeightOptions Height()
            {
                return new HeightOptions(_stereotype.GetProperty<string>("Height"));
            }

            public class HeightOptions
            {
                public readonly string Value;

                public HeightOptions(string value)
                {
                    Value = value;
                }

                public HeightOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Full":
                            return HeightOptionsEnum.Full;
                        case "Screen":
                            return HeightOptionsEnum.Screen;
                        case "SVW":
                            return HeightOptionsEnum.SVW;
                        case "LVW":
                            return HeightOptionsEnum.LVW;
                        case "DVW":
                            return HeightOptionsEnum.DVW;
                        case "Min":
                            return HeightOptionsEnum.Min;
                        case "Max":
                            return HeightOptionsEnum.Max;
                        case "Fit":
                            return HeightOptionsEnum.Fit;
                        case "1":
                            return HeightOptionsEnum._1;
                        case "2":
                            return HeightOptionsEnum._2;
                        case "3":
                            return HeightOptionsEnum._3;
                        case "4":
                            return HeightOptionsEnum._4;
                        case "5":
                            return HeightOptionsEnum._5;
                        case "6":
                            return HeightOptionsEnum._6;
                        case "7":
                            return HeightOptionsEnum._7;
                        case "8":
                            return HeightOptionsEnum._8;
                        case "9":
                            return HeightOptionsEnum._9;
                        case "10":
                            return HeightOptionsEnum._10;
                        case "11":
                            return HeightOptionsEnum._11;
                        case "12":
                            return HeightOptionsEnum._12;
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

            public enum HeightOptionsEnum
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