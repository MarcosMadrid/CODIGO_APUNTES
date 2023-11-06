<template>
  <div>
    <h1>Empleados</h1>
    <form v-if="empleados.length != 0" @submit="Submit_Empleado($event)">
        <select class="select" v-model="idEmpleado" >
            <option v-for="empleado in empleados" :key="empleado" :value="empleado.idEmpleado">
                {{ empleado.apellido.toUpperCase() }}
            </option>
        </select>
        <button type="submit"> Buscar </button>
    </form>
    <div v-if="empleado != null">
        <table class="table" v-if="empleado != null">
        <thead>
            <tr>
                <td v-for="key in Object.keys(empleado)" :key="key">
                    {{ key.toUpperCase() }}
                </td>
            </tr>
        </thead>
        <tbody> 
            <tr>
            
            <td v-for="value in Object.values(empleado)" :key="value">                        
                {{ value }}                                            
            </td>
            </tr>
        </tbody>
    </table>
    </div>
  </div>
</template>

<script>
import ServiceEmpleado from '../../services/ServiceEmpleados';

const service = new ServiceEmpleado();

export default {
    name: 'EmpleadosDetalle',
    data(){
        return{
            empleados:[],
            empleado : null,
            idEmpleado : null
        }
    },
    methods:{
        Submit_Empleado(event){
            event.preventDefault();
            service.Get_Empleado(this.idEmpleado).then(response=>{
                this.empleado= response
            });              
        }
    },
    mounted(){    
        service.Get_Empleados().then(response=>{
                this.empleados= response
        });   
    }
}


</script>

<style>

</style>