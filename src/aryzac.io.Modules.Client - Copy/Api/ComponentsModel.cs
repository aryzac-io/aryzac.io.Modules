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
    public class ComponentsModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Components";
        public const string SpecializationTypeId = "07b847f0-5ea2-4685-bfe0-c06a6b585fdf";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public ComponentsModel(IElement element, string requiredType = SpecializationType)
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

        public IList<ComponentModel> Components => _element.ChildElements
            .GetElementsOfType(ComponentModel.SpecializationTypeId)
            .Select(x => new ComponentModel(x))
            .ToList();

        public IList<ComponentFolderModel> Folders => _element.ChildElements
            .GetElementsOfType(ComponentFolderModel.SpecializationTypeId)
            .Select(x => new ComponentFolderModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(ComponentsModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComponentsModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class ComponentsModelExtensions
    {

        public static bool IsComponentsModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == ComponentsModel.SpecializationTypeId;
        }

        public static ComponentsModel AsComponentsModel(this ICanBeReferencedType type)
        {
            return type.IsComponentsModel() ? new ComponentsModel((IElement)type) : null;
        }
    }
}