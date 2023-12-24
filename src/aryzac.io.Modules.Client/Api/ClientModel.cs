using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.Modules.Common.Types.Api;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiPackageModel", Version = "1.0")]

namespace Aryzac.Io.Modules.Client.Api
{
    [IntentManaged(Mode.Fully)]
    public class ClientModel : IHasStereotypes, IMetadataModel
    {
        public const string SpecializationType = "Client";
        public const string SpecializationTypeId = "f96c5215-e609-4066-8e9e-95d86e199e1f";

        [IntentManaged(Mode.Ignore)]
        public ClientModel(IPackage package)
        {
            if (!SpecializationType.Equals(package.SpecializationType, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception($"Cannot create a '{GetType().Name}' from package with specialization type '{package.SpecializationType}'. Must be of type '{SpecializationType}'");
            }

            UnderlyingPackage = package;
        }

        public IPackage UnderlyingPackage { get; }
        public string Id => UnderlyingPackage.Id;
        public string Name => UnderlyingPackage.Name;
        public IEnumerable<IStereotype> Stereotypes => UnderlyingPackage.Stereotypes;
        public string FileLocation => UnderlyingPackage.FileLocation;

        public LayoutsModel Layouts => UnderlyingPackage.ChildElements
            .GetElementsOfType(LayoutsModel.SpecializationTypeId)
            .Select(x => new LayoutsModel(x))
            .SingleOrDefault();

        public PagesModel Pages => UnderlyingPackage.ChildElements
            .GetElementsOfType(PagesModel.SpecializationTypeId)
            .Select(x => new PagesModel(x))
            .SingleOrDefault();

        public ComponentsModel Components => UnderlyingPackage.ChildElements
            .GetElementsOfType(ComponentsModel.SpecializationTypeId)
            .Select(x => new ComponentsModel(x))
            .SingleOrDefault();

        public CommandsModel Commands => UnderlyingPackage.ChildElements
            .GetElementsOfType(CommandsModel.SpecializationTypeId)
            .Select(x => new CommandsModel(x))
            .SingleOrDefault();

        public ServiceProxiesModel ServiceProxies => UnderlyingPackage.ChildElements
            .GetElementsOfType(ServiceProxiesModel.SpecializationTypeId)
            .Select(x => new ServiceProxiesModel(x))
            .SingleOrDefault();

        public IList<FolderModel> Folders => UnderlyingPackage.ChildElements
            .GetElementsOfType(FolderModel.SpecializationTypeId)
            .Select(x => new FolderModel(x))
            .ToList();

        public IList<EnumModel> Enums => UnderlyingPackage.ChildElements
            .GetElementsOfType(EnumModel.SpecializationTypeId)
            .Select(x => new EnumModel(x))
            .ToList();

        public IList<TypeDefinitionModel> Types => UnderlyingPackage.ChildElements
            .GetElementsOfType(TypeDefinitionModel.SpecializationTypeId)
            .Select(x => new TypeDefinitionModel(x))
            .ToList();

        public StylesModel Styles => UnderlyingPackage.ChildElements
            .GetElementsOfType(StylesModel.SpecializationTypeId)
            .Select(x => new StylesModel(x))
            .SingleOrDefault();

        public ControlsModel Controls => UnderlyingPackage.ChildElements
            .GetElementsOfType(ControlsModel.SpecializationTypeId)
            .Select(x => new ControlsModel(x))
            .SingleOrDefault();

    }
}