<i18n lang="yaml">
en:
  newHeading:
    title: NewHeading
    attributes:
      newHeadingAttributeLabel: NewHeadingAttribute
    
</i18n>

<script setup lang="ts">


const { t } = useI18n();

const props = defineProps<{
}>();
	






// NewHeading

const newHeadingAttributes = computed(() => [
  {
	icon: '',
	label: t("newHeading.attributes.newHeadingAttributeLabel"),
  },
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

</script>

<template>
  <ui-heading-page
    :title="t('newHeading.title')"
    :attributes="newHeadingAttributes"
    :actions="newHeadingActions"
  />
</template>