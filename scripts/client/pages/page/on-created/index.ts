/// <reference path="../../../../typings/elementmacro.context.api.d.ts" />

const routeParameters: IElementApi[] = [];

let currentNode = element;

while (currentNode) {
    const currentNodeChildren = currentNode.getChildren();
    const currentNodeRouteParameter = currentNodeChildren.filter(m => m.specialization === "Route Parameter");

    if (currentNodeRouteParameter.length > 0) {
        routeParameters.push(currentNodeRouteParameter[0]);
    }

    currentNode = currentNode.getParent();

    if (currentNode.specialization === "Pages") {
        break;
    }
}

const reversedRouteParameters = routeParameters.reverse();

for (let i = 0; i < reversedRouteParameters.length; i++) {
    let parameter = createElement("Parameter", reversedRouteParameters[i].getName(), element.id);
    
    parameter.setOrder(i);
    parameter.typeReference.setType(reversedRouteParameters[i].typeReference.getType().id);
    parameter.typeReference.setIsNullable(reversedRouteParameters[i].typeReference.getIsNullable());
}