<template>
  <div>
    <main v-if="this.serie != null">
        <section class="py-5 text-center container">
            <div class="row py-lg-5">
                <div class="col-lg-6 col-md-8 mx-auto">
                    <h1 class="fw-light">{{ this.serie.nombre.toUpperCase() }}</h1>             
                </div>
                <img :src="this.serie.imagen" alt="hola">
        </div>
        </section>

        <div class="album py-5 bg-body-tertiary">
        <div class="container">
            <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
                <div class="col" v-for="personaje in personajes" :key="personaje">
                    <div class="card shadow-sm">
                        <img class="bd-placeholder-img card-img-top" width="100%" height="265" :src="personaje.imagen" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice" focusable="false">                    
                        <div class="card-body">
                            <h4 class="card-text">{{ personaje.nombre.toUpperCase() }}</h4>
                            <div class="d-flex justify-content-between align-items-center">
                            <div class="btn-group">
                                <router-link type="button" :to="'/Series/personaje/detalles/' + personaje.idPersonaje" class="btn btn-sm btn-outline-secondary">View</router-link>
                                <router-link type="button" :to="'/Series/personaje/put/' + personaje.idPersonaje" class="btn btn-sm btn-outline-primary">Edit</router-link>
                                <button type="button" class="btn btn-sm btn-outline-danger">Delete</button>
                            </div>
                                <small class="text-body-secondary">{{ personaje.idPersonaje }}</small>
                            </div>
                        </div>
                    </div>
                </div>          
            </div>
        </div>
        </div>
    </main>
  </div>
</template>

<script>
import ServicesSeries from '../../services/ServicesSeries'
const service = new ServicesSeries();

export default {
    name : 'SerieDetalles',
    data(){
        return{
            serie : null,
            personajes : null
        }
    },
    mounted(){       
        service.GET_Serie(this.$route.params.id_serie)
            .then(response=>{
                this.serie = response.data;               
            })
            .catch(error=>{
                console.log(error.message);
            });

        service.GET_Personajes(this.$route.params.id_serie)
                .then(response=>{
                    this.personajes = response.data;
                })
                .catch(error=>{
                    console.log(error.message);
                }); 
    },
    watch:{
        '$route.params.id_serie'(nextVal, oldVal){
            if (nextVal != oldVal){

                service.GET_Serie(nextVal)
                    .then(response=>{
                        this.serie = response.data;
                    })
                    .catch(error=>{
                        console.log(error.message);
                    });

                service.GET_Personajes(nextVal)
                    .then(response=>{
                        this.personajes = response.data;
                    })
                    .catch(error=>{
                        console.log(error.message);
                    });           
            }
        }
    }
}
</script>

<style>

</style>