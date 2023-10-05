$(document).ready(function () {
    $("#start").click(function () { 
        var tabla = $("<table>");
        $.get("../../Recursos/XML/alumnos.xml",
            function (data) {
            var title = $("<h1>",{"text":data.documentElement.tagName}) 
            $("body").append(title)            
            $.each(data.documentElement.children, function (i, children) {   
                var row = $("<tr>");
                $.each(children.attributes, function (y, value) { 
                    var colum = $("<td>", {
                         "text" : value.nodeValue
                        });
                    row.append(colum)
               });
                $.each(children.children, function (y, value) { 
                    var colum = $("<td>", { 
                        "text" : value.innerHTML
                    });
                    row.append(colum)                     
                });                
                $("#tabla").append(row);                  
            });
            }
        );
        $("body").append(tabla);   
    });

    $("#busqueda").keyup(function (e) { 
        var busqueda = this.value;
        
        if (busqueda == "") 
            return

        $.get("../../Recursos/XML/departamentos.xml",
        function (data) {
            $.each(data.documentElement.children, function (i, children) {   
                var filtros = []

                $.each(children.attributes, function (y, value) { 
                    var filtro = value.name + ":contains(" + busqueda + ")";
                    filtros.push(filtro);
               });

                $.each(children.children, function (y, value) {                     
                    var filtro =  value.tagName + ":contains(" + busqueda + ")";
                    filtros.push(filtro);
                }); 

                var final_results = []
                $.each(filtros, function (y, filtro) { 
                    $.each($(data).find(filtro), function (z, result) { 
                        final_results.push(result)
                    });
                });     
                ShowResult(final_results);             
            });
        });
    });

    function ShowResult(result){
        $.each(result, function (i, children) {   
            var row = $("<tr>");
            $.each(children.attributes, function (y, value) { 
                var colum = $("<td>", {
                     "text" : value.nodeValue
                    });
                row.append(colum)
           });
            $.each(result, function (y, value) { 
                var colum = $("<td>", { 
                    "text" : value.innerHTML
                });
                row.append(colum)                     
            });                
            $("#tabla").append(row);                  
        });
    }
});