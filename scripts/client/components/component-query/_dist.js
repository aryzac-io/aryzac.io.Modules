/// <reference path="../../../typings/elementmacro.context.api.d.ts" />
function GetParameters(targetService) {
    let httpSettings = targetService.getStereotype("Http Settings");
    var isForCqrs = targetService.specialization == "Query" || targetService.specialization == "Command";
    var verbAllowsBody = ["PUT", "PATCH", "POST"].some(x => x == httpSettings.getProperty("Verb").getValue());
    var requiresBody = false;
    let result = [];
    targetService.getChildren("Parameter").concat(targetService.getChildren("DTO-Field")).forEach(childElement => {
        var parameterSettings = childElement.getStereotype("d01df110-1208-4af8-a913-92a49d219552"); // "Paremeter Settings"
        var routeContainsParameter = httpSettings.getProperty("Route").getValue().toString().toLowerCase().indexOf(`{${childElement.getName().toLowerCase()}}`) != -1;
        if (isForCqrs && !parameterSettings && !routeContainsParameter && verbAllowsBody) {
            requiresBody = true;
            return;
        }
        result.push({
            id: childElement.id,
            name: toCamelCase(childElement.getName()),
            typeId: childElement.typeReference.getTypeId(),
            isNullable: childElement.typeReference.getIsNullable(),
            isCollection: childElement.typeReference.getIsCollection(),
        });
    });
    if (isForCqrs && requiresBody) {
        result.push({
            id: targetService.id,
            name: targetService.specialization.toLowerCase(),
            typeId: targetService.id,
            isNullable: false,
            isCollection: false,
        });
    }
    return result;
}
function execute(command) {
    let targetOperation = command.getMapping().getElement();
    let targetService = targetOperation.getMapping().getElement();
    let params = GetParameters(targetService);
    params.forEach((param, index) => {
        let existing = command.getChildren("Parameter").find(x => x.getMetadata("endpoint-input-id") == param.id);
        if (!existing) {
            existing = createElement("Parameter", param.name, command.id);
        }
        existing.setName(param.name);
        existing.setOrder(index);
        existing.typeReference.setType(param.typeId);
        existing.typeReference.setIsCollection(param.isCollection);
        existing.typeReference.setIsNullable(param.isNullable);
        existing.setMetadata("endpoint-input-id", param.id);
    });
    command.getChildren("Parameter")
        .filter(x => params.every(p => p.id != x.getMetadata("endpoint-input-id")));
    if (targetOperation.typeReference) {
        let responseType = createElement("Parameter", "response-type", command.id);
        responseType.setName("response-type");
        responseType.setOrder(params.length);
        responseType.typeReference.setType(targetOperation.typeReference.getTypeId());
        // responseType.typeReference.setIsCollection(targetOperation.typeReference.getIsCollection());
        responseType.typeReference.setIsNullable(targetOperation.typeReference.getIsNullable());
        responseType.setMetadata("response-type", responseType.id);
    }
}
execute(element);
