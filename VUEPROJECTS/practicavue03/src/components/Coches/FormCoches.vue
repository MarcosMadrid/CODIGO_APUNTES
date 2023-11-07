<template>
  <div>
    <div v-if="type != undefined">
        <form v-if="type == 'post'" @submit="Submit_Coche($event)">
            <div class="mb-3">
                <label for="Input_IdCoche" class="form-label">ID COCHE</label>
                <input type="text" class="form-control" id="Input_IdCoche" aria-describedby="ID COCHE">    
            </div>
            <div class="mb-3">
                <label for="Input_Marca" class="form-label">MARCA</label>
                <input type="text" class="form-control" id="Input_Marca" aria-describedby="Marca">    
            </div>
            <div class="mb-3">
                <label for="Input_Modelo" class="form-label">MODELO</label>
                <input type="text" class="form-control" id="Input_Modelo" aria-describedby="Modelo">    
            </div>
            <div class="mb-3">
                <label for="Input_Conductor" class="form-label">CONDUCTOR</label>
                <input type="text" class="form-control" id="Input_Conductor" aria-describedby="Conductor">    
            </div>
            <div class="mb-3">
                <label for="Input_Imagen" class="form-label">IMAGEN</label>
                <input type="text" class="form-control" id="Input_Imagen" aria-describedby="Imagen">    
            </div>
            <button type="submit" class="btn btn-success">Crear</button>
        </form>

        <form v-if="type == 'put'" @submit="Submit_Coche($event)">
            <div class="mb-3">
                <label for="Input_IdCoche" class="form-label">ID COCHE</label>
                <input type="text" class="form-control" id="Input_IdCoche" v-model="this.coche.idCoche" aria-describedby="ID COCHE" disabled>    
            </div>
            <div class="mb-3">
                <label for="Input_Marca" class="form-label">MARCA</label>
                <input type="text" class="form-control" id="Input_Marca"  v-model="this.coche.marca" aria-describedby="Marca" >    
            </div>
            <div class="mb-3">
                <label for="Input_Modelo" class="form-label">MODELO</label>
                <input type="text" class="form-control" id="Input_Modelo"  v-model="this.coche.modelo" aria-describedby="Modelo" >    
            </div>
            <div class="mb-3">
                <label for="Input_Conductor" class="form-label">CONDUCTOR</label>
                <input type="text" class="form-control" id="Input_Conductor"  v-model="this.coche.conductor" aria-describedby="Conductor" >    
            </div>
            <div class="mb-3">
                <label for="Input_Imagen" class="form-label">IMAGEN</label>
                <input type="text" class="form-control" id="Input_Imagen"  v-model="this.coche.imagen" aria-describedby="Imagen">  
                <img :src="this.coche.imagen">  
            </div>
            <button type="submit" class="btn btn-success">Modificar</button>
        </form>

        <form v-if="type == 'detalles'">
            <div class="mb-3">
                <label for="Input_IdCoche" class="form-label">ID COCHE</label>
                <input type="text" class="form-control" id="Input_IdCoche" v-model="this.coche.idCoche" aria-describedby="ID COCHE" disabled>    
            </div>
            <div class="mb-3">
                <label for="Input_Marca" class="form-label">MARCA</label>
                <input type="text" class="form-control" id="Input_Marca"  v-model="this.coche.marca" aria-describedby="Marca" disabled>    
            </div>
            <div class="mb-3">
                <label for="Input_Modelo" class="form-label">MODELO</label>
                <input type="text" class="form-control" id="Input_Modelo"  v-model="this.coche.modelo" aria-describedby="Modelo" disabled>    
            </div>
            <div class="mb-3">
                <label for="Input_Conductor" class="form-label">CONDUCTOR</label>
                <input type="text" class="form-control" id="Input_Conductor"  v-model="this.coche.conductor" aria-describedby="Conductor" disabled>    
            </div>
            <div class="mb-3">
                <label for="Input_Imagen" class="form-label">IMAGEN</label>
                <input type="text" class="form-control" id="Input_Imagen"  v-model="this.coche.imagen" aria-describedby="Imagen" disabled>    
                <img :src="this.coche.imagen">
            </div>
            <router-link type="submit" to='/coches_servicios/' class="btn btn-success">Volver</router-link>
        </form>
  </div>
  </div>
</template>

<script>
import ServicesCoches from './../../services/ServicesCoches';

const service = new ServicesCoches();

export default {
    name : 'FormCoche',
    data(){
        return{
            coche :{
                idCoche: null,
                marca: null,
                modelo: null,
                conductor: null,
                imagen: null
            },
            type : null
        }
    },
    mounted(){
        this.type = this.$route.params.type;
        this.coche.idCoche = parseInt(this.$route.params.id_coche);
        if(this.type != 'post'){
            service.GET_Coche(this.coche.idCoche).then(response=>{
                this.coche = response;
            });            
        }
    },
    methods:{
        Submit_Coche(event){
            event.preventDefault();

            var form = event.target;

            this.coche.idCoche = parseInt(form[0].value);
            this.coche.marca =  form[1].value;
            this.coche.modelo =  form[2].value;
            this.coche.conductor =  form[3].value;
            this.coche.imagen =  form[4].value;
            console.log(this.coche)
            if(this.type == 'post'){
                service.CREATE_Coche(this.coche).then(response=>{
                    if(response.status == 200){
                        this.$swal.fire({
                            icon: "success",
                            title: "Coche creado",                            
                            footer: '<a href="/coches_servicios/" class="btn btn-primary" >Volver</a>'
                        });
                    }else{
                        this.$swal.fire({
                            icon: "error",
                            title: "Error al crear coche",       
                            text: response.message ,                     
                            footer: '<a href="/coches_servicios/" class="btn btn-primary" >Volver</a>'
                        });
                    }
                });
            }
            if(this.type == 'put'){
                this.$swal.fire({
                title: "Are you sure?",
                text: "You won't be able to revert this!",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Yes, modify it!"
                }).then((result) => {
                if (result.isConfirmed) {
                    service.UPDATE_Coche(this.coche).then(respnse=>{
                        if(respnse.status == 200){
                            this.$swal.fire({
                            title: "Coche Modificado!",
                            text: "Coche eliminado.",
                            icon: "success"
                        });
                        service.GET_Coches().then(response=>{
                            this.coches = response;
                        });
                        }
                    })                                        
                }
                }); 
                
            }
        }

    }

}
</script>

<style>

</style>