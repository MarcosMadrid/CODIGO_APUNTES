<template>
  <div>
    <div v-if="type != undefined">

        <form @submit="Submit_Departamento($event)" v-if="type == 'post'">
            <div class="mb-3">
                <label for="Input_IdDepartamento" class="form-label">ID Departamento</label>
                <input type="text" class="form-control" id="Input_IdDepartamento" aria-describedby="Departamento">    
            </div>
            <div class="mb-3">
                <label for="Input_Nombre" class="form-label">Nombre</label>
                <input type="text" class="form-control" id="Input_Nombre" aria-describedby="Nombre">    
            </div>
            <div class="mb-3">
                <label for="Input_Localidad" class="form-label">Localidad</label>
                <input type="text" class="form-control" id="Input_Localidad" aria-describedby="Localidad">    
            </div>
            <button type="submit" class="btn btn-success">Crear</button>
        </form>

        <form @submit="Submit_Departamento($event)" v-if="type == 'put'">
            <div class="mb-3">
                <label for="Input_IdDepartamento" class="form-label disabled" >ID Departamento</label>
                <input type="text" v-model="departamento.idDepartamento" class="form-control disabled" id="Input_IdDepartamento" aria-describedby="Departamento" disabled>    
            </div>
            <div class="mb-3">
                <label for="Input_Nombre" class="form-label">Nombre</label>
                <input type="text"  v-model="departamento.nombre"  class="form-control" id="Input_Nombre" aria-describedby="Nombre">    
            </div>
            <div class="mb-3">
                <label for="Input_Localidad" class="form-label">Localidad</label>
                <input type="text"  v-model="departamento.localidad" class="form-control" id="Input_Localidad" aria-describedby="Localidad">    
            </div>
            <button type="submit" class="btn btn-success">Modificar</button>
        </form>

        <form v-if="type == 'detalles'">
              <div class="mb-3">
                <label for="Input_IdDepartamento" class="form-label disabled" >ID Departamento</label>
                <input type="text" v-model="departamento.idDepartamento" class="form-control disabled" id="Input_IdDepartamento" aria-describedby="Departamento" disabled>    
            </div>
            <div class="mb-3">
                <label for="Input_Nombre" class="form-label">Nombre</label>
                <input type="text"  v-model="departamento.nombre"  class="form-control" id="Input_Nombre" aria-describedby="Nombre" disabled>    
            </div>
            <div class="mb-3">
                <label for="Input_Localidad" class="form-label">Localidad</label>
                <input type="text"  v-model="departamento.localidad" class="form-control" id="Input_Localidad" aria-describedby="Localidad" disabled>    
            </div>
            <router-link type="submit" to="/Departamentos/" class="btn btn-secondary">Volver</router-link>
        </form>

    </div>    
  </div>
</template>

<script>
import ServicesDepartamentos from '../../services/ServicesDepartamentos';
const service = new ServicesDepartamentos();

export default {
    name : 'FormDepartamento',
    data(){
        return{
            departamento:{
                idDepartamento: null,
                nombre : null,
                localidad : null                
            },
            type : null
        }
    },
    methods : {
        Submit_Departamento(event){
            event.preventDefault();
            var form = event.target;
            var idDepartamento = form[0].value;
            var nombre = form[1].value;
            var localidad = form[2].value;

            this.departamento.idDepartamento = idDepartamento;
            this.departamento.nombre = nombre;
            this.departamento.localidad = localidad;

            if(this.type == 'post'){
                service.INSERT_Departamento(this.departamento);
            }
            if(this.type == 'put'){               
                service.UPDATE_Departamento(this.departamento);
            }
            

            this.$route.push("/Departamentos/");
        }
    },
    mounted(){    
        this.type = this.$route.params.type;
        if(this.type != 'post'){
            service.GET_Departamento(this.$route.params.id_departamento).then(response=>{
                this.departamento = response;
            });
           
        }
    }
}
</script>

<style>

</style>