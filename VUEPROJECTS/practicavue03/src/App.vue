<template>
  <div>
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">HOME</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav" id="menu_app">           
            <li class="nav-item">
              <router-link class="nav-link" to="/tabla_multiplicar/">Tabla Multiplicar</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/coches_servicios/">Vue Servicios Coches</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/EmpleadosDetalle/">Vue Servicios EmpleadosDetalle</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/OficiosHome/">Vue Servicios Oficios</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/Departamentos/">Vue Departamentos</router-link>
            </li>
            <li>
              <router-link class="nav-link" to="/HomeSeries/">Vue Series</router-link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
    <div id="router-view-container">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import gsap from "gsap";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap";

export default {
  name: 'App',
  components: {
     
  },
  mounted(){
    this.Animation_Nav();
  }, 
  watch:{
    $route(){
      this.Animation_RouterView();
    }
  },
  methods:{
        Animation_Nav(){
            gsap.from("#menu_app",
                {
                    x:-200,
                    duration: 1.5,
                    ease: 'ease.out'
                });
        },
        Animation_RouterView(){          
          gsap.from("#router-view-container",
                {
                    x:-200,
                    duration: 1                 
                });
        }
    }
}
</script>

<style>

</style>
