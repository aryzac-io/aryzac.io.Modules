/// <reference path="../../../typings/elementmacro.context.api.d.ts" />

lookupTypesOf("Locale").forEach(locale => {
    if (locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("5b660009-8997-4ec3-9b41-0fcded5e97b5"); // section settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});

lookupTypesOf("Locale").forEach(locale => {
    if (!locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("5b660009-8997-4ec3-9b41-0fcded5e97b5"); // section settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});