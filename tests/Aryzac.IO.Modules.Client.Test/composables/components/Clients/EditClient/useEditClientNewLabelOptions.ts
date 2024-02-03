import type { EditClientProps } from "~/structs/components/clients/edit-client.props";
import type { EditClientModel } from "~/structs/components/clients/edit-client.model";

export const useEditClientNewLabelOptions = async (
  props: EditClientProps,
  model: EditClientModel
) => {
  const { t } = useI18n();

  const label = computed(() => {
    return "";
  });

  return {
    label,
  };
};
