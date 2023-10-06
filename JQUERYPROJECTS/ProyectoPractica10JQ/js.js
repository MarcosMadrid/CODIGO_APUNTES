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
                        console.log("XML leido");                       
                    }
                });
            });


            function GetDepartamentos(){
                var request = "api/Departamentos"
                $.get(src_url + request,
                function (data) {
                    console.log("Peticion leyendo");
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

                        $("#tabla_dept").append(departamento_row);
                    });                     
                    
                    $(".Modificar").click(function (e) {                    
                        var row = this.parentNode.parentNode;
                        ModifyRow(row);
                    });

                    $(".Eliminar").click(function (e) { 
                        var id_dept = this.value; 
                        DELETEDepartamentos(id_dept);
                    });
                });
            }

            function PUTDepartamentos(id_dept){
                var request = "api/Departamentos";
                var nomb_dept_modificar = $("#nom_dept_row").val();
                    var loc_dept_modificar =  $("#loc_dept_row").val();
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

            function ModifyRow(row){                
                var cell_id = row.children[0];
                var cell_nombre = row.children[1];
                var cell_loc = row.children[2];
                var cell_buttons = row.children[3];

                $(row).addClass("selected");

                var input_nombre = $("<input>",{ "type": "text" , "placeholder" : cell_nombre.textContent , "id" : "nom_dept_row" });            
                $(cell_nombre).empty();
                $(cell_nombre).append(input_nombre);

                var input_loc = $("<input>",{ "type": "text" , "placeholder" : cell_loc.textContent , "id" : "loc_dept_row" });                              
                $(cell_loc).empty();
                $(cell_loc).append(input_loc);

                $(row).data("dept_row", { "nombre" : cell_nombre.textContent , "localidad" : cell_loc.textContent });  

                var accept_button = cell_buttons.children[0];
                accept_button.textContent = "Aceptar";
                $(accept_button).removeClass("Eliminar");
                $(accept_button).addClass("Acept");

                var cancel_button = cell_buttons.children[1];
                cancel_button.textContent = "Cancelar";
                $(cancel_button).removeClass("Modificar");
                $(cancel_button).addClass("Cancel");
                
                $(".Modificar").prop('disabled', true);
                $(".Eliminar").prop('disabled', true);
                
                $(".Acept").click(function (e) {                     
                    var row = this.parentNode.parentNode;
                    PUTDepartamentos(id_dept);
                });

                $(".Cancel").click(function (e) { 
                    var row = this.parentNode.parentNode;
                    CancelModify(row);
                });
            }

            function CancelModify(row){
                var cell_nombre = row.children[1];
                var cell_loc = row.children[2];
                var cell_buttons = row.children[3];

                var data_row = $(row).data("dept_row");
                var nombre = data_row.nombre;
                var loc = data_row.localidad;

                $(row).removeClass("selected");

                $(cell_nombre).empty();
                $(cell_nombre).append(nombre);

                $(cell_loc).empty();
                $(cell_loc).append(loc);  

                var delete_button = cell_buttons.children[0];
                delete_button.textContent = "Eliminar";
                $(delete_button).removeClass("Acept");
                $(delete_button).addClass("Eliminar");

                var modify_button = cell_buttons.children[1];
                modify_button.textContent = "Modificar";
                $(modify_button).removeClass("Cancel");
                $(modify_button).addClass("Modificar"); 

                $(".Modificar").prop('disabled', false)
                $(".Eliminar").prop('disabled', false)
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
