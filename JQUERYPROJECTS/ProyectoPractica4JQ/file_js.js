$(document).ready(function () {
    $("#rango_chk").on("change", function () {
        $("#contador").text("0");
        $("#contenedor_chk").empty();
        GenerarCheckBox(parseInt($(this).val()))
    });

    
    function GenerarCheckBox(qty){
        for (let index = 0; index < qty; index++) {
            var numero = parseInt(Math.random()*500) + 1
            var button = $("<input>",{
                "type":"checkbox",
                "value":numero
            });
    
            $(button).on("click", function () {
                var operacion = "restar"
                    if($(this).prop("checked"))
                        operacion = "sumar"
                    
                Operar(this, operacion)
            });
            $("#contenedor_chk").append(button);
        }
    }
    
    
    function Operar(e, operacion){
        var valor = parseInt($(e).val());
        var total = parseInt($("#contador").text());

        if(isNaN(total))
            total = 0

        if(operacion == "restar")
            valor = valor * -1

        total += valor;
        $("#contador").text(total);
    }
    
    $()
});