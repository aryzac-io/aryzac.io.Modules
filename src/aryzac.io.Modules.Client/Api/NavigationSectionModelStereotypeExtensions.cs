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
    public static class NavigationSectionModelStereotypeExtensions
    {
        public static NavigationSectionSettings GetNavigationSectionSettings(this NavigationSectionModel model)
        {
            var stereotype = model.GetStereotype("Navigation Section Settings");
            return stereotype != null ? new NavigationSectionSettings(stereotype) : null;
        }


        public static bool HasNavigationSectionSettings(this NavigationSectionModel model)
        {
            return model.HasStereotype("Navigation Section Settings");
        }

        public static bool TryGetNavigationSectionSettings(this NavigationSectionModel model, out NavigationSectionSettings stereotype)
        {
            if (!HasNavigationSectionSettings(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new NavigationSectionSettings(model.GetStereotype("Navigation Section Settings"));
            return true;
        }

        public class NavigationSectionSettings
        {
            private IStereotype _stereotype;

            public NavigationSectionSettings(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public AlignmentOptions Alignment()
            {
                return new AlignmentOptions(_stereotype.GetProperty<string>("Alignment"));
            }

            public JustifyOptions Justify()
            {
                return new JustifyOptions(_stereotype.GetProperty<string>("Justify"));
            }

            public bool Stretch()
            {
                return _stereotype.GetProperty<bool>("Stretch");
            }

            public class AlignmentOptions
            {
                public readonly string Value;

                public AlignmentOptions(string value)
                {
                    Value = value;
                }

                public AlignmentOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Left":
                            return AlignmentOptionsEnum.Left;
                        case "Justify":
                            return AlignmentOptionsEnum.Justify;
                        case "Right":
                            return AlignmentOptionsEnum.Right;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsLeft()
                {
                    return Value == "Left";
                }
                public bool IsJustify()
                {
                    return Value == "Justify";
                }
                public bool IsRight()
                {
                    return Value == "Right";
                }
            }

            public enum AlignmentOptionsEnum
            {
                Left,
                Justify,
                Right
            }
            public class JustifyOptions
            {
                public readonly string Value;

                public JustifyOptions(string value)
                {
                    Value = value;
                }

                public JustifyOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Start":
                            return JustifyOptionsEnum.Start;
                        case "Justify":
                            return JustifyOptionsEnum.Justify;
                        case "End":
                            return JustifyOptionsEnum.End;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsStart()
                {
                    return Value == "Start";
                }
                public bool IsJustify()
                {
                    return Value == "Justify";
                }
                public bool IsEnd()
                {
                    return Value == "End";
                }
            }

            public enum JustifyOptionsEnum
            {
                Start,
                Justify,
                End
            }
        }

    }
}