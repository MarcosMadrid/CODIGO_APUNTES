$(document).ready(function () {
    $("button").click(function (e) { 
        var fecha =  $($("input")[0]).val();
        var lista = fecha.split("/");
    
        $.each(lista, function (i, e) { 
             e = parseInt(e); 
        });
    
        if(lista[1] == 1){
            lista[1] = 13;
            lista[2] -= 1;
        }
        if(lista[1] == 2){
            lista[1] = 14;
            lista[2] -= 1;
        }
        
        paso1 = parseInt(((lista[1] + 1) * 3) / 5 );
        paso2 = parseInt((lista[2] / 4));
        paso3 = parseInt((lista[2] / 100));
        paso4 = parseInt((lista[2] / 400));
        paso5 = lista[0] + lista[1]*2  + lista[2] + paso1 + paso2 - paso3 + paso4 + 2;
        paso6 = parseInt(paso5/7)
        paso7 = paso5 - (paso6 * 7)
        resultado = paso7
        
        lista_dias = ["Sabado", "Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes"]
        alert(lista_dias[resultado])
        $("#resultado").innerText = lista_dias[resultado]
    });

    
    

});