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
const intentTypes = {
    binary: { name: "binary", id: "013af2c5-3c32-4752-8f59-db5691050aef" },
    bool: { name: "bool", id: "e6f92b09-b2c5-4536-8270-a4d9e5bbd930" },
    byte: { name: "byte", id: "A4E9102F-C1C8-4902-A417-CA418E1874D2" },
    char: { name: "char", id: "C1B3A361-B1C6-48C3-B34C-7999B3E071F0" },
    date: { name: "date", id: "1fbaa056-b666-4f25-b8fd-76fe3165acc8" },
    datetime: { name: "datetime", id: "a4107c29-7851-4121-9416-cf1236908f1e" },
    datetimeoffset: {
        name: "datetimeoffset",
        id: "f1ba4df3-a5bc-427e-a591-4f6029f89bd7",
    },
    decimal: { name: "decimal", id: "675c7b84-997a-44e0-82b9-cd724c07c9e6" },
    double: { name: "double", id: "24A77F70-5B97-40DD-8F9A-4208AD5F9219" },
    float: { name: "float", id: "341929E9-E3E7-46AA-ACB3-B0438421F4C4" },
    guid: { name: "guid", id: "6b649125-18ea-48fd-a6ba-0bfff0d8f488" },
    int: { name: "int", id: "fb0a362d-e9e2-40de-b6ff-5ce8167cbe74" },
    long: { name: "long", id: "33013006-E404-48C2-AC46-24EF5A5774FD" },
    object: { name: "object", id: "341DD965-D06C-4A40-9437-9516ADA77FF5" },
    short: { name: "short", id: "2ABF0FD3-CD56-4349-8838-D120ED268245" },
    string: { name: "string", id: "d384db9c-a279-45e1-801e-e4e8099625f2" },
};
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
/// <reference path="../../../typings/elementmacro.context.api.d.ts" />
/// <reference path="../../../common/addElement.ts" />
/// <reference path="../../../common/intent-types.ts" />
/// <reference path="../../../common/aryzac-types.ts" />
/// <reference path="../../../common/aryzac-stereotypes.ts" />
if (element.getName().startsWith(":")) {
    addElement(aryzacTypes.routeParameter.name, {
        name: `[${element.getName().split(":")[1]}]`,
        type: { id: intentTypes.string.id },
        nullable: false,
    }, element);
}
