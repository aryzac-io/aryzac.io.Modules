import type { ViewClientProps } from '~/structs/components/clients/view-client.props';
import type { ViewClientModel } from '~/structs/components/clients/view-client.model';





export const useViewClientReceivePromotionsOptions = async (
props: ViewClientProps, model: ViewClientModel 
) => {

const { t } = useI18n();

const label = computed(() => {
  const receivePromotions = model.receivePromotions || '';
  const mappedExpression = `${receivePromotions}`;
  return mappedExpression;
});

return {
  label
};

}