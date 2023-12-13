<template>
  <div>
    <AppTitle :text="`Counter: ${buttonClickCount}`"/>
    <AppCounterButton
        text="Button Count Trigger"
        @on-click="handleButtonOnClick"/>
  </div>
</template>

<script lang="ts" setup>

import {ref} from "vue";
import AppCounterButton from "@/components/AppCounterButton.vue";
import AppTitle from "@/components/AppTitle.vue";

const buttonClickCount = ref(0);

function handleButtonOnClick(count) {
  buttonClickCount.value = count;
}

</script>

<style scoped>
</style>
