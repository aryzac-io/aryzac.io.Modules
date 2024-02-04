import type { ViewClientProps } from '~/structs/components/clients/view-client.props';
import type { ViewClientModel } from '~/structs/components/clients/view-client.model';





export const useViewClientNotesOptions = async (
props: ViewClientProps, model: ViewClientModel 
) => {

const { t } = useI18n();

const label = computed(() => {
  const notes = model.notes || '';
  const mappedExpression = `${notes}`;
  return mappedExpression;
});

return {
  label
};

}