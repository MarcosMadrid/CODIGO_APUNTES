$(document).ready(function () {

    $.getJSON("../../Recursos/JSON/jugadores.json",
        function (data) {
            $.each(data.jugadores, function (i, jugador) { 
                var option = $("<option>",{
                    "text" : jugador.nombre , 
                    "value" : i
                });
                $("#select_esp").append(option);
            });
        }
    );

    $("#select_esp").change(function (e) { 
        var index = this.value;

        $.getJSON("../../Recursos/JSON/jugadores.json", 
            function (data) {
                var row = $("<tr>");
                $("#tabla_JUGADOR").empty();
                $.each(data.jugadores, function (i, jugador) { 
                    if(index == i){                       
                        var numero_cell = $("<td>",{"text" : jugador.numero});
                        var nombre_cell = $("<td>",{"text" : jugador.nombre});
                        var posi_cell = $("<td>",{"text" : jugador.posicion});
                        var edad_cell = $("<td>",{"text" : jugador.edad});
                        var img_cell = $("<td>").append($("<img>" , {"src"  : jugador.imagen , "load" : "lazy"}));
                        $(row).append(numero_cell);
                        $(row).append(nombre_cell);
                        $(row).append(posi_cell);
                        $(row).append(edad_cell);
                        $(row).append(img_cell);
                    }
                });
                $("#tabla_JUGADOR").append(row);
            }
        );
        
    });
    
});
