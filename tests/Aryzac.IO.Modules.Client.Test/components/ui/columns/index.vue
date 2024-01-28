<script setup lang="ts">
const debug = useDebug();

const props = defineProps({
    asideWidth: {
        type: String,
        default: 'w-96'
    },
    navWidth: {
        type: String,
        default: 'w-96'
    }
});
</script>

<template>
    <div class="h-full relative z-0 flex flex-1 overflow-hidden">

        <!-- Nav slot -->
        <nav v-if="$slots.nav"
             :class="[navWidth, 'relative', 'hidden', 'flex-shrink-0', 'overflow-y-auto', 'border-r', 'border-gray-200', 'xl:flex', 'xl:flex-col', 'order-0']">
            <div class="h-full inset-0 py-6 px-4 sm:px-6 lg:px-8">
                <div class="h-full rounded-lg"
                     :class="{ 'border-2 border-dashed border-gray-200': debug }">
                    <slot name="nav" />
                </div>
            </div>
        </nav>

        <!-- Main slot -->
        <main
              class="relative z-0 flex-1 overflow-y-auto focus:outline-none xl:order-1">
            <div class="h-full inset-0 py-6 px-4 sm:px-6 lg:px-8">
                <div class="h-full rounded-lg"
                     :class="{ 'border-2 border-dashed border-gray-200': debug }">
                    <slot />
                </div>
            </div>
        </main>

        <!-- Aside slot -->
        <aside v-if="$slots.aside"
               :class="[asideWidth, 'relative', 'hidden', 'flex-shrink-0', 'overflow-y-auto',
                   'border-l', 'border-gray-200', 'xl:flex', 'xl:flex-col', 'order-2']">
            <div class="h-full inset-0 py-6 px-4 sm:px-6 lg:px-8">
                <div class="h-full rounded-lg"
                     :class="{ 'border-2 border-dashed border-gray-200': debug }">
                    <slot name="aside" />
                </div>
            </div>
        </aside>
    </div>
</template>