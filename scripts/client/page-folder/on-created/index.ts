/// <reference path="../../../typings/elementmacro.context.api.d.ts" />
/// <reference path="../../_common/addElement.ts" />
/// <reference path="../../_common/intent-types.ts" />
/// <reference path="../../_common/aryzac-types.ts" />
/// <reference path="../../_common/aryzac-stereotypes.ts" />

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