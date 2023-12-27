<script setup>
const props = defineProps({
  title: String,
  description: String,
  padding: {
    type: Boolean,
    default: () => true,
  },
});
</script>

<template>
  <div class="pt-10 grid grid-cols-1 gap-x-8 gap-y-8 md:grid-cols-3">
    <div class="px-4 sm:px-0">
      <h2 class="text-base font-semibold leading-7 text-gray-900">
        {{ title }}
      </h2>
      <p class="mt-1 text-sm leading-6 text-gray-600">
        {{ description }}
      </p>
    </div>

    <div
      class="bg-white shadow-sm ring-1 ring-gray-900/5 sm:rounded-xl md:col-span-2"
    >
      <div :class="{ 'px-4 py-6 sm:p-8': padding, 'pb-6': !padding }">
        <div :class="{ 'gap-x-6 gap-y-8': padding }">
          <div :class="{ 'space-y-10': padding }">
            <slot />
          </div>
        </div>
      </div>
      <div
        class="flex items-center justify-end gap-x-6 border-t border-gray-900/10 px-4 py-4 sm:px-8"
        v-if="$slots.actions"
      >
        <slot name="actions" />
      </div>
    </div>
  </div>
</template>
