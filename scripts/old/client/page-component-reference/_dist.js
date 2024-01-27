var LogLevel;
(function (LogLevel) {
    LogLevel[LogLevel["Error"] = 0] = "Error";
    LogLevel[LogLevel["Warn"] = 1] = "Warn";
    LogLevel[LogLevel["Info"] = 2] = "Info";
    LogLevel[LogLevel["Debug"] = 3] = "Debug";
    LogLevel[LogLevel["Trace"] = 4] = "Trace";
})(LogLevel || (LogLevel = {}));
const logLevel = LogLevel.Trace;
const logger = {
    error: (message) => {
        if (logLevel >= LogLevel.Error) {
            console.error(`${new Date()} ERROR: ${message}`);
        }
    },
    warn: (message) => {
        if (logLevel >= LogLevel.Warn) {
            console.warn(`${new Date()} WARN: ${message}`);
        }
    },
    info: (message) => {
        if (logLevel >= LogLevel.Info) {
            console.log(`${new Date()} INFO: ${message}`);
        }
    },
    debug: (message) => {
        if (logLevel >= LogLevel.Debug) {
            console.log(`${new Date()} DEBUG: ${message}`);
        }
    },
    trace: (message) => {
        if (logLevel >= LogLevel.Trace) {
            console.log(`${new Date()} TRACE: ${message}`);
        }
    }
};
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
/// <reference path="../../common/logger.ts" />
/// <reference path="../../common/addElement.ts" />
/// <reference path="../../common/aryzac-types.ts" />
/// <reference path="../../common/aryzac-stereotypes.ts" />
logger.info("Finding Component Page");
const routeParameters = [];
let currentNode = element;
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
    addElement(aryzacTypes.routeParameter.name, {
        name: routeParameters[i].getName(),
        type: routeParameters[i].typeReference.getType(),
        nullable: routeParameters[i].typeReference.getIsNullable()
    }, element);
}
