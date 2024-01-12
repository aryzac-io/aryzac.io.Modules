<script setup>
const props = defineProps({
  label: String,
  body: String,
  id: String,
  colSpan: {
    type: [Number, String],
    default: 3,
  },
  rows: {
    type: [Number, String],
    default: 4,
  },
});
</script>

<template>
  <div :class="['sm:col-span-' + colSpan]">
    <label :for="id"
           class="block text-sm font-medium leading-6 text-gray-900">{{ label
           }}</label>
    <div class="mt-2">
      <span :id="id">{{ body }}</span>
    </div>
  </div>
</template>
