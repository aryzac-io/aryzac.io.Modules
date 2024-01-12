<script setup lang="ts">
import type NavigationSection from "@/structs/navigation";
import { components } from "../components";

interface Props {
  sections: NavigationSection[];
}

defineProps<Props>();

const getComponent = (section: NavigationSection) => {
  return components[section.component];
};
</script>

<template>
  <li
    v-for="section in sections"
    :key="section.id"
    :data-section-id="section.id"
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
