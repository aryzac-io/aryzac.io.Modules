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
    public class ComponentFolderModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Component Folder";
        public const string SpecializationTypeId = "ca698be1-3d9a-4a36-8415-a452954d9d00";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public ComponentFolderModel(IElement element, string requiredType = SpecializationType)
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

        public bool Equals(ComponentFolderModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComponentFolderModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class ComponentFolderModelExtensions
    {

        public static bool IsComponentFolderModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == ComponentFolderModel.SpecializationTypeId;
        }

        public static ComponentFolderModel AsComponentFolderModel(this ICanBeReferencedType type)
        {
            return type.IsComponentFolderModel() ? new ComponentFolderModel((IElement)type) : null;
        }
    }
}