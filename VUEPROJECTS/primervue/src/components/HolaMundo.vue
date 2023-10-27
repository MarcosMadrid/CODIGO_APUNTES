<template>
    <div>
        <h1>PRIMERA APP Vue</h1>
        <h2>{{nombre}}</h2>
        <h3>{{ numero }}</h3>
    </div>
</template>

<script>
export default {
    name : 'HolaMundo',
    data(){
        return{
            nombre: "Marcos",
            numero : "12"
        }
    }
}
</script>

<style>
    @import './../assets/css/HonlaMundo.css';
</style>
