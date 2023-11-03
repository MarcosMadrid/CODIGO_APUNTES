<template>
  <div>
    <div class="card" v-if="comic != null">        
        <img :src="this.comic.imagen" class="bd-placeholder-img card-img" height="940" role="img" aria-label="Placeholder: Card image" preserveAspectRatio="xMidYMid slice" focusable="false"/>            
    </div>    
  </div>
</template>

<script>

export default {
    name: 'ComicDetalles',
    data() {
        return {
            comic: null,
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
        };
    },
    mounted() {
        this.titulo = this.$route.params.titulo;
        this.comics.forEach(comic => {
            if(comic.titulo == this.titulo){
                this.comic = comic
            }
        });
    }
}
</script>

<style>

</style>