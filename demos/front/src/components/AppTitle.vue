<template>
  <h1>{{ props.text }}</h1>
</template>

<script lang="ts" setup>

import {Text} from "vue";

const props = defineProps({
  text: Text
})

</script>

<style scoped>
</style>
