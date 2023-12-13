<template>
  <button @click="increment">
    {{ props.text }} {{ count }}
  </button>
</template>

<script lang="ts" setup>

const props = defineProps({
  text: Text
});

const emits = defineEmits(['onClick']);

import {ref, Text} from "vue";

const count = ref(0);

function increment() {
  count.value++;
  emits('onClick', count.value);
}

</script>

<style scoped>
</style>
