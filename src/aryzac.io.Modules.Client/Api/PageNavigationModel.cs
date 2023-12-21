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
    public class PageNavigationModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper, IHasTypeReference
    {
        public const string SpecializationType = "Page Navigation";
        public const string SpecializationTypeId = "deee1801-cf3b-4ace-9169-c35129b771ba";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public PageNavigationModel(IElement element, string requiredType = SpecializationType)
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

        public InheritedNavigationModel InheritedNavigation => _element.ChildElements
            .GetElementsOfType(InheritedNavigationModel.SpecializationTypeId)
            .Select(x => new InheritedNavigationModel(x))
            .SingleOrDefault();

        public IList<NavigationSectionModel> Sections => _element.ChildElements
            .GetElementsOfType(NavigationSectionModel.SpecializationTypeId)
            .Select(x => new NavigationSectionModel(x))
            .ToList();

        public IList<NavigationItemModel> Items => _element.ChildElements
            .GetElementsOfType(NavigationItemModel.SpecializationTypeId)
            .Select(x => new NavigationItemModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(PageNavigationModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PageNavigationModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class PageNavigationModelExtensions
    {

        public static bool IsPageNavigationModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == PageNavigationModel.SpecializationTypeId;
        }

        public static PageNavigationModel AsPageNavigationModel(this ICanBeReferencedType type)
        {
            return type.IsPageNavigationModel() ? new PageNavigationModel((IElement)type) : null;
        }
    }
}