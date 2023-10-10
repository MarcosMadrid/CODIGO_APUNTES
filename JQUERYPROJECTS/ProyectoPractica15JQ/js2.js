$(document).ready(function () {
var url = "https://apicrudhospital.azurewebsites.net/";
const params_url = new URL(window.location.href).searchParams;

    if (params_url.has('idhospital')){
        GET_Hospital(params_url.get('idhospital'));   
        if(params_url.has('edit')){
            $("#id_hospital").prop("disabled",true);
            $("#btn_insert_hospital").text("Modificar hospital");
        }
        if(params_url.has('detalles')){
            $("input").prop("disabled",true);
            $("#btn_insert_hospital").css("display","none");
        } 
    }
    
    $("#btn_insert_hospital").click(function (e) { 
        var idhospital = parseInt($("#id_hospital").val());
        var nombre = $("#nomb_hospital").val();
        var direccion = $("#dir_hospital").val();
        var telefono = $("#tel_hospital").val();
        var camas = parseInt($("#camas_hospital").val());

        var dataJson = HospitalesJson(idhospital,nombre,direccion,telefono,camas);
        var type = "POST";
        if(params_url.has('edit'))
            type ="PUT";

        UPDATE_Hospital(dataJson, type);        
    });

    function HospitalesJson(idhospital,nombre,direccion,telefono,camas){
        var hospital = new Object();

        hospital.idhospital = idhospital;
        hospital.nombre = nombre;
        hospital.direccion = direccion;
        hospital.telefono = telefono;
        hospital.camas = camas;

        return JSON.stringify(hospital);;
    }


    function UPDATE_Hospital(dataJson,type){
        var request = "webresources/hospitales/post";
        $.ajax({
            type: type,
            url: url + request,
            data: dataJson,
            contentType: "application/json",
            success: function (response) {
                Swal.fire({
                    icon: 'succes',
                    title: 'Todo correcto',
                    text: 'Hospital creado',
                    footer: '<button class="volver" >Volver a la página principal</button>'
                  })
            },
            error: function(response){
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Fallo al crear hospital',
                  })
            }
        });
    }

    function GET_Hospital(idhospital){
        var request = "webresources/hospitales/"+idhospital;
        $.getJSON(url+request,
            function (hospital) {
                $("#id_hospital").val(hospital.idhospital)
                $("#nomb_hospital").val(hospital.nombre)
                $("#dir_hospital").val(hospital.direccion);
                $("#tel_hospital").val(hospital.telefono);
                $("#camas_hospital").val(hospital.camas);
            }
        );
    }


});