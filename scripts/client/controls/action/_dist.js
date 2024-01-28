/// <reference path="../../../typings/elementmacro.context.api.d.ts" />
lookupTypesOf("Locale").forEach(locale => {
    if (locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("ea0f9d89-8d52-4d58-b4d2-9095a9bf5606"); // action settings stereotype
        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});
lookupTypesOf("Locale").forEach(locale => {
    if (!locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("ea0f9d89-8d52-4d58-b4d2-9095a9bf5606"); // action settings stereotype
        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});
