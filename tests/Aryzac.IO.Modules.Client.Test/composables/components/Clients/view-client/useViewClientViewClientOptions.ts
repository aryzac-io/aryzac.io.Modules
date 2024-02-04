import type { ViewClientProps } from '~/structs/components/clients/view-client.props';
import type { ViewClientModel } from '~/structs/components/clients/view-client.model';





export const useViewClientViewClientOptions = async (
props: ViewClientProps, model: ViewClientModel 
) => {

const { t } = useI18n();





const title = computed(() => {
  const lastName = model.lastName || '';
  const firstName = model.firstName || '';
  const mappedExpression = `${lastName}, ${firstName}`;
  return mappedExpression;
});









const actions = [
  {
    label: t("heading-viewClient.actions.action-edit.label"),
    icon: t("heading-viewClient.actions.action-edit.icon"),
action: async () => {
      const localeRoute = useLocaleRoute();
      await navigateTo(localeRoute(`/Clients/${props.clientId}/edit`));
    },
  },
];


return {
  title,
	actions,
};

}