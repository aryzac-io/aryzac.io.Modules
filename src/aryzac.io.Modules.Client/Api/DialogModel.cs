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
    public class DialogModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper, IHasTypeReference
    {
        public const string SpecializationType = "Dialog";
        public const string SpecializationTypeId = "4dfb2d6b-9396-4e1c-a681-c5336de624be";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public DialogModel(IElement element, string requiredType = SpecializationType)
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

        public ITypeReference TypeReference => _element.TypeReference;

        public IElement InternalElement => _element;

        public StyleModel Style => _element.ChildElements
            .GetElementsOfType(StyleModel.SpecializationTypeId)
            .Select(x => new StyleModel(x))
            .SingleOrDefault();

        public ContainerHeaderModel Header => _element.ChildElements
            .GetElementsOfType(ContainerHeaderModel.SpecializationTypeId)
            .Select(x => new ContainerHeaderModel(x))
            .SingleOrDefault();

        public ContainerBodyModel Body => _element.ChildElements
            .GetElementsOfType(ContainerBodyModel.SpecializationTypeId)
            .Select(x => new ContainerBodyModel(x))
            .SingleOrDefault();

        public ContainerActionsModel Actions => _element.ChildElements
            .GetElementsOfType(ContainerActionsModel.SpecializationTypeId)
            .Select(x => new ContainerActionsModel(x))
            .SingleOrDefault();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(DialogModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DialogModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class DialogModelExtensions
    {

        public static bool IsDialogModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == DialogModel.SpecializationTypeId;
        }

        public static DialogModel AsDialogModel(this ICanBeReferencedType type)
        {
            return type.IsDialogModel() ? new DialogModel((IElement)type) : null;
        }
    }
}