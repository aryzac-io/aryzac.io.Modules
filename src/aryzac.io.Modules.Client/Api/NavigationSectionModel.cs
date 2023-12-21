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
    public class NavigationSectionModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Navigation Section";
        public const string SpecializationTypeId = "d9b61c89-152b-435e-abb0-91df88b51518";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public NavigationSectionModel(IElement element, string requiredType = SpecializationType)
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

        public bool Equals(NavigationSectionModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NavigationSectionModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class NavigationSectionModelExtensions
    {

        public static bool IsNavigationSectionModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == NavigationSectionModel.SpecializationTypeId;
        }

        public static NavigationSectionModel AsNavigationSectionModel(this ICanBeReferencedType type)
        {
            return type.IsNavigationSectionModel() ? new NavigationSectionModel((IElement)type) : null;
        }
    }
}