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
    public static class SelectModelStereotypeExtensions
    {
        public static Align GetAlign(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Align");
            return stereotype != null ? new Align(stereotype) : null;
        }


        public static bool HasAlign(this SelectModel model)
        {
            return model.HasStereotype("Align");
        }

        public static bool TryGetAlign(this SelectModel model, out Align stereotype)
        {
            if (!HasAlign(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new Align(model.GetStereotype("Align"));
            return true;
        }

        public static Flex GetFlex(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Flex");
            return stereotype != null ? new Flex(stereotype) : null;
        }


        public static bool HasFlex(this SelectModel model)
        {
            return model.HasStereotype("Flex");
        }

        public static bool TryGetFlex(this SelectModel model, out Flex stereotype)
        {
            if (!HasFlex(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new Flex(model.GetStereotype("Flex"));
            return true;
        }

        public static FlexAuto GetFlexAuto(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Flex Auto");
            return stereotype != null ? new FlexAuto(stereotype) : null;
        }


        public static bool HasFlexAuto(this SelectModel model)
        {
            return model.HasStereotype("Flex Auto");
        }

        public static bool TryGetFlexAuto(this SelectModel model, out FlexAuto stereotype)
        {
            if (!HasFlexAuto(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new FlexAuto(model.GetStereotype("Flex Auto"));
            return true;
        }

        public static FlexColumns GetFlexColumns(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Flex Columns");
            return stereotype != null ? new FlexColumns(stereotype) : null;
        }


        public static bool HasFlexColumns(this SelectModel model)
        {
            return model.HasStereotype("Flex Columns");
        }

        public static bool TryGetFlexColumns(this SelectModel model, out FlexColumns stereotype)
        {
            if (!HasFlexColumns(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new FlexColumns(model.GetStereotype("Flex Columns"));
            return true;
        }

        public static FlexGrow GetFlexGrow(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Flex Grow");
            return stereotype != null ? new FlexGrow(stereotype) : null;
        }


        public static bool HasFlexGrow(this SelectModel model)
        {
            return model.HasStereotype("Flex Grow");
        }

        public static bool TryGetFlexGrow(this SelectModel model, out FlexGrow stereotype)
        {
            if (!HasFlexGrow(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new FlexGrow(model.GetStereotype("Flex Grow"));
            return true;
        }

        public static FlexInitial GetFlexInitial(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Flex Initial");
            return stereotype != null ? new FlexInitial(stereotype) : null;
        }


        public static bool HasFlexInitial(this SelectModel model)
        {
            return model.HasStereotype("Flex Initial");
        }

        public static bool TryGetFlexInitial(this SelectModel model, out FlexInitial stereotype)
        {
            if (!HasFlexInitial(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new FlexInitial(model.GetStereotype("Flex Initial"));
            return true;
        }

        public static FlexNone GetFlexNone(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Flex None");
            return stereotype != null ? new FlexNone(stereotype) : null;
        }


        public static bool HasFlexNone(this SelectModel model)
        {
            return model.HasStereotype("Flex None");
        }

        public static bool TryGetFlexNone(this SelectModel model, out FlexNone stereotype)
        {
            if (!HasFlexNone(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new FlexNone(model.GetStereotype("Flex None"));
            return true;
        }

        public static FlexReverse GetFlexReverse(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Flex Reverse");
            return stereotype != null ? new FlexReverse(stereotype) : null;
        }


        public static bool HasFlexReverse(this SelectModel model)
        {
            return model.HasStereotype("Flex Reverse");
        }

        public static bool TryGetFlexReverse(this SelectModel model, out FlexReverse stereotype)
        {
            if (!HasFlexReverse(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new FlexReverse(model.GetStereotype("Flex Reverse"));
            return true;
        }

        public static FlexRow GetFlexRow(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Flex Row");
            return stereotype != null ? new FlexRow(stereotype) : null;
        }


        public static bool HasFlexRow(this SelectModel model)
        {
            return model.HasStereotype("Flex Row");
        }

        public static bool TryGetFlexRow(this SelectModel model, out FlexRow stereotype)
        {
            if (!HasFlexRow(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new FlexRow(model.GetStereotype("Flex Row"));
            return true;
        }

        public static FlexShrink GetFlexShrink(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Flex Shrink");
            return stereotype != null ? new FlexShrink(stereotype) : null;
        }


        public static bool HasFlexShrink(this SelectModel model)
        {
            return model.HasStereotype("Flex Shrink");
        }

        public static bool TryGetFlexShrink(this SelectModel model, out FlexShrink stereotype)
        {
            if (!HasFlexShrink(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new FlexShrink(model.GetStereotype("Flex Shrink"));
            return true;
        }

        public static FlexWrap GetFlexWrap(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Flex Wrap");
            return stereotype != null ? new FlexWrap(stereotype) : null;
        }


        public static bool HasFlexWrap(this SelectModel model)
        {
            return model.HasStereotype("Flex Wrap");
        }

        public static bool TryGetFlexWrap(this SelectModel model, out FlexWrap stereotype)
        {
            if (!HasFlexWrap(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new FlexWrap(model.GetStereotype("Flex Wrap"));
            return true;
        }

        public static Gap GetGap(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Gap");
            return stereotype != null ? new Gap(stereotype) : null;
        }


        public static bool HasGap(this SelectModel model)
        {
            return model.HasStereotype("Gap");
        }

        public static bool TryGetGap(this SelectModel model, out Gap stereotype)
        {
            if (!HasGap(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new Gap(model.GetStereotype("Gap"));
            return true;
        }

        public static GapX GetGapX(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Gap X");
            return stereotype != null ? new GapX(stereotype) : null;
        }


        public static bool HasGapX(this SelectModel model)
        {
            return model.HasStereotype("Gap X");
        }

        public static bool TryGetGapX(this SelectModel model, out GapX stereotype)
        {
            if (!HasGapX(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new GapX(model.GetStereotype("Gap X"));
            return true;
        }

        public static GapY GetGapY(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Gap Y");
            return stereotype != null ? new GapY(stereotype) : null;
        }


        public static bool HasGapY(this SelectModel model)
        {
            return model.HasStereotype("Gap Y");
        }

        public static bool TryGetGapY(this SelectModel model, out GapY stereotype)
        {
            if (!HasGapY(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new GapY(model.GetStereotype("Gap Y"));
            return true;
        }
        public static Grid GetGrid(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Grid");
            return stereotype != null ? new Grid(stereotype) : null;
        }


        public static bool HasGrid(this SelectModel model)
        {
            return model.HasStereotype("Grid");
        }

        public static bool TryGetGrid(this SelectModel model, out Grid stereotype)
        {
            if (!HasGrid(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new Grid(model.GetStereotype("Grid"));
            return true;
        }

        public static GridColumnSpan GetGridColumnSpan(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Grid Column Span");
            return stereotype != null ? new GridColumnSpan(stereotype) : null;
        }


        public static bool HasGridColumnSpan(this SelectModel model)
        {
            return model.HasStereotype("Grid Column Span");
        }

        public static bool TryGetGridColumnSpan(this SelectModel model, out GridColumnSpan stereotype)
        {
            if (!HasGridColumnSpan(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new GridColumnSpan(model.GetStereotype("Grid Column Span"));
            return true;
        }

        public static GridColumns GetGridColumns(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Grid Columns");
            return stereotype != null ? new GridColumns(stereotype) : null;
        }


        public static bool HasGridColumns(this SelectModel model)
        {
            return model.HasStereotype("Grid Columns");
        }

        public static bool TryGetGridColumns(this SelectModel model, out GridColumns stereotype)
        {
            if (!HasGridColumns(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new GridColumns(model.GetStereotype("Grid Columns"));
            return true;
        }

        public static GridRowSpan GetGridRowSpan(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Grid Row Span");
            return stereotype != null ? new GridRowSpan(stereotype) : null;
        }


        public static bool HasGridRowSpan(this SelectModel model)
        {
            return model.HasStereotype("Grid Row Span");
        }

        public static bool TryGetGridRowSpan(this SelectModel model, out GridRowSpan stereotype)
        {
            if (!HasGridRowSpan(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new GridRowSpan(model.GetStereotype("Grid Row Span"));
            return true;
        }

        public static GridRows GetGridRows(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Grid Rows");
            return stereotype != null ? new GridRows(stereotype) : null;
        }


        public static bool HasGridRows(this SelectModel model)
        {
            return model.HasStereotype("Grid Rows");
        }

        public static bool TryGetGridRows(this SelectModel model, out GridRows stereotype)
        {
            if (!HasGridRows(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new GridRows(model.GetStereotype("Grid Rows"));
            return true;
        }

        public static Justify GetJustify(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Justify");
            return stereotype != null ? new Justify(stereotype) : null;
        }


        public static bool HasJustify(this SelectModel model)
        {
            return model.HasStereotype("Justify");
        }

        public static bool TryGetJustify(this SelectModel model, out Justify stereotype)
        {
            if (!HasJustify(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new Justify(model.GetStereotype("Justify"));
            return true;
        }

        public static Order GetOrder(this SelectModel model)
        {
            var stereotype = model.GetStereotype("Order");
            return stereotype != null ? new Order(stereotype) : null;
        }


        public static bool HasOrder(this SelectModel model)
        {
            return model.HasStereotype("Order");
        }

        public static bool TryGetOrder(this SelectModel model, out Order stereotype)
        {
            if (!HasOrder(model))
            {
                stereotype = null;
                return false;
            }

            stereotype = new Order(model.GetStereotype("Order"));
            return true;
        }

        public class Align
        {
            private IStereotype _stereotype;

            public Align(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public AlignmentOptions Alignment()
            {
                return new AlignmentOptions(_stereotype.GetProperty<string>("Alignment"));
            }

            public TargetOptions Target()
            {
                return new TargetOptions(_stereotype.GetProperty<string>("Target"));
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
                        case "Auto":
                            return AlignmentOptionsEnum.Auto;
                        case "Start":
                            return AlignmentOptionsEnum.Start;
                        case "End":
                            return AlignmentOptionsEnum.End;
                        case "Baseline":
                            return AlignmentOptionsEnum.Baseline;
                        case "Center":
                            return AlignmentOptionsEnum.Center;
                        case "Stretch":
                            return AlignmentOptionsEnum.Stretch;
                        case "Normal":
                            return AlignmentOptionsEnum.Normal;
                        case "Between":
                            return AlignmentOptionsEnum.Between;
                        case "Around":
                            return AlignmentOptionsEnum.Around;
                        case "Evenly":
                            return AlignmentOptionsEnum.Evenly;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsAuto()
                {
                    return Value == "Auto";
                }
                public bool IsStart()
                {
                    return Value == "Start";
                }
                public bool IsEnd()
                {
                    return Value == "End";
                }
                public bool IsBaseline()
                {
                    return Value == "Baseline";
                }
                public bool IsCenter()
                {
                    return Value == "Center";
                }
                public bool IsStretch()
                {
                    return Value == "Stretch";
                }
                public bool IsNormal()
                {
                    return Value == "Normal";
                }
                public bool IsBetween()
                {
                    return Value == "Between";
                }
                public bool IsAround()
                {
                    return Value == "Around";
                }
                public bool IsEvenly()
                {
                    return Value == "Evenly";
                }
            }

            public enum AlignmentOptionsEnum
            {
                Auto,
                Start,
                End,
                Baseline,
                Center,
                Stretch,
                Normal,
                Between,
                Around,
                Evenly
            }
            public class TargetOptions
            {
                public readonly string Value;

                public TargetOptions(string value)
                {
                    Value = value;
                }

                public TargetOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Content":
                            return TargetOptionsEnum.Content;
                        case "Items":
                            return TargetOptionsEnum.Items;
                        case "Self":
                            return TargetOptionsEnum.Self;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsContent()
                {
                    return Value == "Content";
                }
                public bool IsItems()
                {
                    return Value == "Items";
                }
                public bool IsSelf()
                {
                    return Value == "Self";
                }
            }

            public enum TargetOptionsEnum
            {
                Content,
                Items,
                Self
            }
        }

        public class Flex
        {
            private IStereotype _stereotype;

            public Flex(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class FlexAuto
        {
            private IStereotype _stereotype;

            public FlexAuto(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class FlexColumns
        {
            private IStereotype _stereotype;

            public FlexColumns(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class FlexGrow
        {
            private IStereotype _stereotype;

            public FlexGrow(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class FlexInitial
        {
            private IStereotype _stereotype;

            public FlexInitial(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class FlexNone
        {
            private IStereotype _stereotype;

            public FlexNone(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class FlexReverse
        {
            private IStereotype _stereotype;

            public FlexReverse(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class FlexRow
        {
            private IStereotype _stereotype;

            public FlexRow(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class FlexShrink
        {
            private IStereotype _stereotype;

            public FlexShrink(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class FlexWrap
        {
            private IStereotype _stereotype;

            public FlexWrap(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class Gap
        {
            private IStereotype _stereotype;

            public Gap(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public int? Size()
            {
                return _stereotype.GetProperty<int?>("Size");
            }

        }

        public class GapX
        {
            private IStereotype _stereotype;

            public GapX(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public int? Size()
            {
                return _stereotype.GetProperty<int?>("Size");
            }

        }

        public class GapY
        {
            private IStereotype _stereotype;

            public GapY(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public int? Size()
            {
                return _stereotype.GetProperty<int?>("Size");
            }

        }

        public class Grid
        {
            private IStereotype _stereotype;

            public Grid(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

        }

        public class GridColumnSpan
        {
            private IStereotype _stereotype;

            public GridColumnSpan(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public int? ColumnSpan()
            {
                return _stereotype.GetProperty<int?>("Column Span");
            }

        }

        public class GridColumns
        {
            private IStereotype _stereotype;

            public GridColumns(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public int? NumberOfColumns()
            {
                return _stereotype.GetProperty<int?>("Number of Columns");
            }

        }

        public class GridRowSpan
        {
            private IStereotype _stereotype;

            public GridRowSpan(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public int? RowSpan()
            {
                return _stereotype.GetProperty<int?>("Row Span");
            }

        }

        public class GridRows
        {
            private IStereotype _stereotype;

            public GridRows(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public int? NumberOfRows()
            {
                return _stereotype.GetProperty<int?>("Number of Rows");
            }

        }

        public class Justify
        {
            private IStereotype _stereotype;

            public Justify(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public AlignmentOptions Alignment()
            {
                return new AlignmentOptions(_stereotype.GetProperty<string>("Alignment"));
            }

            public TargetOptions Target()
            {
                return new TargetOptions(_stereotype.GetProperty<string>("Target"));
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
                        case "Auto":
                            return AlignmentOptionsEnum.Auto;
                        case "Start":
                            return AlignmentOptionsEnum.Start;
                        case "End":
                            return AlignmentOptionsEnum.End;
                        case "Baseline":
                            return AlignmentOptionsEnum.Baseline;
                        case "Center":
                            return AlignmentOptionsEnum.Center;
                        case "Stretch":
                            return AlignmentOptionsEnum.Stretch;
                        case "Normal":
                            return AlignmentOptionsEnum.Normal;
                        case "Between":
                            return AlignmentOptionsEnum.Between;
                        case "Around":
                            return AlignmentOptionsEnum.Around;
                        case "Evenly":
                            return AlignmentOptionsEnum.Evenly;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsAuto()
                {
                    return Value == "Auto";
                }
                public bool IsStart()
                {
                    return Value == "Start";
                }
                public bool IsEnd()
                {
                    return Value == "End";
                }
                public bool IsBaseline()
                {
                    return Value == "Baseline";
                }
                public bool IsCenter()
                {
                    return Value == "Center";
                }
                public bool IsStretch()
                {
                    return Value == "Stretch";
                }
                public bool IsNormal()
                {
                    return Value == "Normal";
                }
                public bool IsBetween()
                {
                    return Value == "Between";
                }
                public bool IsAround()
                {
                    return Value == "Around";
                }
                public bool IsEvenly()
                {
                    return Value == "Evenly";
                }
            }

            public enum AlignmentOptionsEnum
            {
                Auto,
                Start,
                End,
                Baseline,
                Center,
                Stretch,
                Normal,
                Between,
                Around,
                Evenly
            }
            public class TargetOptions
            {
                public readonly string Value;

                public TargetOptions(string value)
                {
                    Value = value;
                }

                public TargetOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "Content":
                            return TargetOptionsEnum.Content;
                        case "Items":
                            return TargetOptionsEnum.Items;
                        case "Self":
                            return TargetOptionsEnum.Self;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsContent()
                {
                    return Value == "Content";
                }
                public bool IsItems()
                {
                    return Value == "Items";
                }
                public bool IsSelf()
                {
                    return Value == "Self";
                }
            }

            public enum TargetOptionsEnum
            {
                Content,
                Items,
                Self
            }
        }

        public class Order
        {
            private IStereotype _stereotype;

            public Order(IStereotype stereotype)
            {
                _stereotype = stereotype;
            }

            public string Name => _stereotype.Name;

            public ValueOptions Value()
            {
                return new ValueOptions(_stereotype.GetProperty<string>("Value"));
            }

            public class ValueOptions
            {
                public readonly string Value;

                public ValueOptions(string value)
                {
                    Value = value;
                }

                public ValueOptionsEnum AsEnum()
                {
                    switch (Value)
                    {
                        case "First":
                            return ValueOptionsEnum.First;
                        case "Last":
                            return ValueOptionsEnum.Last;
                        case "None":
                            return ValueOptionsEnum.None;
                        case "1":
                            return ValueOptionsEnum._1;
                        case "2":
                            return ValueOptionsEnum._2;
                        case "3":
                            return ValueOptionsEnum._3;
                        case "4":
                            return ValueOptionsEnum._4;
                        case "5":
                            return ValueOptionsEnum._5;
                        case "6":
                            return ValueOptionsEnum._6;
                        case "7":
                            return ValueOptionsEnum._7;
                        case "8":
                            return ValueOptionsEnum._8;
                        case "9":
                            return ValueOptionsEnum._9;
                        case "10":
                            return ValueOptionsEnum._10;
                        case "11":
                            return ValueOptionsEnum._11;
                        case "12":
                            return ValueOptionsEnum._12;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                public bool IsFirst()
                {
                    return Value == "First";
                }
                public bool IsLast()
                {
                    return Value == "Last";
                }
                public bool IsNone()
                {
                    return Value == "None";
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

            public enum ValueOptionsEnum
            {
                First,
                Last,
                None,
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