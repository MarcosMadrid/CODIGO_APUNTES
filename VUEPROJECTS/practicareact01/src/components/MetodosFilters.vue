<template>
  <div>
    <h1>Metodos Flter</h1>
    <ul>
        <li v-for="num in numeros" :key="num">
            {{  $filters.getNumeroDoble(num) }}
        </li>
    </ul>
    <ul>
        <li v-for="name in nombres" :key="name">
            {{ $filters.mayuscula(name) }}
        </li>
    </ul>
  </div>
</template>

<script>
export default {
    name: 'MetodosFilters',
    data(){
        return{
            numeros: [2,6,9,99,123,563],
            nombres: ["Adrian", "Lucia", "Marcos", "Madrid" , "Bejar"]
        }
    }
}
</script>

<style>

</style>