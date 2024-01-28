/// <reference path="../../../typings/elementmacro.context.api.d.ts" />

lookupTypesOf("Locale").forEach(locale => {
    if (locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("76a05306-e432-445c-a3ef-1bc5b4869a7d"); // textbox settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});

lookupTypesOf("Locale").forEach(locale => {
    if (!locale.hasStereotype("09876e82-e2d2-440a-9f22-2cb2d958d89d")) {
        let settingsStereotype = element.addStereotype("76a05306-e432-445c-a3ef-1bc5b4869a7d"); // textbox settings stereotype

        settingsStereotype
            .getProperty("Locale")
            .setValue(locale.id);
    }
});