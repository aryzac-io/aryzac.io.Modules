using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Api
{
    [IntentManaged(Mode.Fully, Signature = Mode.Fully)]
    public class HeadingModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Heading";
        public const string SpecializationTypeId = "2bf5bef0-a091-4ff8-a5d6-fe931a86616f";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public HeadingModel(IElement element, string requiredType = SpecializationType)
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

        public IList<HeadingAttributeModel> Attributes => _element.ChildElements
            .GetElementsOfType(HeadingAttributeModel.SpecializationTypeId)
            .Select(x => new HeadingAttributeModel(x))
            .ToList();

        public ActionsModel Actions => _element.ChildElements
            .GetElementsOfType(ActionsModel.SpecializationTypeId)
            .Select(x => new ActionsModel(x))
            .SingleOrDefault();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(HeadingModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((HeadingModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class HeadingModelExtensions
    {

        public static bool IsHeadingModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == HeadingModel.SpecializationTypeId;
        }

        public static HeadingModel AsHeadingModel(this ICanBeReferencedType type)
        {
            return type.IsHeadingModel() ? new HeadingModel((IElement)type) : null;
        }
    }
}