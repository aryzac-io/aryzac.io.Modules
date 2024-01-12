using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.TypeResolution;
using Intent.Modules.Common.Types.Api;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiElementModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Api
{
    [IntentManaged(Mode.Fully, Signature = Mode.Fully)]
    public class PageModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper, IHasTypeReference
    {
        public const string SpecializationType = "Page";
        public const string SpecializationTypeId = "89cf68f6-6f29-412a-bae2-31faed8280d9";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public PageModel(IElement element, string requiredType = SpecializationType)
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

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(PageModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PageModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Merge)]
    public static class PageModelExtensions
    {

        public static bool IsPageModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == PageModel.SpecializationTypeId;
        }

        public static PageModel AsPageModel(this ICanBeReferencedType type)
        {
            return type.IsPageModel() ? new PageModel((IElement)type) : null;
        }

        public static string GetPath(this PageModel page)
        {
            var path = "/";
            var currentNode = page.InternalElement;

            while (currentNode != null)
            {
                if (currentNode.SpecializationTypeId == PagesModel.SpecializationTypeId)
                {
                    break;
                }

                if (currentNode.Name.ToLower() != "index")
                {
                    path += $"/{currentNode.Name}";
                }

                currentNode = currentNode.ParentElement;
            }

            return path.Replace("//", "/");
        }
    }
}