import type { ClientDto } from '~/structs/dto/clients/client.dto';




export const useListClientsClientsTableOptions = async (
 
) => {

const { t } = useI18n();


const clientsServiceProxy = useClientsServiceProxy();



// Queries
const { 
  data,
  pending,
  error,
  execute,
  refresh,
  status
} = await clientsServiceProxy.getClientsQuery();






const headers = [
  {
    key: 'firstName',
    label: t("clientsTable.firstName"),
    data: (item: ClientDto) => {

        if (!pending.value) {
                const firstName = item.firstName || '';
      const mappedExpression = `${firstName}`;
      return mappedExpression;
        } else {
          return '';
        }
    }
  },
  {
    key: 'lastName',
    label: t("clientsTable.lastName"),
    data: (item: ClientDto) => {

        if (!pending.value) {
                const lastName = item.lastName || '';
      const mappedExpression = `${lastName}`;
      return mappedExpression;
        } else {
          return '';
        }
    }
  },
  {
    key: 'otherNames',
    label: t("clientsTable.otherNames"),
    data: (item: ClientDto) => {

        if (!pending.value) {
                const otherNames = item.otherNames || '';
      const mappedExpression = `${otherNames}`;
      return mappedExpression;
        } else {
          return '';
        }
    }
  },
];



const actions = [
  {
    label: t("clientsTable.actions.view.label"),
    icon: t("clientsTable.actions.view.icon"),
action: async (item: ClientDto) => {
      const localeRoute = useLocaleRoute();
      await navigateTo(localeRoute(`/Clients/${item.id}`));
    },
  },
];


return {
	headers,
	actions,
	data,
	pending,
	error,
	execute,
	refresh,
	status,
};
}
