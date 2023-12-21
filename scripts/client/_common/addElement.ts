/// <reference path="../../typings/elementmacro.context.api.d.ts" />
function addElement(type: string, definition: any, parent: IElementApi, stereotypes?: any[]) {
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
                    stereotype.properties.forEach((property: any) => {
                        _element
                            .getStereotype(stereotype.id)
                            .getProperty(property.name)
                            .setValue(property.value);
                    });
                }
            }
        }

        return _element;
    } else {
        let _element = null;

        parent.getChildren(type).forEach((e) => {
            if (e.getName() === definition.name) {
                _element = e;
            }
        });

        return _element;
    }
}