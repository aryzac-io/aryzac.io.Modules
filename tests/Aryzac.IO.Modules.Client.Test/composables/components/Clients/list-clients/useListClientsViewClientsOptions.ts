export const useListClientsViewClientsOptions = async () => {
  const { t } = useI18n();

  const title = computed(() => {
    return t("viewClients.title");
  });

  return {
    title,
  };
};
