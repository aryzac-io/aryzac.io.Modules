<i18n lang="yaml" src="@/locales/components/clients/edit-client.i18n.yaml" />

<script setup lang="ts">


import type { EditClientProps } from '~/structs/components/clients/edit-client.props';
import type { EditClientModel } from '~/structs/components/clients/edit-client.model';

import type { ClientDto } from '~/structs/dto/clients/client.dto';


import { useEditClientEditClientOptions } from '~/composables/components/clients/edit-client/useEditClientEditClientOptions'

const { t } = useI18n();


const props = defineProps<EditClientProps>();


const clientsServiceProxy = useClientsServiceProxy();

const query = await clientsServiceProxy.getClientByIdQuery(props.clientId);
const model = reactive<EditClientModel>({} as EditClientModel);

watchEffect(async () => {
  if (query.data.value) {
    Object.assign(model, query.data.value);
  }
});

const editClientOptions = await useEditClientEditClientOptions(props, model);

onMounted(() => {
  query.execute();
});
</script>


<template>

<div>
    
  <ui-heading-page
    :title="editClientOptions.title.value"
  />

    
  <ui-editor-section
    :title="t('personalInformation.title')"
    :description="t('personalInformation.description')"
  >

    
  <ui-input-textbox 
    v-model="model.firstName" 
    :label="t('personalInformation.firstName.label')" 
  />

    
  <ui-input-textbox 
    v-model="model.lastName" 
    :label="t('personalInformation.lastName.label')" 
  />

    
  <ui-input-textbox 
    v-model="model.otherNames" 
    :label="t('personalInformation.otherNames.label')" 
  />


  </ui-editor-section>  
    
  <ui-editor-section
    :title="t('salutation.title')"
    :description="t('salutation.description')"
  >


  </ui-editor-section>  
    
  <ui-editor-section
    :title="t('promotions.title')"
    :description="t('promotions.description')"
  >


  </ui-editor-section>  
    
  <ui-editor-section
    :title="t('notes.title')"
    :description="t('notes.description')"
  >


  </ui-editor-section>  
</div>
</template>
