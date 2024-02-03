import type { EditClientProps } from '~/structs/components/clients/edit-client.props';
import type { EditClientModel } from '~/structs/components/clients/edit-client.model';





export const useEditClientHeadingOptions = async (
props: EditClientProps, model: EditClientModel 
) => {

const { t } = useI18n();





const title = computed(() => {
  return t('heading.title');
});











return {
  title,
};

}
