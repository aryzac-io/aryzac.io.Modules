/// <reference path="../../../typings/elementmacro.context.api.d.ts" />

lookupTypesOf("Locale").forEach(locale => {
    if (locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("3fc958c7-8c35-42f6-8f40-388ad0494fbb"); // heading settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});

lookupTypesOf("Locale").forEach(locale => {
    if (!locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("3fc958c7-8c35-42f6-8f40-388ad0494fbb"); // heading settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});