/// <reference path="../../typings/elementmacro.context.api.d.ts" />
/// <reference path="../_common/addElement.ts" />
/// <reference path="../_common/aryzac-types.ts" />
/// <reference path="../_common/aryzac-stereotypes.ts" />

addElement(
    aryzacTypes.layoutNavigation.name,
    {
        name: "Top Navigation"
    },
    element,
    [
        {
            stereotype: aryzacStereotypes.topNavigationSettings
        }
    ]
);

addElement(
    aryzacTypes.layoutNavigation.name,
    {
        name: "Sidebar Navigation"
    },
    element,
    [
        {
            stereotype: aryzacStereotypes.sidebarNavigationSettings
        }
    ]
);

addElement(
    aryzacTypes.layoutNavigation.name,
    {
        name: "Footer"
    },
    element,
    [
        {
            stereotype: aryzacStereotypes.footerNavigationSettings
        }
    ]
);

addElement(
    aryzacTypes.layoutSlot.name,
    {
        name: "Main"
    },
    element
);