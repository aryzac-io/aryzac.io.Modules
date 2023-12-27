/// <reference path="../typings/elementmacro.context.api.d.ts" />
function addElement(type, definition, parent, stereotypes) {
    if (parent.getChildren(type).every((x) => x.getName() !== definition.name)) {
        const _element = createElement(type, definition.name, parent.id);
        if (definition.type) {
            _element.typeReference.setType(definition.type.id);
            _element.typeReference.setIsNullable(definition.nullable);
        }
        if (stereotypes) {
            for (let s = 0; s < stereotypes.length; s++) {
                const stereotype = stereotypes[s].stereotype;
                if (!_element.hasStereotype(stereotype.id)) {
                    _element.addStereotype(stereotype.id);
                }
                if (stereotype.properties) {
                    stereotype.properties.forEach((property) => {
                        _element
                            .getStereotype(stereotype.id)
                            .getProperty(property.name)
                            .setValue(property.value);
                    });
                }
            }
        }
        return _element;
    }
    else {
        let _element = null;
        parent.getChildren(type).forEach((e) => {
            if (e.getName() === definition.name) {
                _element = e;
            }
        });
        return _element;
    }
}
/// <reference path="../typings/elementmacro.context.api.d.ts" />
const aryzacTypes = {
    routeParameter: { name: "Route Parameter", id: "b1e06380-f8fe-42f8-bea1-820bbe5fee92" },
    inheritedNavigation: { name: "Inherited Navigation", id: "9974d562-885d-46d7-817e-0f663fe07e88" },
    layout: { name: "Layout", id: "eb6cb3df-6d5a-469b-8919-ab659187874f" },
    layoutNavigation: { name: 'Layout Navigation', id: '504052da-efcd-4f9d-8177-ba6a2c7bfa79' },
    layoutSlot: { name: 'Layout Slot', id: 'd5e91bdc-bc8d-4dd7-9fa7-5d537a478866' },
    pages: { name: 'Pages', id: '4e3cc9bd-3900-4cd7-918b-ba7d11972da4' },
    breakpoints: { name: 'Breakpoints', id: 'd001da3a-4e21-4a7b-930c-defe16bf8091' },
    breakpoint: { name: 'Breakpoint', id: '054ff75d-9014-4505-ba45-5fee23653139' },
    themeColor: { name: 'Theme Color', id: '4f68aa50-d3c0-40af-842c-f1302c7cf805' }
};
/// <reference path="../typings/elementmacro.context.api.d.ts" />
const aryzacStereotypes = {
    footerNavigationSettings: { name: "Footer Navigation Settings", id: "a4934d2c-7817-413d-af69-57b87289e2fd" },
    sidebarNavigationSettings: { name: "Sidebar Navigation Settings", id: "d2871749-82c8-467d-8a70-2d0bea7cd3e2" },
    topNavigationSettings: { name: "Top Navigation Settings", id: "e31690e9-e123-4c7f-aad5-576bbde51d08" }
};
/// <reference path="../../typings/elementmacro.context.api.d.ts" />
/// <reference path="../../common/addElement.ts" />
/// <reference path="../../common/aryzac-types.ts" />
/// <reference path="../../common/aryzac-stereotypes.ts" />
addElement(aryzacTypes.inheritedNavigation.name, {
    name: "[inherited]"
}, element);
