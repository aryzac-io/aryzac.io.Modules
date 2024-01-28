<script setup lang="ts">
import type NavigationItem from "@/structs/navigation";

const { navigationItems } = useNavigation("breadcrumb", true);
const { getActiveItem } = useNavigationStore();
const localeRoute = useLocaleRoute();

const isActive = (breadcrumb: NavigationItem) => {
  const activeItem = getActiveItem("breadcrumb");
  return activeItem && activeItem.id === breadcrumb.id;
};
</script>

<template>
  <nav
    v-if="navigationItems.length > 0"
    class="flex border-b border-gray-200 bg-white"
    aria-label="Breadcrumb"
  >
    <ol role="list" class="mx-auto flex w-full space-x-4 h-11">
      <li
        v-for="(breadcrumb, n) in navigationItems"
        :key="breadcrumb.to"
        class="flex"
      >
        <div class="flex items-center">
          <svg
            v-if="n !== 0"
            class="h-full w-6 flex-shrink-0 text-gray-200"
            viewBox="0 0 24 44"
            preserveAspectRatio="none"
            fill="currentColor"
            aria-hidden="true"
          >
            <path d="M.293 0l22 22-22 22h1.414l22-22-22-22H.293z" />
          </svg>
          <nuxt-link
            :to="localeRoute(breadcrumb.to)"
            class="ml-4 text-sm font-medium text-gray-500 hover:text-gray-700"
            :aria-current="isActive(breadcrumb) ? 'breadcrumb' : undefined"
          >
            <icon
              v-if="breadcrumb.icon"
              :name="breadcrumb.icon"
              class="h-5 w-5 flex-shrink-0"
              aria-hidden="true"
            />
            <span v-else>{{ breadcrumb.name }}</span>
          </nuxt-link>
          <span class="sr-only">{{ breadcrumb.name }}</span>
        </div>
      </li>
    </ol>
  </nav>
</template>
