<script setup lang="ts">
import type NavigationItem from "@/structs/navigation";

interface Props {
  items: NavigationItem[];
}

defineProps<Props>();

const { getActiveItem } = useNavigationStore();
const localeRoute = useLocaleRoute();

const isActive = (item: NavigationItem) => {
  const activeItem = getActiveItem("sidebar");
  return activeItem && activeItem.id === item.id;
};
</script>

<template>
  <li v-for="item in items" :key="item.id">
    <nuxt-link
      :to="localeRoute(item.to)"
      :class="[
        isActive(item)
          ? 'border-indigo-500 text-gray-900'
          : 'border-transparent text-gray-500 hover:border-gray-300 hover:text-gray-700',
        'flex gap-x-3 border-r-2 px-1 pt-1 text-sm font-medium leading-6',
      ]"
    >
      <Icon
        :name="item.icon"
        :class="[
          isActive(item)
            ? 'text-indigo-600'
            : 'text-gray-400 group-hover:text-indigo-600',
          'h-6 w-6 shrink-0',
        ]"
        aria-hidden="true"
      />
      {{ item.name }}
    </nuxt-link>
  </li>
</template>
