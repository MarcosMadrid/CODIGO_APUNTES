$(document).ready(function () {
    $("#start").click(function () { 
        var tabla = $("<table>");
        $.get("../../Recursos/XML/empleados.xml",
            function (data) {
            $.each($(data).find("APELLIDO"), function (i, value) {                     
                    var row = $("<tr>")
                    var c1 = $("<td>", { 
                        "text": value.innerHTML
                    });
                    row.append(c1);
                    $(tabla).append(row);           
            });
            }
        );
        $("body").append(tabla);   
    });
});