<template>
  <div>
    <div class="card text-center">
      <menu-series></menu-series>
      <div class="card-body">
        <router-view></router-view>        
      </div>   
    </div>
  </div>
</template>

<script>
import MenuSeries from './MenuSeries.vue'
export default {
    name : 'AppSeries',
    components: { MenuSeries }
}
</script>

<style>

</style>