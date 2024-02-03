import type { ComposerTranslation } from "@nuxtjs/i18n/dist/runtime/composables";

import type { EditClientProps } from "~/structs/components/clients/edit-client.props";
import type { EditClientModel } from "~/structs/components/clients/edit-client.model";

import type { ChangeNameClientCommand } from "~/structs/dto/clients/change-name-client-command.dto";

export const useEditClientHeadingOptions = async (
  props: EditClientProps,
  model: EditClientModel,
  t: ComposerTranslation
) => {
  const clientsServiceProxy = useClientsServiceProxy();

  // Commands
  const changeNameClientCommand = async (id: string) => {
    const command: ChangeNameClientCommand = {
      id: model.id,
      firstName: model.firstName,
      lastName: model.lastName,
      otherNames: model.otherNames,
    };

    const changeNameClientCommand =
      await clientsServiceProxy.changeNameClientCommand(id, command);
  };

  const actions = [
    {
      label: t("heading.actions.view.label"),
      action: async () => {
        const localeRoute = useLocaleRoute();
        await navigateTo(localeRoute(`/Clients/${props.clientId}`));
      },
    },
    {
      label: t("heading.actions.save.label"),
      action: async () => {
        await changeNameClientCommand(props.clientId);
      },
    },
  ];

  return {
    actions,
    changeNameClientCommand,
  };
};
