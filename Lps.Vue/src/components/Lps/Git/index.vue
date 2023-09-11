<template>
  <div>
    <svg-icon name="github" @click="goto" />
  </div>
</template>
<script>
  export default {
    setup() {
      const url = ref("https://github.com/Lean365/Lean365.LPS");

      function goto() {
        window.open(url.value);
      }

      return {
        goto,
      };
    },
  };
</script>