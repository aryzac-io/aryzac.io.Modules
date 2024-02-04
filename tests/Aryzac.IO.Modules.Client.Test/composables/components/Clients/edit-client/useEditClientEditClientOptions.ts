import type { EditClientProps } from '~/structs/components/clients/edit-client.props';
import type { EditClientModel } from '~/structs/components/clients/edit-client.model';





export const useEditClientEditClientOptions = async (
props: EditClientProps, model: EditClientModel 
) => {

const { t } = useI18n();





const title = computed(() => {
  const lastName = model.lastName || '';
  const firstName = model.firstName || '';
  const mappedExpression = `${lastName}, ${firstName}`;
  return mappedExpression;
});











return {
  title,
};

}