<template>
  <div>
    <ul class="nav">
      <li class="nav-item">           
        <router-link class="nav-link" to="/">Home</router-link>
      </li>
      <li class="nav-item">
        <router-link class="nav-link" to="/Collazt">Collazt</router-link>
      </li>
      <li class="nav-item">
        <router-link class="nav-link" to="/TablaMultiplicar">TablaMultiplicar</router-link>
      </li>
      <li class="nav-item">
        <router-link class="nav-link" to="/PadreComponent">PadreComponent</router-link>
      </li>
      <li class="nav-item">
        <router-link class="nav-link" to="/AcumularComponent">AcumularComponent</router-link>
      </li>
      <li class="nav-item">
        <router-link class="nav-link" to="/ComicsComponent">ComicsComponent</router-link>
      </li>
    </ul>            
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
