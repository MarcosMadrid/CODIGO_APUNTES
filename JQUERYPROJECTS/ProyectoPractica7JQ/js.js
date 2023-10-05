$(document).ready(function () {
    $("#start").click(function () { 
        var tabla = $("#tabla");
        $("#tabla").empty();
        var nota =  parseInt($("#busqueda").val())
        $.get("../../Recursos/XML/alumnos.xml",
            function (data) {
                alumnos = []
                $.each(data.documentElement.children, function (i, alumno) { 
                     if (parseInt(alumno.children[2].innerHTML) >= nota){
                        tabla = ShowResult(alumno,tabla);
                     }                    
                });                            
            });        
    });

    function ShowResult(alumno, tabla){
        var row = $("<tr>")
        $.each(alumno.children, function (i, alumno_data) { 
            var colum = $("<td>", {"text": alumno_data.innerHTML }) 
            $(row).append(colum);
        });
        return tabla.append(row)
    }
});