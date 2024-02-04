<script setup>
const model = defineModel({ type: String });

const props = defineProps({
  label: String,
  rows: {
    type: [Number, String],
    default: 4,
  },
});

function updateValue(event) {
  autoGrow(event);
}

// Auto-grow functionality
function autoGrow(event) {
  event.target.style.height = "auto";
  event.target.style.height = event.target.scrollHeight + "px";
}
</script>

<template>
  <div>
    <label
      :for="id"
      class="block text-sm font-medium leading-6 text-gray-900"
      >{{ label }}</label
    >
    <div class="mt-2">
      <textarea
        :rows="rows"
        v-model="model"
        class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-1 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6 resize-none overflow-hidden"
      ></textarea>
    </div>
  </div>
</template>
