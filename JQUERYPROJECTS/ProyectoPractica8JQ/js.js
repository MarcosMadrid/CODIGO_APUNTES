$(document).ready(function () {

    var categoria = ("#categorias");
    $.get("../../Recursos/XML/coches.xml",
        function (data) {
            var select_marca = $("<select>" , { "name" : "marcas"})
            
            $.each(data.documentElement.children, function (i, coche) {        
                   $.each(coche.children, function (y, datos_coche) { 
                     if(datos_coche.tagName == "marca"){
                        var option = $("<option>" , { 
                            "text": datos_coche.innerHTML , 
                            "value" : coche.attributes[0].value
                        });
                        $(select_marca).append(option);

                        $(select_marca).on("select", function () {
                            ShowResult(this.value)
                        });
                     }
                     $("body").append(select_marca)
                     });
                   });
            });                                               

    function ShowResult(marca){
        $.get("../../Recursos/XML/coches.xml",
        function (data) {
            var select_marca = $("<select>" , { "name" : "marcas"})
            
            $.each($(data).find("[marca =" + marca + "]"), function (i, coche) {        
                 
            });               

        
        var row = $("<tr>")
        $.each(alumno.children, function (i, alumno_data) { 
            var colum = $("<td>", {"text": alumno_data.innerHTML }) 
            $(row).append(colum);
        });
        return tabla.append(row)
    }
});