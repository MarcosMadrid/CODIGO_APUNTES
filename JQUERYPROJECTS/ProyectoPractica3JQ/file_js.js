$(document).ready(function () {
    for (let index = 0; index < 10; index++) {
        var numero = parseInt(Math.random()*500) + 1
        var button = $("<button>",{
            "type":"button",
            "text":numero
        });

        $(button).on("click", function () {
                Sumar(this)
        });

        $("body").append(button);
    }
    
    function Sumar(e){
        var valor = parseInt($(e).text());
        var total = parseInt($("#contador").text());

        if(isNaN(total))
            total = 0

        total += valor;
        $("#contador").text(total);
    }
});