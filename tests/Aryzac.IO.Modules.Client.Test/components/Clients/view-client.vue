<i18n lang="yaml" src="@/locales/components/clients/view-client.i18n.yaml" />

<script setup lang="ts">


import type { ViewClientProps } from '~/structs/components/clients/view-client.props';
import type { ViewClientModel } from '~/structs/components/clients/view-client.model';

import type { ClientDto } from '~/structs/dto/clients/client.dto';



const { t } = useI18n();


const props = defineProps<ViewClientProps>();


const clientsServiceProxy = useClientsServiceProxy();

const query = await clientsServiceProxy.getClientByIdQuery(props.clientId);
const model = reactive<ViewClientModel>({} as ViewClientModel);

watchEffect(async () => {
  if (query.data.value) {
    Object.assign(model, query.data.value);
  }
});


onMounted(() => {
  query.execute();
});
</script>


<template>

<div>
</div>
</template>
