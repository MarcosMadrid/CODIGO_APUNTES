<template>
  <div>

    <comic-select :comics_titulo="comics_titulo" v-on:selected_comics="Selected_Comics"/>

    <h1>Comics Seleccionados</h1>
    <ul class="position-relative my-auto">
        <li v-for="(comic,index) in selected_comics" :key="comic">
            <ComicComponent :comic="comic" v-on:seleccionar_favorito="SeleccionarFavorito" v-on:delete_comic="Delete_Comic" :index="index"/>
        </li>
    </ul>

    <h2>Favorito</h2>
    <div v-if="favorito != null">
        <div class="card" style="width: 18rem;">
            <img :src=this.favorito.imagen class="card-img-top" alt="comic">
            <div class="card-body">
                <h5 class="card-title">{{ this.favorito.titulo }}</h5>
                <p class="card-text">{{ this.favorito.descripcion }}</p>  
                <h3 :class="{rojo: this.favorito.year <=2000, verde: this.favorito.year > 200}">{{this.favorito.year}}</h3>      
                <button class="btn btn-danger" @click="Delete_Favorito">Quitar Favorito</button>                           
            </div>
        </div>
    </div>
    <p></p>
    <h2>Crear Comic</h2>
    <form @submit="SubmitComic($event)">
        <div class="mb-3">
            <label for="Input_Titulo" class="form-label">Titulo</label>
            <input type="text" class="form-control" id="Input_Titulo" aria-describedby="Nombre">       
        </div>
        <div class="mb-3">
            <label for="Input_Descripcion" class="form-label">Descripción</label>
            <input type="text" class="form-control" id="Input_Descripcion">
        </div>   
        <div class="mb-3">
            <label for="Input_Year" class="form-label">Año</label>
            <input type="date" class="form-control" id="Input_Year">
        </div>          
        <button type="submit" class="btn btn-primary">Crear</button>
    </form>
  </div>

</template>

<script>
import ComicComponent from './ComicComponent.vue';
import ComicSelect from './ComicSelect.vue';

export default {
    name: 'ComicsComponent',
    data() {
        return {
            comics: [
                {
                    titulo: "Spiderman",
                    imagen: "https://3.bp.blogspot.com/-i70Zu_LAHwI/T290xxduu-I/AAAAAAAALq8/8bXDrdvW50o/s1600/spiderman1.jpg",
                    descripcion: "Hombre araña",
                    year: 100
                },
                {
                    titulo: "Wolverine",
                    imagen: "https://images-na.ssl-images-amazon.com/images/I/51c1Q1IdUBL._SX259_BO1,204,203,200_.jpg",
                    descripcion: "Lobezno",
                    year: 121
                },
                {
                    titulo: "Guardianes de la Galaxia",
                    imagen: "https://cdn.normacomics.com/media/catalog/product/cache/1/thumbnail/9df78eab33525d08d6e5fb8d27136e95/g/u/guardianes_galaxia_guadianes_infinito.jpg",
                    descripcion: "Yo soy Groot",
                    year: 1021
                },
                {
                    titulo: "Avengers",
                    imagen: "https://d26lpennugtm8s.cloudfront.net/stores/057/977/products/ma_avengers_01_01-891178138c020318f315132687055371-640-0.jpg",
                    descripcion: "Los Vengadores",
                    year: 921
                },
                {
                    titulo: "Spawn",
                    imagen: "https://i.pinimg.com/originals/e1/d8/ff/e1d8ff4aeab5e567798635008fe98ee1.png",
                    descripcion: "Al Simmons",
                    year: 2000
                },
                {
                    titulo: "Batman",
                    imagen: "https://www.comicverso.com/wp-content/uploads/2020/06/The-Killing-Joke-657x1024.jpg",
                    descripcion: "Murcielago",
                    year: 2021
                }
            ]
            ,
            favorito: null
            ,
            formComic:null
            ,
            comics_titulo : []
            ,
            selected_comics:[]
        };
    },
    methods:{
        SeleccionarFavorito(comic){
            this.favorito = comic;
        },
        Delete_Favorito(){
            this.favorito = null;
        },
        Delete_Comic(index){
            this.comics.splice(index, 1);
        },
        SubmitComic(event){
            event.preventDefault();
            this.formComic = event.currentTarget;
            console.log(this.formComic);

            var titulo = this.formComic[0].value;
            var descripcion = this.formComic[1].value;
            var year = new Date(this.formComic[2].value).getFullYear();
            
            var comic ={
                titulo : titulo,
                descripcion: descripcion,
                imagen : "",
                year : year
            }
            this.Create_Comic(comic);
        },
        Create_Comic(comic){
            this.comics.push(comic);
            this.Comics_Titulo(comic.titulo);

        },
        Selected_Comics(comics_index){
            this.selected_comics = [];
            comics_index.forEach(comic_index => {
                this.selected_comics.push(this.comics[comic_index]);
            });            
        },
        Comics_Titulo(titulo){
            this.comics_titulo.push(titulo)            
        }
        
    },  
    mounted() {        
        this.comics.forEach(comic => {
            this.comics_titulo.push(comic.titulo)
        });
          
    },            
    components: { ComicComponent, ComicSelect }
}
</script>

<style>
    @import "./../assets/Comic.css";
    
</style>