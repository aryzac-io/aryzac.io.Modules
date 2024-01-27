/// <reference path="../../typings/elementmacro.context.api.d.ts" />
/// <reference path="../../common/logger.ts" />
/// <reference path="../../common/addElement.ts" />
/// <reference path="../../common/aryzac-types.ts" />
/// <reference path="../../common/aryzac-stereotypes.ts" />

logger.info("Finding Breadcrumb Page");

const routeParameters = [];

let currentNode = element.typeReference.getType();

while (currentNode) {
    logger.debug(`Current Page ${currentNode.id} - ${currentNode.getName()}`);
    logger.trace(`Current Page ${JSON.stringify(currentNode)}`);

    const currentNodeChildren = currentNode.getChildren();
    logger.trace(`Current Page Children ${JSON.stringify(currentNodeChildren)}`);

    const currentNodeRouteParameter = currentNodeChildren.filter(m => m.specialization === aryzacTypes.routeParameter.name);

    if (currentNodeRouteParameter.length > 0) {
        logger.info(`Has Route Parameter ${JSON.stringify(currentNodeRouteParameter[0])}`);

        routeParameters.push(currentNodeRouteParameter[0]);
    }

    currentNode = currentNode.getParent();
    logger.trace(`Current Page Parent ${JSON.stringify(currentNode)}`);

    if (currentNode.specializationId === aryzacTypes.pages.id) {
        logger.info(`Reached Pages folder`);
        break;
    }
}

for (let i = 0; i < routeParameters.length; i++) {
    addElement(
        aryzacTypes.routeParameter.name,
        {
            name: routeParameters[i].getName(),
            type: routeParameters[i].typeReference.getType(),
            nullable: routeParameters[i].typeReference.getIsNullable()
        },
        element);
}