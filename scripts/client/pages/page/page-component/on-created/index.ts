/// <reference path="../../../../../typings/elementmacro.context.api.d.ts" />

if (element.typeReference) {
    let parameters = element.typeReference.getType().getChildren("Component Parameter");

    parameters.forEach(parameter => {
        let componentParameter = createElement("Parameter", parameter.getName(), element.id);

        componentParameter.typeReference.setType(parameter.typeReference.getType().id);
        componentParameter.typeReference.setIsNullable(parameter.typeReference.getIsNullable());
    });
}