import type { ViewClientProps } from '~/structs/components/clients/view-client.props';
import type { ViewClientModel } from '~/structs/components/clients/view-client.model';





export const useViewClientFirstNameOptions = async (
props: ViewClientProps, model: ViewClientModel 
) => {

const { t } = useI18n();

const label = computed(() => {
  const firstName = model.firstName || '';
  const mappedExpression = `${firstName}`;
  return mappedExpression;
});

return {
  label
};

}