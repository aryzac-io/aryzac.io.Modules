import type { ComposerTranslation } from "@nuxtjs/i18n/dist/runtime/composables";

import type { TitleDto } from "~/structs/dto/titles/title.dto";

export const useEditClientTitleSelectOptions = async (
  t: ComposerTranslation
) => {
  const titlesServiceProxy = useTitlesServiceProxy();

  // Queries
  const { data, pending, error, execute, refresh, status } =
    await titlesServiceProxy.getTitlesQuery();

  const titleSelectOptions = computed(() => {
    const options: { value: string; label: string }[] = [];
    if (data.value) {
      data.value.forEach((item: TitleDto) => {
        const name = item.name || "";
        const code = item.code || "";
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
    titleSelectOptions,
  };
};
