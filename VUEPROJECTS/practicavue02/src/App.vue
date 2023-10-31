<template>
  <div>
    <router-link class="nav-link" to="/Collazt">Collazt</router-link>
    <router-link class="nav-link" to="/">Home</router-link>
    <router-view/>
  </div>
</template>

<script>
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap";
export default {
  name: 'App',
  components: {
   
  }
}
</script>

<style>

</style>
