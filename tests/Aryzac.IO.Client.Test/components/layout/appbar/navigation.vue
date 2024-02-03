<script setup lang="ts">
import type NavigationItem from "@/structs/navigation";

interface Props {
  items: NavigationItem[];
}

defineProps<Props>();

const { getActiveItem } = useNavigationStore();
const localeRoute = useLocaleRoute();

const isActive = (item: NavigationItem) => {
  const activeItem = getActiveItem("appbar");
  return activeItem && activeItem.id === item.id;
};
</script>

<template>
  <nuxt-link
    v-for="item in items"
    :key="item.id"
    :to="localeRoute(item.to)"
    :class="[
      isActive(item)
        ? 'border-indigo-500 text-gray-900'
        : 'border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700',
    ]"
    class="inline-flex items-center border-b-2 px-1 pt-1 text-sm font-medium"
  >
    {{ item.name }}
  </nuxt-link>
</template>
