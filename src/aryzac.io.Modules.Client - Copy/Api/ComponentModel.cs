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
    public class ComponentModel : IMetadataModel, IHasStereotypes, IHasName, IElementWrapper
    {
        public const string SpecializationType = "Component";
        public const string SpecializationTypeId = "854137dd-0e21-4076-adb9-404c4b1a782e";
        protected readonly IElement _element;

        [IntentManaged(Mode.Fully)]
        public ComponentModel(IElement element, string requiredType = SpecializationType)
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

        public IList<ComponentParameterModel> Parameters => _element.ChildElements
            .GetElementsOfType(ComponentParameterModel.SpecializationTypeId)
            .Select(x => new ComponentParameterModel(x))
            .ToList();

        public ComponentQueryModel Query => _element.ChildElements
            .GetElementsOfType(ComponentQueryModel.SpecializationTypeId)
            .Select(x => new ComponentQueryModel(x))
            .SingleOrDefault();

        public ComponentCommandModel Command => _element.ChildElements
            .GetElementsOfType(ComponentCommandModel.SpecializationTypeId)
            .Select(x => new ComponentCommandModel(x))
            .SingleOrDefault();

        public ComponentModelModel Model => _element.ChildElements
            .GetElementsOfType(ComponentModelModel.SpecializationTypeId)
            .Select(x => new ComponentModelModel(x))
            .SingleOrDefault();

        public ComponentViewModel View => _element.ChildElements
            .GetElementsOfType(ComponentViewModel.SpecializationTypeId)
            .Select(x => new ComponentViewModel(x))
            .SingleOrDefault();

        public override string ToString()
        {
            return _element.ToString();
        }

        public bool Equals(ComponentModel other)
        {
            return Equals(_element, other?._element);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComponentModel)obj);
        }

        public override int GetHashCode()
        {
            return (_element != null ? _element.GetHashCode() : 0);
        }
    }

    [IntentManaged(Mode.Merge)]
    public static class ComponentModelExtensions
    {

        public static bool IsComponentModel(this ICanBeReferencedType type)
        {
            return type != null && type is IElement element && element.SpecializationTypeId == ComponentModel.SpecializationTypeId;
        }

        public static ComponentModel AsComponentModel(this ICanBeReferencedType type)
        {
            return type.IsComponentModel() ? new ComponentModel((IElement)type) : null;
        }

        public static string GetPath(this ComponentModel component)
        {
            var path = "/";
            var currentNode = component.InternalElement.ParentElement;

            while (currentNode != null)
            {
                if (currentNode.SpecializationTypeId == ComponentsModel.SpecializationTypeId)
                {
                    break;
                }

                path += $"/{currentNode.Name}";

                currentNode = currentNode.ParentElement;
            }

            return path.Replace("//", "/");
        }

        public static string GetComponentName(this ComponentModel component)
        {
            var path = "";
            var currentNode = component.InternalElement;

            while (currentNode != null)
            {
                if (currentNode.SpecializationTypeId == ComponentsModel.SpecializationTypeId)
                {
                    break;
                }

                if (currentNode.Name.ToLower() != "index")
                {
                    path += $"-{currentNode.Name}";
                }

                currentNode = currentNode.ParentElement;
            }

            return path;
        }
    }
}