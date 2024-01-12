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
    public class NavigationItemModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Navigation Item";
        public const string SpecializationTypeId = "27ebf07c-5f47-49cb-8ccf-b5dc2cffa951";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public NavigationItemModel(IElement element, string requiredType = SpecializationType)
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

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(NavigationItemModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NavigationItemModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class NavigationItemModelExtensions
    {

        public static bool IsNavigationItemModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == NavigationItemModel.SpecializationTypeId;
        }

        public static NavigationItemModel AsNavigationItemModel(this ICanBeReferencedType type)
        {
            return type.IsNavigationItemModel() ? new NavigationItemModel((IElement)type) : null;
        }
    }
}