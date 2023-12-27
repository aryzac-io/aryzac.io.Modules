<script setup lang="ts">
import type { Item } from "~/structs/navigation";
import type { useRoute, useRouter, RouteLocationRaw } from "vue-router";

interface Props {
  items: Item[];
}

defineProps<Props>();

const route = useRoute();
const router = useRouter();
const isActive = (to: RouteLocationRaw) =>
  route.fullPath === router.resolve(to).fullPath;
</script>

<template>
  <li v-for="item in items" :key="item.name">
    <nuxt-link
      :to="item.to"
      @click.prevent="router.push(item.to)"
      :class="[
        isActive(item.to)
          ? 'bg-gray-50 text-indigo-600'
          : 'text-gray-700 hover:text-indigo-600 hover:bg-gray-50',
        'group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold',
      ]"
    >
      <Icon
        :name="item.icon"
        :class="[
          isActive(item.to)
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
