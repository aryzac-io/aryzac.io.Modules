<script setup lang="ts">
import breakpointPadded from './breakpoint-padded.vue';
import constrainedPadded from './constrained-padded.vue';
import mobileFullBreakpointPadded from './mobile-full-breakpoint-padded.vue';
import mobileFullConstrainedPadded from './mobile-full-constrained-padded.vue';
import narrowConstrainedPadded from './narrow-constrained-padded.vue';

const props = defineProps({
    type: {
        type: String,
        default: 'breakpoint-padded',
        validator: value => {
            return [
                'breakpoint-padded',
                'constrained-padded',
                'mobile-full-breakpoint-padded',
                'mobile-full-constrained-padded',
                'narrow-constrained-padded'
            ].includes(value);
        }
    }
});

const Container = ref(null);

switch (props.type) {
    case 'breakpoint-padded':
        Container.value = breakpointPadded;
        break;
    case 'constrained-padded':
        Container.value = constrainedPadded;
        break;
    case 'fullWidthOnMobileConstrainedToBreakpoint':
        Container.value = mobileFullBreakpointPadded;
        break;
    case 'fullWidthOnMobileConstrained':
        Container.value = mobileFullConstrainedPadded;
        break;
    case 'narrowConstrained':
        Container.value = narrowConstrainedPadded;
        break;
    default:
        throw new Error(`Unsupported container type: ${props.type}`);
}
</script>

<template>
    <component :is="Container">
        <slot />
    </component>
</template>
