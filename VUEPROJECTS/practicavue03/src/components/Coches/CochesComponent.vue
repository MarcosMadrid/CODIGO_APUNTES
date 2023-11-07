<template>
  <div>
    <h1>Coches</h1>
    <router-link to="/coche/post/" class="btn btn-outline-primary">Crear Coche</router-link>
    <table class="table" v-if="coches != null">
        <thead>
            <tr>
                <td v-for="key in Object.keys(coches[0])" :key="key">
                    {{ key.toUpperCase() }}
                </td>
            </tr>
        </thead>
        <tbody> 
            <tr v-for="coche in coches" :key="coche">
            
            <td v-for="(value, index_value) in Object.values(coche)" :key="value">             
                <img v-if="Object.keys(coche)[index_value] == 'imagen'" :src=coche.imagen style="{width: 70px; height: 70px;}" @error="Not_FoundIMG($event)">
                <span v-else>                    
                    {{ value }}                            
                </span>               
            </td>
            <router-link :to="'/coche/detalles/' + coche.idCoche" class="btn btn-outline-secondary">Detalles</router-link>
            <router-link :to="'/coche/put/' + coche.idCoche" class="btn btn-outline-success">Modificar</router-link>
            <button @click="DELETE_Coche(coche.idCoche)" class="btn btn-outline-danger">Eliminar</button>
            </tr>
        </tbody>
    </table>
  </div>
</template>

<script>
import ServicesCoches from './../../services/ServicesCoches';
import Loading_IMG from './../../assets/images/loading.gif'

const service = new ServicesCoches();
export default {
    name:'CochesComponent',
    data(){
        return{
            coches : null
        }
    },
    mounted(){
        service.GET_Coches().then(response=>{
            this.coches = response;
        })
    },
    methods:{
        DELETE_Coche(id_coche){
            this.$swal.fire({
                title: "Are you sure?",
                text: "You won't be able to revert this!",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Yes, delete it!"
                }).then((result) => {
                if (result.isConfirmed) {
                    service.DELETE_Coche(id_coche).then(respnse=>{
                        if(respnse.status == 200){
                            this.$swal.fire({
                            title: "Deleted!",
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
        },

        Not_FoundIMG(event){
            var img = event.target;
            img.src = Loading_IMG;
        }

    }
}
</script>

<style>

</style>