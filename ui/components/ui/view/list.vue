<script setup>
const props = defineProps({
  items: {
    type: Array,
    default: () => [],
    validator: (items) => items.every((item) => typeof item === "object"),
  },
  key: {
    type: [String, Function],
    default: null,
  },
});

const emit = defineEmits(["itemClicked"]);

const { key, items } = toRefs(props);

const getKey = (item, index) => {
  if (typeof key.value === "function") {
    return key.value(item);
  } else if (typeof key.value === "string" && item[key.value] !== undefined) {
    return item[key.value];
  } else {
    console.warn(
      `A valid key could not be determined for the list item at index ${index}. Falling back to index. Consider providing a valid key prop.`
    );
    return index;
  }
};

const handleItemClicked = (item, index) => {
  emit("itemClicked", { item, index });
};
</script>

<template>
  <ul role="list" class="divide-y divide-gray-100 bg-white">
    <li
      v-for="(item, index) in items"
      :key="getKey(item, index)"
      class="relative flex items-center justify-between gap-x-6 py-5 hover:bg-gray-50 cursor-pointer"
      @click="handleItemClicked(item, index)"
    >
      <slot v-bind="{ item, index }"></slot>
    </li>
  </ul>
  <ui-view-pagination />
</template>
