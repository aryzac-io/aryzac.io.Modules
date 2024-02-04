<i18n lang="yaml" src="@/locales/components/clients/view-client.i18n.yaml" />

<script setup lang="ts">


import type { ViewClientProps } from '~/structs/components/clients/view-client.props';
import type { ViewClientModel } from '~/structs/components/clients/view-client.model';

import type { ClientDto } from '~/structs/dto/clients/client.dto';


import { useViewClientViewClientOptions } from '~/composables/components/clients/view-client/useViewClientViewClientOptions'
import { useViewClientFirstNameOptions } from '~/composables/components/clients/view-client/useViewClientFirstNameOptions'
import { useViewClientLastNameOptions } from '~/composables/components/clients/view-client/useViewClientLastNameOptions'
import { useViewClientOtherNamesOptions } from '~/composables/components/clients/view-client/useViewClientOtherNamesOptions'
import { useViewClientReceivePromotionsOptions } from '~/composables/components/clients/view-client/useViewClientReceivePromotionsOptions'
import { useViewClientNotesOptions } from '~/composables/components/clients/view-client/useViewClientNotesOptions'

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

const viewClientOptions = await useViewClientViewClientOptions(props, model);
const firstNameOptions = await useViewClientFirstNameOptions(props, model);
const lastNameOptions = await useViewClientLastNameOptions(props, model);
const otherNamesOptions = await useViewClientOtherNamesOptions(props, model);
const receivePromotionsOptions = await useViewClientReceivePromotionsOptions(props, model);
const notesOptions = await useViewClientNotesOptions(props, model);

onMounted(() => {
  query.execute();
});
</script>


<template>

<div>
    
  <ui-heading-page
    :title="viewClientOptions.title.value"
    :actions="viewClientOptions.actions"
  />

    
  <ui-editor-section
    :title="t('section-personalInformation.title')"
    :description="t('section-personalInformation.description')"
  >

    
  <ui-input-label 
    v-model="firstNameOptions.label.value" 
    :label="t('section-personalInformation.label-firstName.label')" 
  />

    
  <ui-input-label 
    v-model="lastNameOptions.label.value" 
    :label="t('section-personalInformation.label-lastName.label')" 
  />

    
  <ui-input-label 
    v-model="otherNamesOptions.label.value" 
    :label="t('section-personalInformation.label-otherNames.label')" 
  />


  </ui-editor-section>  
    
  <ui-editor-section
    :title="t('section-promotions.title')"
    :description="t('section-promotions.description')"
  >

    
  <ui-input-label 
    v-model="receivePromotionsOptions.label.value" 
    :label="t('section-promotions.label-receivePromotions.label')" 
  />


  </ui-editor-section>  
    
  <ui-editor-section
    :title="t('section-notes.title')"
    :description="t('section-notes.description')"
  >

    
  <ui-input-label 
    v-model="notesOptions.label.value" 
    :label="t('section-notes.label-notes.label')" 
  />


  </ui-editor-section>  
</div>
</template>
