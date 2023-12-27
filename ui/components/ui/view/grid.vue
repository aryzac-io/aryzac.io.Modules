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
  columnClasses: {
    type: Array,
    default: () => [
      "grid-cols-1",
      "sm:grid-cols-2",
      "md:grid-cols-3",
      "lg:grid-cols-4",
      "xl:grid-cols-5",
      "2xl:grid-cols-6",
    ],
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

const gridClasses = computed(() => {
  return props.columnClasses.join(" ");
});
</script>

<template>
  <ul role="list" class="grid gap-6" :class="gridClasses">
    <li
      v-for="(item, index) in items"
      :key="getKey(item, index)"
      class="col-span-1 flex flex-col divide-y divide-gray-200 rounded-lg bg-white text-center shadow"
      @click="handleItemClicked(item, index)"
    >
      <slot v-bind="{ item, index }"></slot>
    </li>
  </ul>
  <ui-view-pagination class="mt-6" />
</template>
