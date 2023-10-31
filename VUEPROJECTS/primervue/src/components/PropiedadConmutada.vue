<template>
  <div>
    <ul class="list-group">
        <li v-for="game in juegosRojos" :key="game" class="list-group-item" v-html="game">
        </li>
    </ul>
    <button @click="GenerarCard"> Generar Card</button>
    <ul>
        <li v-html="dataHtml"></li>    
    </ul>    
  </div>
</template>

<script>
export default {
    name: 'PropiedadConmutada',
    computed : {
        juegosRojos(){
            var datos = this.juegos;
            for (let index = 0; index < datos.length; index++) {
                var juego = datos[index];
                juego = "<span style='color:red'>" + juego+ "</span>";
                datos[index] = juego;                
            }
            return (datos);
        }
    },
    data(){
        return{
            juegos:[
                "Parchis", "Luz roja luz verde",
                "Canicas", "La galleta", "La cuerda"
            ],
            dataHtml : null
        }
    },
    methods:{
        GenerarCard(){
            this.dataHtml += "<div class='card' style='width: 18rem;'>"+
                                "<img src='...' class='card-img-top' alt='...'>"+
                                "<div class='card-body'>"+
                                    "<h5 class='card-title'>Elemento generado</h5>"+
                                    "<p class='card-text'>Some quick example text to build on the card title and make up the bulk of the card's content.</p>"+
                                    "<a href='#' class='btn btn-primary'>Go somewhere</a>"+
                                "</div>"+
                            "</div>"
        }

    }
}
</script>

<style>

</style>