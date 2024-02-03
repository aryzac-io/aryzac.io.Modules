import type { EditClientProps } from '~/structs/components/clients/edit-client.props';
import type { EditClientModel } from '~/structs/components/clients/edit-client.model';





export const useEditClientNewSelectOptions = async (
props: EditClientProps, model: EditClientModel 
) => {

const { t } = useI18n();








const options = computed(() => {
  const options: { value: string; label: string }[] = [];
  return options;
});


return {
	options
};

}