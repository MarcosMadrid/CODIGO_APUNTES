$(document).ready(function () {
    var tabla = $("<table>");
    var encabezados = [];


    $.get("../../Recursos/XML/clientes.xml",
    function (data) {            
            $(tabla).empty();
            encabezados = [];
            $.each(data.children, function (i, data_content) { 
                var encabezado_tabla = $("<tr>");
                $(tabla).append(encabezado_tabla);
                ExtractXML_tabla(data_content);
                EncabezadoTablaXML(encabezados, encabezado_tabla);
            });
            $("body").append(tabla);
        }
    );

        function ExtractXML_tabla(nodo){
            if(nodo.parentNode.nodeName == "#document"){
                var titulo  = $("<h1>" , {
                    "text":nodo.tagName
                });
                $("body").append(titulo);
            }

            var row = $("<tr>");
            
            $.each(nodo.attributes, function (i, nodo_atributo) { 
                var colum = $("<td>", {
                "text": nodo_atributo.value
                });
                $(row).append(colum);
                
                encabezados.push(nodo_atributo.name);                     
            }); 


            $.each(nodo.children , function (i, nodo_hijo) { 
                if(nodo_hijo.children.length > 0){     
                    EncabezadoTablaXML(encabezados, $(tabla).clone());
                    var titulo  = $("<h2>" , {
                        "text":nodo.tagName
                    });
                    encabezados = []               
                    
                    ExtractXML_tabla(nodo_hijo);                      
                }else{
                    var colum = $("<td>", {
                        "text": nodo_hijo.textContent
                     });
                    $(row).append(colum);  

                    encabezados.push(nodo_hijo.tagName);                             
                }
            });                
            $(tabla).append(row);
    }

    function EncabezadoTablaXML(encabezado, encabezado_tabla){
        encabezado = [... new Set(encabezado)]
        
        $.each(encabezado , function (i, texto) { 
            var colum = $("<th>", {
                "text": texto.toUpperCase()
             });
            $(encabezado_tabla).append(colum);           
        });
        return encabezado_tabla;
    }
});