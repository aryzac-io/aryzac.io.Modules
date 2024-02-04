using System;
using System.Collections.Generic;
using System.Linq;
using Intent.Metadata.Models;
using Intent.Modelers.WebClient.Api;
using Intent.Modules.Common;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.ModuleBuilder.Templates.Api.ApiPackageExtensionModel", Version = "1.0")]

namespace Aryzac.IO.Modules.Client.Api
{
    [IntentManaged(Mode.Merge)]
    public class PackageExtensionModel : WebClientModel
    {
        [IntentManaged(Mode.Ignore)]
        public PackageExtensionModel(IPackage package) : base(package)
        {
        }

        [IntentManaged(Mode.Fully)]
        public LocalesModel Locales => UnderlyingPackage.ChildElements
            .GetElementsOfType(LocalesModel.SpecializationTypeId)
            .Select(x => new LocalesModel(x))
            .SingleOrDefault();

        [IntentManaged(Mode.Fully)]
        public LayoutsModel Layouts => UnderlyingPackage.ChildElements
            .GetElementsOfType(LayoutsModel.SpecializationTypeId)
            .Select(x => new LayoutsModel(x))
            .SingleOrDefault();

        [IntentManaged(Mode.Fully)]
        public PagesModel Pages => UnderlyingPackage.ChildElements
            .GetElementsOfType(PagesModel.SpecializationTypeId)
            .Select(x => new PagesModel(x))
            .SingleOrDefault();

        [IntentManaged(Mode.Fully)]
        public ComponentsModel Components => UnderlyingPackage.ChildElements
            .GetElementsOfType(ComponentsModel.SpecializationTypeId)
            .Select(x => new ComponentsModel(x))
            .SingleOrDefault();

        [IntentManaged(Mode.Fully)]
        public ServiceProxiesModel ServiceProxies => UnderlyingPackage.ChildElements
            .GetElementsOfType(ServiceProxiesModel.SpecializationTypeId)
            .Select(x => new ServiceProxiesModel(x))
            .SingleOrDefault();

    }
}