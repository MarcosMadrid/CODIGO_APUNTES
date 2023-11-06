<template>
  <div>
    <h1>DEPT</h1>
    <router-link to="/FormDepartamento/post" class="btn btn-primary">CreateDepartamento</router-link>
    <img v-if="departamentos.length == 0" src="./../../assets/images/loading.gif">
    <div v-if="departamentos.length != 0">
        <table class="table" v-if="departamentos.length != 0">
        <thead>
            <tr>
                <td v-for="key in Object.keys(departamentos[0])" :key="key">
                    {{ key.toUpperCase() }}
                </td>
            </tr>
        </thead>
        <tbody> 
            
            <tr v-for="departamento in departamentos" :key="departamento">                             
                <td v-for="value in Object.values(departamento)" :key="value">                        
                    {{ value }}                                            
                </td>
                <td> 
                    <router-link :to="'/FormDepartamento/put/' + departamento.idDepartamento" class="btn btn-success">Modificar</router-link>
                    <button @click="DELETE_Departamento(departamento.idDepartamento)" class="btn btn-danger">Eliminar</button>
                </td>
            </tr>
        </tbody>
    </table>
    </div>
  </div>
</template>

<script>
import ServicesDepartamentos from './../../services/ServicesDepartamentos';
const service = new ServicesDepartamentos();
export default {
    name:'DepartamentosComponent',
    data(){
        return{
            departamentos : []
        }
    },
    methods:{
        DELETE_Departamento(id_departamento){
            service.DELETE_Departamento(id_departamento);
            this.departamentos.forEach((departamento, index) => {
                if(id_departamento == departamento.idDepartamento)
                    this.departamentos.splice(index,1);
            });
        }        
    },
    mounted(){
        service.GET_Departamentos().then(response=>{
            this.departamentos= response;
        });
    }
}
</script>

<style>

</style>