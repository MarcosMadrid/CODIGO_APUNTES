$(document).ready(function () {
    $.get("../../Recursos/XML/clientes.xml",
        function (data) {
            $.each($(data.children[0]).find("CLIENTE"), function (i, cliente) {    
                var button = $("<button>",{ 
                        "text" : "Cliente " + i ,
                        "value" : $(cliente).attr("IDCLIENTE")
                }) 
                $(button).data("idcliente", $(cliente).attr("IDCLIENTE"));

                button.click(function (e) { 
                    var idcliente = $(this).val();
                    $("#container_clientes").empty(); 
                    $.get("../../Recursos/XML/clientes.xml",
                    function (data) {                   
                        $.each($(data).find("CLIENTE[IDCLIENTE= "+ idcliente +"]"), function (i, cliente) {         
                            var lista = $("<ul>");       
                            $.each(cliente.children , function (i, nodo_hijo) { 
                                var li = $("<li>" , {"text" : nodo_hijo.tagName + ": "+  nodo_hijo.innerHTML.toUpperCase()});
                                $(lista).append(li);
                            });
                            $("#container_clientes").append(lista);                   
                        });  
                    });
                })
                $("#container_buttons").append(button);
                })
            });
});    
