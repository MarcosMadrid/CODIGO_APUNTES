<template>
  <div>
    <h2>
        {{ nombre_deporte }}
    </h2>
    <button @click="Put_Favorito()">Favorito</button>
  </div>
</template>

<script>
export default {
    name:'HijoComponent',
    props: ['nombre_deporte'],
    methods: {
        Put_Favorito(){
            this.$emit("Set_Favorito", this.nombre_deporte);
        }
    }
}
</script>

<style>

</style>