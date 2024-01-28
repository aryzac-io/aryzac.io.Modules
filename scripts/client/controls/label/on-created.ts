/// <reference path="../../../typings/elementmacro.context.api.d.ts" />

lookupTypesOf("Locale").forEach(locale => {
    if (locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("ea62dc6f-ed7c-46c5-bcd9-c717d616f590"); // label settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});

lookupTypesOf("Locale").forEach(locale => {
    if (!locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("ea62dc6f-ed7c-46c5-bcd9-c717d616f590"); // label settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});