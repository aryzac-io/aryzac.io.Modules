/// <reference path="../../../typings/elementmacro.context.api.d.ts" />
lookupTypesOf("Locale").forEach(locale => {
    if (locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("7c3e71c5-7d9d-47eb-b0fc-8473359257bb"); // text-area settings stereotype
        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});
lookupTypesOf("Locale").forEach(locale => {
    if (!locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("7c3e71c5-7d9d-47eb-b0fc-8473359257bb"); // text-area settings stereotype
        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});
