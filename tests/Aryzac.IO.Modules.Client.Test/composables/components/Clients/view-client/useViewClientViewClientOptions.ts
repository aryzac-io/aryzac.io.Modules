import type { ViewClientProps } from "~/structs/components/clients/view-client.props";
import type { ViewClientModel } from '~/structs/components/clients/view-client.model';





export const useViewClientViewClientOptions = async (
props: ViewClientProps, model: ViewClientModel 
) => {

const { t } = useI18n();





const title = computed(() => {
  return t('viewClient.title');
});











return {
  title,
};

}
