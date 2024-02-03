import type { ClientDto } from "~/structs/dto/clients/client.dto";

export const useListClientsClientsTableOptions = async () => {
  const { t } = useI18n();

  const clientsServiceProxy = useClientsServiceProxy();

  // Queries
  const { data, pending, error, execute, refresh, status } =
    await clientsServiceProxy.getClientsQuery();

  const headers = [
    {
      key: "firstName",
      label: t("clientsTable.firstName"),
      data: (item: ClientDto) => {
        const firstName = item.firstName || "";
        const mappedExpression = `${firstName}`;
        return mappedExpression;
      },
    },
    {
      key: "lastName",
      label: t("clientsTable.lastName"),
      data: (item: ClientDto) => {
        const lastName = item.lastName || "";
        const mappedExpression = `${lastName}`;
        return mappedExpression;
      },
    },
    {
      key: "otherNames",
      label: t("clientsTable.otherNames"),
      data: (item: ClientDto) => {
        const otherNames = item.otherNames || "";
        const mappedExpression = `${otherNames}`;
        return mappedExpression;
      },
    },
  ];

  return {
    headers,
    data,
    pending,
    error,
    execute,
    refresh,
    status,
  };
};
