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
  <div
    v-for="section in sections"
    :key="section.id"
    :data-section-id="section.id"
    :class="section.class"
  >
    <component :is="getComponent(section)" v-bind="section" />
  </div>
</template>
