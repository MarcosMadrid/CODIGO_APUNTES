$(document).ready(function () {
    var url ="https://apicruddepartamentoscore.azurewebsites.net";
    GET_Departamentos();


    function GET_Departamentos(){
    var request = "/api/Departamentos";
    $.getJSON(url + request, 
        function (data) {
            $("#contenido").empty();
            $.each(data, function (i, child) { 
                var row = $("<tr>");
                $.each(child, function (y, data_child) { 
                    var cell = $("<td>", {"text" : data_child});
                    $(row).append(cell);
                });
                var btn_delete = $("<button>" , {"text" : "eliminar", "value" : child.numero});
                btn_delete.on("click", function () {
                    var id = this.value;
                    DELETE_Departamento(id);
                });

                $(row).append(btn_delete);
                $("#contenido").append(row);
            });
        })
    }

    $("#btn_insert").on("click", function () {
        var id = $("#cajaid").val();
        var nombre = $("#cajanombre").val();
        var localidad = $("#cajalocalidad").val();
        var dataJson = GENERARJson_Departamento(id, nombre, localidad);
        INSERT_Departamento(dataJson);
    });
    
    $("#btn_modificar").on("click", function () {
        var id = $("#cajaid").val();
        var nombre = $("#cajanombre").val();
        var localidad = $("#cajalocalidad").val();
        var dataJson = GENERARJson_Departamento(id, nombre, localidad);
        UPDATE_Departamento(dataJson);
    });

    function DELETE_Departamento(id_dept){
        var request = "/api/Departamentos/" + id_dept;
        $.ajax({
            type: "DELETE",
            url: url + request,
            success: function (response) {
                console.log("Eliminado");
                GET_Departamentos();
            }
        });
    }

    function INSERT_Departamento(data){
        var request = "/api/Departamentos";
        $.ajax({
            type: "POST",
            url: url + request,
            data: data,
            contentType: "application/json",
            success: function (response) {
                console.log("Datos subidos");
                GET_Departamentos();
            }
        });
    }

    function UPDATE_Departamento(data){
        var request = "/api/Departamentos";
        $.ajax({
            type: "PUT",
            url: url+ request,
            data: data,
            contentType: "application/json",
            success: function (response) {
                console.log("Dato Actualizado")
                GET_Departamentos();
            }
        });
    }

    function GENERARJson_Departamento(id, nombre, localidad){
        var departamento = new Object();

        departamento.numero = parseInt(id);
        departamento.nombre = nombre;
        departamento.localidad = localidad

        return JSON.stringify(departamento);
    }

});

