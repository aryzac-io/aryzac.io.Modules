<i18n lang="yaml">
en:
  newHeading:
    title: NewHeading
  newSection:
    title: NewSection
    description: ''
    newTextbox:
      label: NewTextbox
  newSection:
    title: NewSection
    description: ''
    newTextbox:
      label: NewTextbox
    newCheckbox:
      label: NewCheckbox
      description: ''
    
</i18n>

<script setup lang="ts">
import type { ClientDto } from "~/structs/dto/clients/client.dto";

const { t } = useI18n();

const props = defineProps<{}>();

const clientsServiceProxy = useClientsServiceProxy();

// Queries
const {
  data: newComponentGetClientByIdData,
  pending: newComponentGetClientByIdPending,
  error: newComponentGetClientByIdError,
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
});

// NewHeading

const newHeadingAttributes = computed(() => []);

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

// NewTextbox
// NewSection

// NewTextbox
// NewCheckbox
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
    <ui-input-textbox :label="t('newSection.newTextbox.label')" />
  </ui-editor-section>
  <ui-editor-section
    :title="t('newSection.title')"
    :description="t('newSection.description')"
  >
    <ui-input-textbox :label="t('newSection.newTextbox.label')" />
    <ui-input-checkbox
      :label="t('newSection.newCheckbox.label')"
      :description="t('newSection.newCheckbox.description')"
    />
  </ui-editor-section>
</template>
