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
    public class LayoutNavigationModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Layout Navigation";
        public const string SpecializationTypeId = "504052da-efcd-4f9d-8177-ba6a2c7bfa79";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public LayoutNavigationModel(IElement element, string requiredType = SpecializationType)
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

        public IList<NavigationLogoModel> Logos => _element.ChildElements
            .GetElementsOfType(NavigationLogoModel.SpecializationTypeId)
            .Select(x => new NavigationLogoModel(x))
            .ToList();

        public IList<NavigationSectionModel> Sections => _element.ChildElements
            .GetElementsOfType(NavigationSectionModel.SpecializationTypeId)
            .Select(x => new NavigationSectionModel(x))
            .ToList();

        public IList<NavigationItemModel> Items => _element.ChildElements
            .GetElementsOfType(NavigationItemModel.SpecializationTypeId)
            .Select(x => new NavigationItemModel(x))
            .ToList();

        public IList<ComponentReferenceModel> Components => _element.ChildElements
            .GetElementsOfType(ComponentReferenceModel.SpecializationTypeId)
            .Select(x => new ComponentReferenceModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(LayoutNavigationModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LayoutNavigationModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class LayoutNavigationModelExtensions
    {

        public static bool IsLayoutNavigationModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == LayoutNavigationModel.SpecializationTypeId;
        }

        public static LayoutNavigationModel AsLayoutNavigationModel(this ICanBeReferencedType type)
        {
            return type.IsLayoutNavigationModel() ? new LayoutNavigationModel((IElement)type) : null;
        }
    }
}