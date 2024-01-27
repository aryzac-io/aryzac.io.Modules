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
/// <reference path="../../../../typings/elementmacro.context.api.d.ts" />
/// <reference path="../../../../common/intent-types.ts" />
function getRouteParameterName(name) {
    return name.substring(1, name.length - 1);
}
var existingRouteParameters = element.getChildren("Route Parameter");
existingRouteParameters.forEach(routeParameter => {
    routeParameter.delete();
});
if (element.getName().startsWith("[") && element.getName().endsWith("]")) {
    let routeParameter = createElement("Route Parameter", getRouteParameterName(element.getName()), element.id);
    routeParameter.setOrder(0);
    routeParameter.typeReference.setType(intentTypes.string.id);
    routeParameter.typeReference.setIsNullable(false);
}
