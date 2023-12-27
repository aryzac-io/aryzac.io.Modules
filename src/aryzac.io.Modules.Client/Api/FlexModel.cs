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
    public class FlexModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Flex";
        public const string SpecializationTypeId = "b2f308b0-b572-4721-a21d-f09a0e9d2aeb";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public FlexModel(IElement element, string requiredType = SpecializationType)
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

        public IList<FlexRowModel> FlexRows => _element.ChildElements
            .GetElementsOfType(FlexRowModel.SpecializationTypeId)
            .Select(x => new FlexRowModel(x))
            .ToList();

        public IList<FlexColumnModel> FlexColumns => _element.ChildElements
            .GetElementsOfType(FlexColumnModel.SpecializationTypeId)
            .Select(x => new FlexColumnModel(x))
            .ToList();

        public IList<FlexReverseModel> FlexReverses => _element.ChildElements
            .GetElementsOfType(FlexReverseModel.SpecializationTypeId)
            .Select(x => new FlexReverseModel(x))
            .ToList();

        public IList<FlexWrapModel> FlexWraps => _element.ChildElements
            .GetElementsOfType(FlexWrapModel.SpecializationTypeId)
            .Select(x => new FlexWrapModel(x))
            .ToList();

        public IList<FlexNoWrapModel> FlexNoWraps => _element.ChildElements
            .GetElementsOfType(FlexNoWrapModel.SpecializationTypeId)
            .Select(x => new FlexNoWrapModel(x))
            .ToList();

        public IList<Flex1Model> Flex1s => _element.ChildElements
            .GetElementsOfType(Flex1Model.SpecializationTypeId)
            .Select(x => new Flex1Model(x))
            .ToList();

        public IList<FlexAutoModel> FlexAutos => _element.ChildElements
            .GetElementsOfType(FlexAutoModel.SpecializationTypeId)
            .Select(x => new FlexAutoModel(x))
            .ToList();

        public IList<FlexInitialModel> FlexInitials => _element.ChildElements
            .GetElementsOfType(FlexInitialModel.SpecializationTypeId)
            .Select(x => new FlexInitialModel(x))
            .ToList();

        public IList<FlexNoneModel> FlexNones => _element.ChildElements
            .GetElementsOfType(FlexNoneModel.SpecializationTypeId)
            .Select(x => new FlexNoneModel(x))
            .ToList();

        public IList<FlexGrowModel> FlexGrows => _element.ChildElements
            .GetElementsOfType(FlexGrowModel.SpecializationTypeId)
            .Select(x => new FlexGrowModel(x))
            .ToList();

        public IList<FlexShrinkModel> FlexShrinks => _element.ChildElements
            .GetElementsOfType(FlexShrinkModel.SpecializationTypeId)
            .Select(x => new FlexShrinkModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(FlexModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FlexModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class FlexModelExtensions
    {

        public static bool IsFlexModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == FlexModel.SpecializationTypeId;
        }

        public static FlexModel AsFlexModel(this ICanBeReferencedType type)
        {
            return type.IsFlexModel() ? new FlexModel((IElement)type) : null;
        }
    }
}