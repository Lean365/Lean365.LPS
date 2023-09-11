<template>
  <div>
    <svg-icon name="question" @click="goto" />
  </div>
</template>
<script setup>
  const url = ref('https://lean365docs.github.io/');

  function goto() {
    window.open(url.value)
  }
</script>