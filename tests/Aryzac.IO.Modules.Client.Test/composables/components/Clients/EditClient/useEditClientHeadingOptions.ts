import type { ComposerTranslation } from "@nuxtjs/i18n/dist/runtime/composables";

import type { EditClientProps } from "~/structs/components/clients/edit-client.props";
import type { EditClientModel } from "~/structs/components/clients/edit-client.model";

export const useEditClientHeadingOptions = async (
  props: EditClientProps,
  model: EditClientModel,
  t: ComposerTranslation
) => {
  return {};
};
