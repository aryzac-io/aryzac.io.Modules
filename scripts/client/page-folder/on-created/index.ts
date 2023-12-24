/// <reference path="../../../typings/elementmacro.context.api.d.ts" />
/// <reference path="../../../common/addElement.ts" />
/// <reference path="../../../common/aryzac-types.ts" />
/// <reference path="../../../common/aryzac-stereotypes.ts" />

if (element.getName().startsWith(":")) {
    addElement(
        aryzacTypes.routeParameter.name,
        {
            name: `[${element.getName().split(":")[1]}]`,
            type: { id: intentTypes.string.id },
            nullable: false,
        },
        element
    );
}