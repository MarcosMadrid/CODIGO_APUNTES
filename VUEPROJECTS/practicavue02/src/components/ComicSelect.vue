<template>
  <div>
    <select @input="Handle_Select($event)" class="form-select" aria-label="Comics" multiple>
        <option v-for="(titulo,index) in comics_titulo" :key="titulo" :value="index">    
            {{titulo}}       
        </option>
    </select>

  </div>
</template>

<script>
export default {
    name:'ComicSelect',
    props: ['comics_titulo'],
    data(){
        return{
            selected : null
        }
    },
    methods :{
        Handle_Select(event){
            event.preventDefault();
                
            var select = event.target
            var options = [...select.selectedOptions];
            var comics_index = []
            options.forEach((option) => {
                comics_index.push(option.value)
            });
            this.$emit('selected_comics', comics_index);
            
        }
    }

}
</script>

<style>

</style>