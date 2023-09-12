<template>
  <v-form-designer ref="vfdRef"></v-form-designer>
</template>

<script setup>
  const vfdRef = ref(null)
</script>

<style lang="scss">
  body {
    margin: 0;
    /* 如果页面出现垂直滚动条，则加入此行CSS以消除之 */
  }
</style>