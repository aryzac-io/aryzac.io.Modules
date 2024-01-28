/// <reference path="../../../typings/elementmacro.context.api.d.ts" />

lookupTypesOf("Locale").forEach(locale => {
    if (locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("d4e49575-65a5-472a-8c4b-a4fb12c162bc"); // navigation item settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});

lookupTypesOf("Locale").forEach(locale => {
    if (!locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("d4e49575-65a5-472a-8c4b-a4fb12c162bc"); // navigation item settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});