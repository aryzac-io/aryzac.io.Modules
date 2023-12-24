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
    public class FooterModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Footer";
        public const string SpecializationTypeId = "bda9700d-2ff6-46f3-a6a6-fdccb055b95e";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public FooterModel(IElement element, string requiredType = SpecializationType)
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

        public IList<StyleModel> Styles => _element.ChildElements
            .GetElementsOfType(StyleModel.SpecializationTypeId)
            .Select(x => new StyleModel(x))
            .ToList();

        public IList<NavigationSectionModel> Sections => _element.ChildElements
            .GetElementsOfType(NavigationSectionModel.SpecializationTypeId)
            .Select(x => new NavigationSectionModel(x))
            .ToList();

        public IList<LogoModel> Logos => _element.ChildElements
            .GetElementsOfType(LogoModel.SpecializationTypeId)
            .Select(x => new LogoModel(x))
            .ToList();

        public IList<NavigationItemModel> Items => _element.ChildElements
            .GetElementsOfType(NavigationItemModel.SpecializationTypeId)
            .Select(x => new NavigationItemModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(FooterModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FooterModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class FooterModelExtensions
    {

        public static bool IsFooterModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == FooterModel.SpecializationTypeId;
        }

        public static FooterModel AsFooterModel(this ICanBeReferencedType type)
        {
            return type.IsFooterModel() ? new FooterModel((IElement)type) : null;
        }
    }
}