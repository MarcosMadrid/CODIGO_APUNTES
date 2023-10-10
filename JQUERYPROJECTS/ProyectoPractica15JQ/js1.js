$(document).ready(function () {
    var url_hospitalesAPI = "https://apicrudhospital.azurewebsites.net";
    GET_Hospitales();

    $("#btn_paginainsert").click(function (e) { 
        Swal.fire({
            title: 'Quieres ir a la siguiente página?',
            showDenyButton: true,
            showCancelButton: true,
            confirmButtonText: 'Ir',
            denyButtonText: `Cerrar`,
          }).then((result) => {
            /* Read more about isConfirmed, isDenied below */
            if (result.isConfirmed) {
                window.location= "http://127.0.0.1:5500/JQUERYPROJECTS/ProyectoPractica15JQ/pagina2.HTML";
            }
        });
    })


    function GET_Hospitales(){
        var request = "/webresources/hospitales"
        $.getJSON(url_hospitalesAPI + request,
            function (data) {
                $.each(data, function (index, hospitales) { 
                    var row = $("<tr>");
                    var scope = $("<th>",{ "scope" : "row" , "text" : index})
                    $(row).append(scope);

                    $.each(hospitales, function (indexInArray, hospital_data) { 
                        var cell = $("<td>",{"text" : hospital_data});                        
                        $(row).append(cell);
                    });

                    var btn_detalles = $("<button>" ,{ "text" : "Detalles" ,"class" : "btn btn-success" }); 
                    var btn_edit = $("<button>" ,{ "text" : "Editar", "class" : "btn btn-info"});
                    var btn_delete = $("<button>" ,{ "text" : "Eliminar", "class" : "btn btn-danger" , "value" : hospitales.idhospital})

                    btn_delete.click(function (e) { 
                        var idhospital = $(this).val();
                        Swal.fire({
                            title: 'Seguro que quieres eliminar hospital?',
                            showDenyButton: true,
                            showCancelButton: true,
                            confirmButtonText: 'Eliminar',                            
                          }).then((result) => {
                            if (result.isConfirmed) 
                                DELETE_Hospitales(idhospital);    
                        });
                                           
                    });

                    btn_detalles.click(function (e) { 
                        var idhospital = hospitales.idhospital                     
                        window.location= "http://127.0.0.1:5500/JQUERYPROJECTS/ProyectoPractica15JQ/pagina2.HTML?idhospital="+idhospital +"&detalles=true";
                        
                    });

                    btn_delete.click(function (e) { 
                        var idhospital = $(this).val();
                        DELETE_Hospitales(idhospital);                        
                    });

                    btn_edit.click(function (e) { 
                        var idhospital = hospitales.idhospital                     
                        window.location= "http://127.0.0.1:5500/JQUERYPROJECTS/ProyectoPractica15JQ/pagina2.HTML?idhospital="+idhospital + "&edit=true";                      
                    });


                    $(row).append(btn_detalles);
                    $(row).append(btn_edit);
                    $(row).append(btn_delete);
                    
                    $("#hospitales_tabla").append(row);
                });
            }
        );
    }

    function DELETE_Hospitales(idhospital){
        var request = "/webresources/hospitales/delete/" +idhospital;
        $.ajax({
            type: "DELETE",
            url: url + request,
            success: function (response) {
                Swal.fire({
                    icon: 'succes',
                    title: 'Todo correcto',
                    text: 'Hospital eliminado',
                  })
                GET_Hospitales();
            },
            error: function(response){
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Fallo al eliminar hospital',
                  })
            }
        });
    }

    function DETAILS_Hospital(idhospital) {  }


});