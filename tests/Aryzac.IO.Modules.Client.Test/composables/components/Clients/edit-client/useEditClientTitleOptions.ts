import type { EditClientProps } from '~/structs/components/clients/edit-client.props';
import type { EditClientModel } from '~/structs/components/clients/edit-client.model';

import type { TitleDto } from '~/structs/dto/titles/title.dto';




export const useEditClientTitleOptions = async (
props: EditClientProps, model: EditClientModel 
) => {

const { t } = useI18n();


const titlesServiceProxy = useTitlesServiceProxy();



// Queries
const { 
  data,
  pending,
  error,
  execute,
  refresh,
  status
} = await titlesServiceProxy.getTitlesQuery();



const options = computed(() => {
  const options: { value: string; label: string }[] = [];
  if (data.value) {
    data.value.forEach((item: TitleDto) => {
      const name = item.name || '';
      const code = item.code || '';
      const mappedExpression = `${name} (${code})`;

      options.push({
        value: item.id,
        label: mappedExpression,
      });
    });
  }
  return options;
});


return {
	data,
	pending,
	error,
	execute,
	refresh,
	status,
	options
};

}
