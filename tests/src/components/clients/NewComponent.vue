<i18n lang="yaml">
en:
  newHeading:
    title: NewHeading
  newSection:
    title: NewSection
    description: ''
    firstName:
      label: firstName
  newSection:
    title: NewSection
    description: ''
    lastName:
      label: lastName
    otherNames:
      label: otherNames
    
</i18n>

<script setup lang="ts">
import type { ClientDto } from '~/structs/dto/clients/client.dto';

const { t } = useI18n();

const props = defineProps<{
}>();
	
const clientsServiceProxy = useClientsServiceProxy();

// Queries
const { 
  data: newComponentGetClientByIdData, 
  pending: newComponentGetClientByIdPending, 
  error: newComponentGetClientByIdError 
} = await clientsServiceProxy.getClientById(props.id);

// Model
interface ModelInterface {
  lastName: string;
  name: string;
  otherNames?: string;
}

const model: ModelInterface = reactive({
  lastName: "",
  name: "",
  otherNames: "",
});

watchEffect(async () => {
  if (newComponentGetClientByIdData.value) {
    model.lastName = newComponentGetClientByIdData.value.lastName;
    model.name = newComponentGetClientByIdData.value.firstName;
    model.otherNames = newComponentGetClientByIdData.value.otherNames;
  }
})



// NewHeading

const newHeadingAttributes = computed(() => [
]
);

const newHeadingActions = computed(() => [
  {
    label: "Create Invoice",
    icon: "heroicons:plus",
    function: async () => {
      await navigateTo(`/clients/${props.clientId}/invoices/create`);
    },
  },
]);

// NewSection

// firstName
// NewSection

// lastName
// otherNames
</script>

<template>
  <ui-heading-page
    :title="t('newHeading.title')"
    :attributes="newHeadingAttributes"
    :actions="newHeadingActions"
  />
  <ui-editor-section
    :title="t('newSection.title')"
    :description="t('newSection.description')"
  >
     <ui-input-textbox 
       v-model="model.firstName" 
       :label="t('newSection.firstName.label')" />
  </ui-editor-section>
  <ui-editor-section
    :title="t('newSection.title')"
    :description="t('newSection.description')"
  >
     <ui-input-textbox 
       v-model="model.lastName" 
       :label="t('newSection.lastName.label')" />
     <ui-input-textbox 
       v-model="model.otherNames" 
       :label="t('newSection.otherNames.label')" />
  </ui-editor-section>
</template>