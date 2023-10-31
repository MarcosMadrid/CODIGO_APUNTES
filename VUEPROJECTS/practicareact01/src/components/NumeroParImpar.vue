<template>
    <div>
        <input placeholder="inserte numero" type="number" v-model="numero" @input="IsPar"/>
        <hr>
        <ul>
            <li>
               <h1>Computed</h1>
                    <div v-html="Render_IsPar">
               </div>
           </li>
            <li>
                <h1>Method</h1>
                    <div v-html="htmlData">
                </div>
            </li>
           <li>
                <h1>Dynamic variable</h1>
                <div v-if="numero%2 == 0">
                    <h1>{{this.numero}} es Par </h1>
                </div>
                <div v-else>
                    <h1>{{this.numero}} es Impar </h1>
                </div>
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name:'NumeroParImpar',
    data(){
        return{
            numero : null,
            htmlData : null
        }
    },
    computed :{
        Render_IsPar(){
            if(this.numero%2 == 0){
                return("<h1>"+this.numero+" es Par </h1>");
            }else{
                return("<h1>"+this.numero+" es Impar </h1>");
            }
        }
    },
    methods :{
        IsPar(){
            if(this.numero%2 == 0){
                this.htmlData = ("<h1>"+this.numero+" es Par </h1>");
            }else{
                this.htmlData = ("<h1>"+this.numero+" es Impar </h1>");
            }
        }
    }
}
</script>

<style>

</style>