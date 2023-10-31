<template>
  <div>
    <NumeroParImpar></NumeroParImpar>
    <MetodosFilters></MetodosFilters>
  </div>
</template>

<script>
import NumeroParImpar from './components/NumeroParImpar.vue';
import MetodosFilters from './components/MetodosFilters.vue';
export default {
  name: 'App',
  components: {
    NumeroParImpar,
    MetodosFilters
  }
}
</script>

<style>

</style>
