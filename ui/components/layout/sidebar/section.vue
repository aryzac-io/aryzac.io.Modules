<script setup lang="ts">
import type { Section } from "~/structs/navigation";

interface Props {
  sections: Section[];
}

defineProps<Props>();

const components = {
  navigation: resolveComponent("layout-sidebar-navigation"),
};

const getComponent = (section: Section) => {
  return components[section.component];
};
</script>

<template>
  <li
    v-for="section in sections"
    :key="section.id"
    :data-section-id="section.id"
    :class="{
      'border-2 border-dashed border-green-600': section.title !== undefined,
    }"
  >
    <div
      v-if="section.title"
      class="text-xs font-semibold leading-6 text-gray-400"
    >
      {{ section.title }}
    </div>
    <ul role="list" class="mt-2 -mx-2 space-y-1">
      <component :is="getComponent(section)" v-bind="section" />
    </ul>
  </li>
</template>
