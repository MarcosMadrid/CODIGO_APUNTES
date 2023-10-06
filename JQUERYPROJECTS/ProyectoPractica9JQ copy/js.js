$(document).ready(function () {
            var src_url = "https://apicruddepartamentosxml.azurewebsites.net/";

            GetDepartamentos();
            $("#botoninsert").click(function (e) { 
                var dataXML = GetDepartamentoXML($("#id_dept").val() , $("#nom_dept").val(), $("#loc_dept").val());
                var request = "api/Departamentos"

                $.ajax({
                    type: "POST",
                    url: src_url + request,
                    data: dataXML,
                    contentType: "text/xml",
                    success: function (response) {
                        GetDepartamentos();
                        
                        $(".Modificar").click(function (e) { 
                            var request = "api/Departamentos";
                            $("#id_dept").val(id_dept); 
                            PUTDepartamentos(id_dept, request);
                        });
        
                        $(".Eliminar").click(function (e) { 
                            var id_dept =  $("#id_dept").val(); 
                            DELETEDepartamentos(id_dept);
                        });
                    }
                });

            });


            function GetDepartamentos(){
                var request = "api/Departamentos"
                $.get(src_url + request,
                function (data) {
                    console.log("Peticion leyendo")
                   $.each($(data).find("Departamento"), function (i, departamento) { 
                    var departamento_row = $("<tr>");
                    var id = "";
                     $.each(departamento.children, function (y, nodo_departamento) { 
                        var colum = $("<td>" , {"text" : nodo_departamento.textContent});
                        if(nodo_departamento.tagName == "IDDEPARTAMENTO")
                            id = nodo_departamento.textContent;
                        departamento_row.append(colum);                        
                     });
                     var buttonE = $("<button>",{"text" : "Eliminar" , "class" : "Eliminar" ,"value" : id });
                     var buttonM = $("<button>",{"text" : "Modificar" , "class" : "Modificar" ,"value" : id });
                     var colum = $("<td>");
                     colum.append(buttonE);
                     colum.append(buttonM);
                     departamento_row.append(colum);  
                     $("#tabla_clientes").append(departamento_row);
                   });                  
                }
                );
            }

            function PUTDepartamentos(id_dept, request){
                var nomb_dept_modificar = $("#nom_dept").val();
                    var loc_dept_modificar =  $("#loc_dept").val();
                    var dataXML = GetDepartamentoXML(id_dept, nomb_dept_modificar, loc_dept_modificar)

                    $.ajax({
                        type: "PUT",
                        url: src_url + request,
                        data: dataXML,
                        contentType: "text/xml",
                        success: function (response) {
                            console.log("Modificado")
                            GetDepartamentos()
                        }
                    });       
            }

            function DELETEDepartamentos(id_dept){
                var request = "api/Departamentos"
                var delete_dept = src_url + request +  +"/"+id_dept;

                $.ajax({
                    type: "DELETE",
                    url: delete_dept,
                    success: function (response) {
                        console.log("Eliminado")
                            GetDepartamentos()
                    }
                });
            }


            function GetDepartamentoXML(id_dept, nomb_dept, loc){
                var dataXML = 
                "<Departamento>"
                + "<IdDepartamento>"+ id_dept +"</IdDepartamento>"
                + "<Nombre>"+ nomb_dept +"</Nombre>"
                + "<Localidad>"+ loc +"</Localidad>"
                + "</Departamento>";

                return dataXML;
            }
            
        });
