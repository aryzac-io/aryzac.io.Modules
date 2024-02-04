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
    public class TopNavigationModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Top Navigation";
        public const string SpecializationTypeId = "4be6a3ee-337d-428c-9a2d-e8d306055ad5";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public TopNavigationModel(IElement element, string requiredType = SpecializationType)
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

        public IList<TopNavigationSectionModel> Sections => _element.ChildElements
            .GetElementsOfType(TopNavigationSectionModel.SpecializationTypeId)
            .Select(x => new TopNavigationSectionModel(x))
            .ToList();

        public IList<NavigationLogoModel> Logos => _element.ChildElements
            .GetElementsOfType(NavigationLogoModel.SpecializationTypeId)
            .Select(x => new NavigationLogoModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(TopNavigationModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TopNavigationModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class TopNavigationModelExtensions
    {

        public static bool IsTopNavigationModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == TopNavigationModel.SpecializationTypeId;
        }

        public static TopNavigationModel AsTopNavigationModel(this ICanBeReferencedType type)
        {
            return type.IsTopNavigationModel() ? new TopNavigationModel((IElement)type) : null;
        }
    }
}