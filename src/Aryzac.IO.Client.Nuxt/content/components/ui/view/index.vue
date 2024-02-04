<script setup>
// Props definition
const props = defineProps({
  hideBorder: {
    type: Boolean,
    default: () => false,
  },
  loading: {
    type: Boolean,
    default: () => false,
  },
  items: {
    type: Array,
    default: () => [],
  },
  config: {
    type: Array,
    default: () => [],
  },
  actions: {
    type: Array,
    default: () => [],
  },
});

const { loading, items, config, actions } = toRefs(props);

// Use the config prop to generate the views
const views = config.value.map((view) => ({
  slotName: view.name || "defaultSlotName",
  label: view.label || "defaultLabel",
  icon: view.icon || "defaultIconName",
}));

const currentView = ref(views[0].slotName); // default to the first view

const tabs = views.map((view) => ({
  name: view.label,
  icon: view.icon,
  current: currentView.value === view.slotName,
  href: "#" + view.slotName,
}));

const changeView = (tab) => {
  currentView.value = tab.slotName;
};

const emit = defineEmits();

const load = () => {
  emit("load-more");
};
</script>

<template>
  <div class="px-4 sm:px-6 lg:px-8">
    <div class="sm:flex sm:items-center">
      <div class="sm:flex-auto">
        <h1 class="text-base font-semibold leading-6 text-gray-900">Users</h1>
        <p class="mt-2 text-sm text-gray-700">
          A list of all the users in your account including their name, title,
          email and role.
        </p>
      </div>
      <div class="mt-4 sm:ml-16 sm:mt-0 sm:flex-none">
        <button
          type="button"
          class="block rounded-md bg-indigo-600 px-3 py-2 text-center text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
        >
          Add user
        </button>
      </div>
    </div>
    <div class="mt-8 flow-root">
      <div class="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
        <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
          <div
            class="overflow-hidden sm:rounded-lg"
            :class="{
              'shadow ring-1 ring-black ring-opacity-5': !hideBorder,
            }"
          >
            <div v-for="view in views" :key="view.slotName">
              <!-- Content slots -->
              <slot
                v-if="currentView === view.slotName"
                :name="view.slotName"
                :items="items"
              ></slot>

              <!-- Loading progress -->
              <div v-if="loading && currentView === view.slotName">
                <slot :name="`${view.slotName}-loader`">
                  <div class="w-full h-1 bg-blue-200">
                    <div class="h-1 bg-blue-500 animate-pulse"></div>
                  </div>
                </slot>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
