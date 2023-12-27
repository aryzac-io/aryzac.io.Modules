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
    public class LayoutTemplateModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Layout Template";
        public const string SpecializationTypeId = "22f69e94-c4eb-45b3-b4d0-d9af393ee172";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public LayoutTemplateModel(IElement element, string requiredType = SpecializationType)
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

        public IList<FormDefinitionModel> FormDefinitions => _element.ChildElements
            .GetElementsOfType(FormDefinitionModel.SpecializationTypeId)
            .Select(x => new FormDefinitionModel(x))
            .ToList();

        public IList<ContainerModel> Containers => _element.ChildElements
            .GetElementsOfType(ContainerModel.SpecializationTypeId)
            .Select(x => new ContainerModel(x))
            .ToList();

        public IList<CardModel> Cards => _element.ChildElements
            .GetElementsOfType(CardModel.SpecializationTypeId)
            .Select(x => new CardModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(LayoutTemplateModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LayoutTemplateModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class LayoutTemplateModelExtensions
    {

        public static bool IsLayoutTemplateModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == LayoutTemplateModel.SpecializationTypeId;
        }

        public static LayoutTemplateModel AsLayoutTemplateModel(this ICanBeReferencedType type)
        {
            return type.IsLayoutTemplateModel() ? new LayoutTemplateModel((IElement)type) : null;
        }
    }
}