<template>
  <div>
    <div v-if="method != undefined">
        <form v-if="method == 'post'" @submit="Submit_Personaje($event)">
            <div class="mb-3">
                <label for="Input_IdPersonaje" class="form-label">ID PERSONAJE</label>
                <input type="text" class="form-control" id="Input_IdPersonaje" aria-describedby="ID PERSONAJE">    
            </div>
            <div class="mb-3">
                <label for="Input_Nombre" class="form-label">NOMBRE</label>
                <input type="text" class="form-control" id="Input_Nombre" aria-describedby="Marca">    
            </div>
            <div class="mb-3">
                <label for="Input_Imagen" class="form-label">IMAGEN</label>
                <input type="text" class="form-control" id="Input_Imagen" aria-describedby="Modelo">    
            </div>            
            <select class="form-select text-center" aria-label="Default select example">
                <option v-for="serie in series" :key="serie" :value="serie.idSerie">     
                    {{ serie.nombre }}               
                </option>
            </select>
            <button type="submit" class="btn btn-success">Crear</button>
        </form>

        <form v-if="method == 'put'" @submit="Submit_Personaje($event)">
            <div class="mb-3">
                <label for="Input_IdPersonaje" class="form-label">ID PERSONAJE</label>
                <input type="text" class="form-control text-center" v-model="this.personaje.idPersonaje" id="Input_IdPersonaje" aria-describedby="ID PERSONAJE" disabled>    
            </div>
            <div class="mb-3">
                <label for="Input_Nombre" class="form-label">NOMBRE</label>
                <input type="text" class="form-control text-center" v-model="this.personaje.nombre" id="Input_Nombre" aria-describedby="Marca">    
            </div>
            <div class="mb-3">
                <div class="card ">
                <div class="card-header ">
                    <label for="Input_Imagen" class="form-label">IMAGEN</label>
                    <input type="text" class="form-control text-center" v-model="this.personaje.imagen" id="Input_Imagen" aria-describedby="Imagen">    
                </div>
                <div class="card-body justify-content-center">
                    <blockquote class="blockquote mb-0  h-50 w-50">
                    <img :src="this.personaje.imagen" class=" h-50 w-50">
                    </blockquote>
                </div>
            </div>
            </div>                        
            <select class="form-select text-center" aria-label="Default select example">
                <option v-for="serie in series" :key="serie" :value="serie.idSerie">     
                    {{ serie.nombre }}               
                </option>
            </select>
            <button type="submit" class="btn btn-success">Modificar</button>
        </form>

        <form v-if="method == 'detalles'">
            <div class="mb-3">
                <label for="Input_IdPersonaje" class="form-label">ID PERSONAJE</label>
                <input type="text" class="form-control text-center" v-model="this.personaje.idPersonaje" id="Input_IdPersonaje" aria-describedby="ID PERSONAJE" disabled>    
            </div>
            <div class="mb-3">
                <label for="Input_Nombre" class="form-label">NOMBRE</label>
                <input type="text" class="form-control text-center" v-model="this.personaje.nombre" id="Input_Nombre" aria-describedby="Marca">    
            </div>
            <div class="mb-3">
                <div class="card ">
                <div class="card-header ">
                    <label for="Input_Imagen" class="form-label">IMAGEN</label>
                    <input type="text" class="form-control text-center" v-model="this.personaje.imagen" id="Input_Imagen" aria-describedby="Imagen">    
                </div>
                <div class="card-body justify-content-center">
                    <blockquote class="blockquote mb-0  h-50 w-50">
                    <img :src="this.personaje.imagen" class=" h-50 w-50">
                    </blockquote>
                </div>
            </div>
            </div>                        
            <select class="form-select text-center" aria-label="Default select example">
                <option v-for="serie in series" :key="serie" :value="serie.idSerie">     
                    {{ serie.nombre }}               
                </option>
            </select>
            <button type="submit" class="btn btn-success">Modificar</button>
        </form>
  </div>
  </div>
</template>

<script>
import ServicesSeries from '../../services/ServicesSeries'
const service = new ServicesSeries();


export default {
    name: 'FormPersonaje',
    data(){
        return{
            personaje : {
                idPersonaje : null
            },
            series : [],
            method : null
        }
    },
    mounted(){
        this.personaje.idPersonaje = this.$route.params.id_personaje;        
        service.GET_Personaje(this.personaje.idPersonaje)
            .then(response=>{
                this.personaje = response.data;
            })
            .catch(error=>{
                console.log(error.message);
            });
        this.method = this.$route .params.method;
        
        service.GET_Series()
            .then(response=>{
                this.series = response.data;
            })
            .catch(error=>{
                console.log(error.message);
            });
    },
    methods:{
        Submit_Personaje(event){
            event.preventDefault();
            var form = event.target;

            this.personaje={
                idPersonaje:form[0].value,
                nombre:'',
                imagen:'',
                idSerie:''
            }
        }
    }
}
</script>

<style>

</style>