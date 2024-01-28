/// <reference path="../../../typings/elementmacro.context.api.d.ts" />
lookupTypesOf("Locale").forEach(locale => {
    if (locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("d159f0b9-8d24-40b6-900f-6af71a512072"); // select settings stereotype
        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});
lookupTypesOf("Locale").forEach(locale => {
    if (!locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("d159f0b9-8d24-40b6-900f-6af71a512072"); // select settings stereotype
        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});
