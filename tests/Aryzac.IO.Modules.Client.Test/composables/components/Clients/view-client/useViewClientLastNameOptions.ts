import type { ViewClientProps } from '~/structs/components/clients/view-client.props';
import type { ViewClientModel } from '~/structs/components/clients/view-client.model';





export const useViewClientLastNameOptions = async (
props: ViewClientProps, model: ViewClientModel 
) => {

const { t } = useI18n();

const label = computed(() => {
  const lastName = model.lastName || '';
  const mappedExpression = `${lastName}`;
  return mappedExpression;
});

return {
  label
};

}