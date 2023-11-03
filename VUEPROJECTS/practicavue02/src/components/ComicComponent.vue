<template>
  <div>
    <div class="card" style="width: 18rem;">
        <img :src=this.comic.imagen class="card-img-top" alt="comic">
        <div class="card-body">
            <h5 class="card-title">{{ this.comic.titulo }}</h5>
            <p class="card-text">{{ this.comic.descripcion }}</p>  
            <h3 :class="{rojo: this.comic.year <=200, verde: this.comic.year > 200}">{{this.comic.year}}</h3>      
            <button class="btn btn-success" @click="Handle_Favorito" >Favorito</button>    
            <button class="btn btn-danger" @click="Handle_Eliminar" >Eliminar</button>   
            <router-link class="btn btn-primary" :to="'/ComicDetalles/'+this.comic.titulo" >Detalles</router-link>                
        </div>
    </div>
  </div>
</template>                .


<script>
export default {
    props: ['comic', 'index'],
    methods:{
      Handle_Favorito(){
        this.$emit("seleccionar_favorito", this.comic);
      },
      Handle_Eliminar(){
        this.$emit("delete_comic", this.index);
      }
    }
}
</script>

<style>
      @import "./../assets/Comic.css";
</style>