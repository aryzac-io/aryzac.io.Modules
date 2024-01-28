/// <reference path="../../../typings/elementmacro.context.api.d.ts" />
lookupTypesOf("Locale").forEach(locale => {
    if (locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("aff6bbb9-c26b-4a01-b8d3-d7ccc5f61da8"); // heading attribute settings stereotype
        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});
lookupTypesOf("Locale").forEach(locale => {
    if (!locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("aff6bbb9-c26b-4a01-b8d3-d7ccc5f61da8"); // heading attribute settings stereotype
        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});
