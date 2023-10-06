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

                        $(select_marca).on("select", ShowResult(this.value));
                     }
                     $("body").append(select_marca)
                     });
                   });
            });                                               

    function ShowResult(option){
        $.get("../../Recursos/XML/coches.xml"),
        function (data) {       
            var coche = $(data).find("coche[idcoche =" + $(option).val() + "]");
            var modelo = $("<h3>" , { "text" : $(data).find("modelo") })       
            var marca = $("<h3>" , { "text" : $(data).find("modelo") })   
            var img = $("<img>" , { "text" : $(data).find("modelo") })     
            $("body").append(modelo);
            $("body").append(marca);
            $("body").append(img);                   
        }
    }
    
});