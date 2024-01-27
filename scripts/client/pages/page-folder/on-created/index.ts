/// <reference path="../../../../typings/elementmacro.context.api.d.ts" />
/// <reference path="../../../../common/intent-types.ts" />

function getRouteParameterName(name: string) {  
    return name.substring(1, name.length - 1);
}

if (element.getName().startsWith("[") && element.getName().endsWith("]")) {
    let routeParameter = createElement("Route Parameter", getRouteParameterName(element.getName()), element.id);

    routeParameter.setOrder(0);
    routeParameter.typeReference.setType(intentTypes.string.id);
    routeParameter.typeReference.setIsNullable(false);
}
