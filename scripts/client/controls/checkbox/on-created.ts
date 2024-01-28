/// <reference path="../../../typings/elementmacro.context.api.d.ts" />

lookupTypesOf("Locale").forEach(locale => {
    if (locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("1fafd144-4893-4a55-835a-487ad4b41bfe"); // checkbox settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});

lookupTypesOf("Locale").forEach(locale => {
    if (!locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("1fafd144-4893-4a55-835a-487ad4b41bfe"); // checkbox settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});