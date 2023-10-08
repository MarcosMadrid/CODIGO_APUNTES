$(document).ready(function () {
    var url = "https://apicruddoctoresxml.azurewebsites.net/";

    GETDoctoresXML();

    function GETDoctoresXML(){
        var request = "api/Doctores";
        $("#tabla_doctores").empty();
        $.get( url + request,
             function (data) {
                $.each($(data).find("Doctor"), function (i, doctor) { 
                    var row = $("<tr>");
                    $.each(doctor.children, function (y, nodo_doctor) { 
                        var colum = $("<td>",{
                            "text" : nodo_doctor.textContent});
                        $(row).append(colum);
                    });
                    var IdDoctor =  $(doctor).find("IdDoctor").text();
                    var bt_modificar = $("<button>",{"text" : "Modificar" ,"value" : IdDoctor, "class" : "Modificar"});
                    var bt_eliminar = $("<button>",{"text" : "Eliminar" ,"value" : IdDoctor, "class" : "Eliminar"});
                                        
                    $(row).append(bt_modificar);
                    $(row).append(bt_eliminar);

                    $("#tabla_doctores").append(row); 
                });

                GET_Especialidades();

                $(".Modificar").click(function (e) { 
                    Boton_UPDATE(this);
                });

                $(".Eliminar").click(function (e) { 
                    DELETE_Doctor(this.value);
                });
            });
    }

    $("#botoninsert").click(function (e) { 
        var Apellido = $("#apellido_doct").val();
        var Especialidad = $("#especialidad_doct").val();
        var IdDoctor = $("#id_doct").val();
        var IdHospital = $("#id_hospital").val();
        var Salario = $("#salario_doct").val();

        var xml_doctor = Doctor_XML(Apellido,Especialidad,IdDoctor,IdHospital,Salario);

        CREATE_Doctor(xml_doctor);
    });

    $("#select_esp").change(function () { 
        var especialidad = this.value;
        if(especialidad == "Vacio"){
            GETDoctoresXML();   
        }else{
            GET_FilterEspecialidades(especialidad);
        }        
    });

    function Boton_UPDATE(bt_modificar){  
        var cell = bt_modificar.parentNode;

        $(bt_modificar).addClass("Modificar");

        var bt_aceptar = bt_modificar;
        bt_aceptar.textContent = "Aceptar";
        $(bt_cancelar).removeClass("Modificar");   
        $(bt_aceptar).addClass("Acept");
        $(".Acept").click(function (e) { 
                        
        });

        var bt_cancelar = cell.children[6];
        bt_cancelar.textContent = "Cancelar";
        $(bt_cancelar).removeClass("Eliminar");           
        $(bt_cancelar).addClass("Cancel"); 
        $(".Cancel").click(function (e) { 
            Boton_CANCEL(this);                
        });
    }
    
    function Boton_DELETE(IdDoctor){
        $(".Eliminar").click(function (e) { 
            var IdDoctor = this.value;
            DELETE_Doctor(IdDoctor);  
            GET_Especialidades();                      
        });
    }

    function Boton_CANCEL(bt_cancelar) {        
        var bt_aceptar = bt_cancelar.parentNode.children[5];

        bt_aceptar.textContent = "Modificar";
        $(bt_aceptar).removeClass("Acept");
        $(bt_aceptar).addClass("Modificar");

        bt_cancelar.textContent = "Eliminar";
        $(bt_cancelar).removeClass("Cancel");
        $(bt_cancelar).addClass("Eliminar");
    }

    function Doctor_XML(Apellido,Especialidad,IdDoctor,IdHospital,Salario){
        var dataXML = 
        "<Doctor>"
		+ "<Apellido>"+ Apellido +"</Apellido>"
		+ "<Especialidad>"+ Especialidad +"</Especialidad>"
		+ "<IdDoctor>"+ IdDoctor +"</IdDoctor>"
		+ "<IdHospital>"+ IdHospital +"</IdHospital>"
		+ "<Salario>"+ Salario +"</Salario>"
	    + "</Doctor>";

        return dataXML;
    }

    function CREATE_Doctor(dataXML){
        var request = "api/Doctores";
        $.ajax({
            type: "POST",
            url: url + request,
            data: dataXML,
            contentType: "text/xml",
            success: function (response) {
                GETDoctoresXML();
                GET_Especialidades();
            }
        });
    }

    function DELETE_Doctor(IdDoctor) {
        var request = "api/Doctores";
        $.ajax({
            type: "DELETE",
            url: url + request + "/" + IdDoctor,
            contentType: "text/xml",
            success: function (response) {
                GETDoctoresXML();
                GET_Especialidades();
            }
        });
    }

    function GET_Especialidades(){
        var request = "api/Doctores/Especialidades";
        $("#select_esp").empty();
        $("#select_esp").append(new Option ("Vacio","Vacio"));
        $.get(url + request,
            function (data) {
                $.each(data.children[0].children, function (i, especialidad) {                     
                    $("#select_esp").append( 
                        new Option (
                            $(especialidad).text(), 
                            $(especialidad).text()
                            )
                        );
                });
            }
        );
    }

    function GET_FilterEspecialidades(especialidad){
        var request = "api/Doctores/DoctoresEspecialidad/";
        $("#tabla_doctores").empty();
        $.get(url + request + especialidad,
            function (data) {              
                $.each($(data).find("Doctor"), function (i, doctor) { 
                    var row = $("<tr>");
                    $.each(doctor.children, function (y, nodo_doctor) { 
                        var colum = $("<td>",{
                            "text" : $(nodo_doctor).text()});
                        $(row).append(colum);
                    });
                    var IdDoctor =  $(doctor).find("IdDoctor").text();
                    var bt_eliminar = Boton_DELETE(IdDoctor);
                    $(row).append(bt_eliminar);
                    $("#tabla_doctores").append(row); 
                });                              
            }
        );
    }

    function UPDATE_Salario(){
        $.ajax({
            type: "PUT",
            url: url + request,
            data: "data",
            dataType: "text/xml",
            success: function (response) {
                
            }
        });
    }
    
});
