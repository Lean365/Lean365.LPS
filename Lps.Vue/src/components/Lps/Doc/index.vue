<template>
  <div>
    <svg-icon name="question" @click="goto" />
  </div>
</template>
<script setup>
  const url = ref('https://leansoft365.github.io/docs/');

  function goto() {
    window.open(url.value)
  }
</script>