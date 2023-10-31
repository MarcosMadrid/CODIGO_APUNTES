<template >
  <div>
    <MenuComponent/>
    <router-view/>
  </div>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue';
// import HolaMundo from './components/HolaMundo.vue';
import MenuComponent from './components/MenuComponent.vue';
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap";
export default {
  name: 'App',
  components: {
    MenuComponent
    // HelloWorld
    
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
