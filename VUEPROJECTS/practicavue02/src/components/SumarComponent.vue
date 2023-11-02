<template>
  <div>
    <h2>Numero Hijo {{ numero }}</h2>
    <button @click="Btn_Click()">Sumar</button>
  </div>
</template>

<script>
export default {
    data(){
        return{
            numero : parseInt(Math.random()*1000)
        }
    },
    methods :{
        Btn_Click(){
          this.$emit("acumular", this.numero);
        }
    }
}
</script>

<style>

</style>