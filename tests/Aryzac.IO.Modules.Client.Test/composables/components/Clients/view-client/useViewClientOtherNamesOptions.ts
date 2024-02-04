import type { ViewClientProps } from '~/structs/components/clients/view-client.props';
import type { ViewClientModel } from '~/structs/components/clients/view-client.model';





export const useViewClientOtherNamesOptions = async (
props: ViewClientProps, model: ViewClientModel 
) => {

const { t } = useI18n();

const label = computed(() => {
  const otherNames = model.otherNames || '';
  const mappedExpression = `${otherNames}`;
  return mappedExpression;
});

return {
  label
};

}