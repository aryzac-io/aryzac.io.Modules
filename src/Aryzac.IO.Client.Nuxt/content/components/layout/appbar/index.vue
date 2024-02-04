<script setup lang="ts">
import {
  Disclosure,
  DisclosureButton,
  DisclosurePanel,
  Menu,
  MenuButton,
  MenuItem,
  MenuItems,
} from "@headlessui/vue";

const { openSidebar } = useSidebar();

const { navigationItems } = useNavigation("appbar");
</script>

<template>
  <Disclosure as="nav" class="bg-white shadow" v-slot="{ open }">
    <div class="mx-auto px-2 border-b border-gray-200 sm:pr-4 lg:pr-8">
      <div class="flex h-16 justify-between">
        <layout-appbar-section :sections="navigationItems" />
      </div>
    </div>

    <DisclosurePanel class="lg:hidden">
      <layout-appbar-section :sections="navigationItems" />
    </DisclosurePanel>
  </Disclosure>
</template>
