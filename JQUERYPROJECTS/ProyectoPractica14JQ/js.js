$(document).ready(function () {
    
    GET_Departamentos();
    GET_EMPLEADOS();


    function GET_Departamentos(){
        var url ="https://apicruddepartamentoscore.azurewebsites.net/api/Departamentos";
        $.getJSON(url, 
            function (data) {
                $.each(data, function (i, departamento) { 
                    var row = $("<tr>");
                    $.each(departamento, function (y, departamento_data) { 
                        var cell = $("<td>",{ 
                            "text" : departamento_data
                        });
                        $(row).append(cell);
                    });
                    var enlace = $("<td>", {
                        "text" : "Empleados" ,                                          
                    });

                    $(enlace).data("numero_dept", departamento.numero);
                    $(enlace).addClass("enlace");
                    $(row).append(enlace);

                    $("#departamentos").append(row);
                });

                $(".enlace").on("click", function () {
                    var departamento = $(this).data("numero_dept");
                    GET_Empleados_DEPT(departamento);
                });
            }
        );
    }



    function GET_Empleados_DEPT(departamento_numero){
        var request ="https://apiempleadosspgs.azurewebsites.net/api/Empleados/EmpleadosDepartamento/"+ departamento_numero;
        $.ajax({
            type: "GET",
            url:  request,
            contentType: "application/json",
            success: function (data) {
                $("#empleados").empty();
                $.each(data, function (i, empleado) {
                    var row = $("<tr>"); 
                     $.each(empleado, function (y, empleado_data) { 
                        var cell = $("<td>",{ "text" : empleado_data});
                        $(row).append(cell);
                     });      
                     $("#empleados").append(row);               
                });               
            },
        });
    }

    function GET_EMPLEADOS(){
        var request ="https://apiempleadosaction.azurewebsites.net/api/Empleados/GetOficios/oficios";
        $.ajax({
            type: "GET",
            url: request,
            contentType: "json",
            success: function (data) {
                $.each(data, function (i, oficio) {                      
                    var option = $("<option>",{ "text" : oficio , "value" : oficio});
                    $("#select_empleados_ofi").append(option);
                });

                $("#select_empleados_ofi").on("change", function () {
                    var oficio = $(this).val();
                    GET_EMPLEADOS_OFI(oficio);
                });

                $("#incrementar_salario").click(function (e) { 
                    var salario_extra = $("#incremento").val();
                    var oficio = $("#select_empleados_ofi").val();
                    IncrementarSalarioOficio(oficio, salario_extra);
                });
            }
            
        });
    }

    function GET_EMPLEADOS_OFI(oficio){
        var request = "https://apiempleadosaction.azurewebsites.net/api/Empleados/GetEmpleadosOficio/empleadosoficio/"+ oficio;
        $.getJSON(request,
            function (data) {
                $("#empleados_oficios").empty();
                $.each(data, function (index, empleados) { 
                    var row = $("<tr>");
                    $.each(empleados, function (indexInArray, empleado_data) { 
                       var cell = $("<td>",{"text" : empleado_data});
                       $(row).append(cell);
                    });
                    $("#empleados_oficios").append(row);
                });
            }
        );
    }

    function IncrementarSalarioOficio(oficio, incremento){
        request ="https://apiempleadosaction.azurewebsites.net/api/Empleados/IncrementarSalarioOficios/"+ oficio +"/" + incremento;
        $.ajax({
            type: "PUT",
            url: request,                        
            success: function (response) {
                Swal.fire({
                    icon: 'succes',
                    title: 'Datos guardados',
                  })
                GET_EMPLEADOS_OFI(oficio);
            },
            error: function(response){
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                  })
            }
        });
    }

});

