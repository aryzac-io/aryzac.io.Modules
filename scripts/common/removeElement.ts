/// <reference path="../../typings/elementmacro.context.api.d.ts" />
function removeElement(type: string, name: string, parent: IElementApi) {
    var children = parent.getChildren(type);

    if (children) {
        children.forEach((element) => {
            if (element.getName() === name) {
                element.delete();
            }
        });
    }
}