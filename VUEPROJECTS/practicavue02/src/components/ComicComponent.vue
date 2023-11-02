<template>
  <div>
    <div class="card" style="width: 18rem;">
        <!-- <img :src={{ this.comic.imagen }} class="card-img-top" alt="comic"> -->
        <div class="card-body">
            <h5 class="card-title">{{ this.comic.titulo }}</h5>
            <p class="card-text">{{ this.comic.descripcion }}</p>            
        </div>
    </div>
  </div>
</template>

<script>
export default {
    props: ['comic']
}
</script>

<style>

</style>