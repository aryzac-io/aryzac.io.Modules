<i18n lang="yaml" src="@/locales/components/clients/edit-client.i18n.yaml" />

<script setup lang="ts">


import type { EditClientProps } from '~/structs/components/clients/edit-client.props';
import type { EditClientModel } from '~/structs/components/clients/edit-client.model';

import type { ClientDto } from '~/structs/dto/clients/client.dto';


import { useEditClientEditClientOptions } from '~/composables/components/clients/edit-client/useEditClientEditClientOptions'
import { useEditClientTitleOptions } from '~/composables/components/clients/edit-client/useEditClientTitleOptions'

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
const titleOptions = await useEditClientTitleOptions(props, model);

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
    :title="t('section-personalInformation.title')"
    :description="t('section-personalInformation.description')"
  >

    
  <ui-input-textbox 
    v-model="model.firstName" 
    :label="t('section-personalInformation.textbox-firstName.label')" 
  />

    
  <ui-input-textbox 
    v-model="model.lastName" 
    :label="t('section-personalInformation.textbox-lastName.label')" 
  />

    
  <ui-input-textbox 
    v-model="model.otherNames" 
    :label="t('section-personalInformation.textbox-otherNames.label')" 
  />


  </ui-editor-section>  
    
  <ui-editor-section
    :title="t('section-salutation.title')"
    :description="t('section-salutation.description')"
  >

    
  <ui-input-select 
    v-model="model.title" 
    :label="t('section-salutation.select-title.label')"
    :options="titleOptions.options.value"
  />


  </ui-editor-section>  
    
  <ui-editor-section
    :title="t('section-promotions.title')"
    :description="t('section-promotions.description')"
  >

    
  <ui-input-checkbox 
    v-model="model.canReceivePromotions" 
    :label="t('section-promotions.checkbox-canReceivePromotions.label')" 
    :description="t('section-promotions.checkbox-canReceivePromotions.description')" 
  />


  </ui-editor-section>  
    
  <ui-editor-section
    :title="t('section-notes.title')"
    :description="t('section-notes.description')"
  >

    
  <ui-input-text-area 
    v-model="model.notes" 
    :label="t('section-notes.text-area-notes.label')" 
  />


  </ui-editor-section>  
</div>
</template>
