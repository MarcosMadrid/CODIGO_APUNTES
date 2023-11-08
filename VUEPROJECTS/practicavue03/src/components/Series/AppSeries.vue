<template>
  <div>
    <div class="card text-center">
      <menu-series></menu-series>
      <div class="card-body">
        <router-view class="router-view" ></router-view>        
      </div>   
    </div>
  </div>
</template>

<script>
import gsap from 'gsap';
import MenuSeries from './MenuSeries.vue'
export default {
    name : 'AppSeries',
    components: { MenuSeries },
    watch:{
      $route(){
        this.Animation_RouterView()
      }
    },
  methods:{
    Animation_RouterView(){
      gsap.from(".card-body",
          {
              x:-200,
              duration: 1.5
          });
    }
  }
}
</script>

<style>

</style>