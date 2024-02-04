export const useListClientsViewClientsOptions = async (
 
) => {

const { t } = useI18n();





const title = computed(() => {
  return t('heading-viewClients.title');
});











return {
  title,
};

}