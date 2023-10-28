var Apis = {
    urlApuestasAPI : 'https://apiapuestas.azurewebsites.net/'
}

$(document).ready(function () {

    GET_Equipos();

    $("#input_buscar_jugadores").on("input", function (e) {
        e.preventDefault();
        GET_BuscarJugadores(e.currentTarget.value);
    });
});

    function GET_Equipos(){ 
        var request = '/api/equipos/';
        
        $.getJSON(Apis.urlApuestasAPI + request,
            function (data) {
                data.forEach(element => {
                    var dropdown_item = $("<li>");
                    var content_item = $("<a>", {
                        "text" : element.nombre.toUpperCase() ,      
                        "class" : "dropdown-item"
                    });
                    
                    $(content_item).click(function (e) { 
                        e.preventDefault();                             
                        var urlEquipo = window.location.toLocaleString().split("/")
                        urlEquipo.splice(-1,1, "PaginaEquipo.html");
                        urlEquipo = new URL(urlEquipo.join("/"));
                        var urlParams = new URLSearchParams(urlEquipo.search);
                        urlParams.set("equipo", element.idEquipo);
                        window.location = (urlEquipo + "?" + urlParams.toString());
                    });
                    
                    dropdown_item.append(content_item);
                    $("#dropdown-nav-equipos").append(dropdown_item);
                });
            }
        );
    }



    function GET_BuscarJugadores(busqueda){
        var request = "/api/jugadores/buscarjugadores/" + busqueda;

        $.ajax({
            type: "GET",
            url: Apis.urlApuestasAPI + request,
            success: function (response) {
                Render_TableJugadores(response);
            },
            error: function (response) {
                console.log(response)
            }
        });
    }

    function Render_TableJugadores(jugadores){
        $("#row-header-table").empty();
        $("#row-body-table").empty();

        $("#row-header-table").append($("<th>",{ "scope" : "col" , "text" : "#"}))
        Object.keys(jugadores[0]).map((key, index_key)=>{
            $("#row-header-table").append($("<th>",{ "scope" : "col" , "text" : key.toUpperCase()}));
        });

        jugadores.forEach((jugador, index )=> {
            var row = $("<tr>");
            row.append($("<th>",{"scope" : "row" , "text" : index}));
            Object.values(jugador).map((value , index)=>{
                row.append(
                        $("<td>",{
                            "text" : value
                        }))
            });   
            $("#row-body-table").append(row);
        });
    }
