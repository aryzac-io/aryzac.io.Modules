using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiPackageModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Api
{
    [IntentManaged(Mode.Fully)]
    public class ClientModel : IHasStereotypes, IMetadataModel
    {
        public const string SpecializationType = "Client";
        public const string SpecializationTypeId = "8a67e242-ece1-4095-91ce-4b1bbd3036b2";

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

    }
}