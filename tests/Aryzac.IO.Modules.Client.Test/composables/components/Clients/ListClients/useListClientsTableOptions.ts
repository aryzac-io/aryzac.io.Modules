import type { ComposerTranslation } from "@nuxtjs/i18n/dist/runtime/composables";

import type { ClientDto } from '~/structs/dto/clients/client.dto';


export const useListClientsTableOptions = (t: ComposerTranslation) => {


const clientsServiceProxy = useClientsServiceProxy();



// Commands

	
const deleteClientCommand = async (id: string) => {



	const deleteClientCommand = await clientsServiceProxy.deleteClientCommand(id);
};



const headers = [
  {
    key: 'clientName',
    label: t("table.clientName"),
    data: (item: ClientDto) => {
      const lastName = item.lastName || '';
      const firstName = item.firstName || '';
      const otherNames = item.otherNames || '';
      const mappedExpression = `${lastName}, ${firstName} ${otherNames}`;
      return mappedExpression;
    }
  },
];


const actions = [
  {
    label: t("table.actions.view.label"),
    icon: t("table.actions.view.icon"),
action: async (item: ClientDto) => {
      const localeRoute = useLocaleRoute();
      await navigateTo(localeRoute(`/Clients/${item.id}`));
    },
  },
  {
    label: t("table.actions.edit.label"),
    icon: t("table.actions.edit.icon"),
action: async (item: ClientDto) => {
      const localeRoute = useLocaleRoute();
      await navigateTo(localeRoute(`/Clients/${item.id}/edit`));
    },
  },
  {
    label: t("table.actions.delete.label"),
    icon: t("table.actions.delete.icon"),
action: async (item: ClientDto) => {
      await deleteClientCommand(item.id);
    },
  },
];


}
