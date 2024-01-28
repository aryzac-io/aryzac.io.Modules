<script setup>
import { Menu, MenuButton, MenuItem, MenuItems } from "@headlessui/vue";

defineProps({
  title: {
    type: String,
    required: true,
  },
  attributes: {
    type: Array,
    default: () => [],
    validator: (items) => items.every((item) => typeof item === "object"),
  },
  actions: {
    type: Array,
    default: () => [],
    validator: (items) => items.every((item) => typeof item === "object"),
  },
});
</script>

<template>
  <div class="lg:flex lg:items-center lg:justify-between">
    <div class="min-w-0 flex-1">
      <h2
        class="mt-2 text-2xl font-bold leading-7 text-gray-900 sm:truncate sm:text-3xl sm:tracking-tight"
      >
        {{ title }}
      </h2>
      <div
        class="mt-1 flex flex-col sm:mt-0 sm:flex-row sm:flex-wrap sm:space-x-6"
      >
        <div
          v-for="(attribute, index) in attributes"
          :key="index"
          class="mt-2 flex items-center text-sm text-gray-500"
        >
          <icon
            v-if="attribute.icon"
            :name="attribute.icon"
            class="mr-1.5 h-5 w-5 flex-shrink-0 text-gray-400"
            aria-hidden="true"
          />
          {{ attribute.label }}
        </div>
      </div>
    </div>

    <div
      v-for="action in actions"
      :key="action.label"
      class="mt-5 flex lg:ml-4 lg:mt-0"
    >
      <button
        type="button"
        class="inline-flex items-center gap-x-2 rounded-md bg-indigo-600 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
        @click="action.action"
      >
        <icon
          v-if="action.icon"
          :name="action.icon"
          class="-ml-0.5 h-5 w-5"
          aria-hidden="true"
        />
        {{ action.label }}
      </button>
    </div>
  </div>
</template>