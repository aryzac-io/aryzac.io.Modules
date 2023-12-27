using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Aryzac.Io.Modules.Client.Api
{
    [IntentManaged(Mode.Fully, Signature = Mode.Fully)]
    public class StyleModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Style";
        public const string SpecializationTypeId = "2c9f3240-b036-4850-ac3f-51d94e8f0c28";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public StyleModel(IElement element, string requiredType = SpecializationType)
        {
            if (!requiredType.Equals(element.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a '{GetType().Name}' from element with specialization type '{element.SpecializationType}'. Must be of type '{SpecializationType}'");
            }
            _element = element;
        }

        public string Id => _element.Id;

        public string Name => _element.Name;

        public string Comment => _element.Comment;

        public IEnumerable<IStereotype> Stereotypes => _element.Stereotypes;

        public IElement InternalElement => _element;

        public BreakpointsModel Breakpoints => _element.ChildElements
            .GetElementsOfType(BreakpointsModel.SpecializationTypeId)
            .Select(x => new BreakpointsModel(x))
            .SingleOrDefault();

        public ColorsModel Colors => _element.ChildElements
            .GetElementsOfType(ColorsModel.SpecializationTypeId)
            .Select(x => new ColorsModel(x))
            .SingleOrDefault();

        public BorderModel Border => _element.ChildElements
            .GetElementsOfType(BorderModel.SpecializationTypeId)
            .Select(x => new BorderModel(x))
            .SingleOrDefault();

        public PaddingModel Padding => _element.ChildElements
            .GetElementsOfType(PaddingModel.SpecializationTypeId)
            .Select(x => new PaddingModel(x))
            .SingleOrDefault();

        public MarginModel Margin => _element.ChildElements
            .GetElementsOfType(MarginModel.SpecializationTypeId)
            .Select(x => new MarginModel(x))
            .SingleOrDefault();

        public ShadowModel Shadow => _element.ChildElements
            .GetElementsOfType(ShadowModel.SpecializationTypeId)
            .Select(x => new ShadowModel(x))
            .SingleOrDefault();

        public WidthModel Width => _element.ChildElements
            .GetElementsOfType(WidthModel.SpecializationTypeId)
            .Select(x => new WidthModel(x))
            .SingleOrDefault();

        public HeightModel Height => _element.ChildElements
            .GetElementsOfType(HeightModel.SpecializationTypeId)
            .Select(x => new HeightModel(x))
            .SingleOrDefault();

        public ColorModel Color => _element.ChildElements
            .GetElementsOfType(ColorModel.SpecializationTypeId)
            .Select(x => new ColorModel(x))
            .SingleOrDefault();

        public BackgroundColorModel BackgroundColor => _element.ChildElements
            .GetElementsOfType(BackgroundColorModel.SpecializationTypeId)
            .Select(x => new BackgroundColorModel(x))
            .SingleOrDefault();

        public IList<CssStyleModel> CssStyles => _element.ChildElements
            .GetElementsOfType(CssStyleModel.SpecializationTypeId)
            .Select(x => new CssStyleModel(x))
            .ToList();

        public IList<FlexModel> Flexes => _element.ChildElements
            .GetElementsOfType(FlexModel.SpecializationTypeId)
            .Select(x => new FlexModel(x))
            .ToList();

        public IList<ImageModel> Images => _element.ChildElements
            .GetElementsOfType(ImageModel.SpecializationTypeId)
            .Select(x => new ImageModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(StyleModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StyleModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class StyleModelExtensions
    {

        public static bool IsStyleModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == StyleModel.SpecializationTypeId;
        }

        public static StyleModel AsStyleModel(this ICanBeReferencedType type)
        {
            return type.IsStyleModel() ? new StyleModel((IElement)type) : null;
        }
    }
}