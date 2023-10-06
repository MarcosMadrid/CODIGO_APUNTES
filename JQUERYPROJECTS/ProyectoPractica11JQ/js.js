$(document).ready(function () {
    var url = "https://apicruddoctoresxml.azurewebsites.net/";

    GETDoctoresXML();

    function GETDoctoresXML(){
        var request = "api/Doctores";

        $.get( url + request,
             function (data) {
                $.each($(data).find("Doctor"), function (i, doctor) { 
                     var row = $("<tr>");
                     $.each(doctor.children, function (y, nodo_doctor) { 
                        var colum = $("<td>",{"text" : nodo_doctor.textContent});
                        $(row).append(colum);
                     });
                     $("#tabla_doctores").append(row);                     
                });
            }
        );


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
            dataType: "text/xml",
            success: function (response) {
                
            }
        });
    }

    
});
