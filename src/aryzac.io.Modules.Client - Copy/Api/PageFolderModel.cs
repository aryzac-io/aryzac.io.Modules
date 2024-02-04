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
    public class PageFolderModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Page Folder";
        public const string SpecializationTypeId = "21b29545-9bd7-4cbd-85bb-3b548765031e";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public PageFolderModel(IElement element, string requiredType = SpecializationType)
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

        public IList<PageModel> Pages => _element.ChildElements
            .GetElementsOfType(PageModel.SpecializationTypeId)
            .Select(x => new PageModel(x))
            .ToList();

        public IList<PageFolderModel> Folders => _element.ChildElements
            .GetElementsOfType(PageFolderModel.SpecializationTypeId)
            .Select(x => new PageFolderModel(x))
            .ToList();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(PageFolderModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PageFolderModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Fully)]
    public static class PageFolderModelExtensions
    {

        public static bool IsPageFolderModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == PageFolderModel.SpecializationTypeId;
        }

        public static PageFolderModel AsPageFolderModel(this ICanBeReferencedType type)
        {
            return type.IsPageFolderModel() ? new PageFolderModel((IElement)type) : null;
        }
    }
}