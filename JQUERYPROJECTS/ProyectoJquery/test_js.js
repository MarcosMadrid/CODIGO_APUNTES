// EJECUTA UNA VEZ SE CARGUE TODO EL DOCUENTO ASOCIADO
$(document).ready(function(){

    // ACCION DE ID
    $("#button1").click(function (e) { 
        alert("Prueba de test_js");
    });

    // ACCION DE CLASS
    $(".azul").click(function (e) { 
        alert("Has clicado algo azul");
    });

    // ACCION DE HIJOS DE UN ID (se puede hacer con cualquier cosa, similar a css)
    $("#lista_elementos li").click(function (e) { 
        alert(this.innerText);
    });

    // INTERCAMBIO DE IMAGENES MEDIANTE PLUGINS DE JQ Y ACCEDIENDO AL ATRIBUTO SRC
    $("#contenedor_de_img_mo img").mouseover(function (e) { 
        $(this).fadeOut(function (e){
            this.src ="imgs/img2.jfif"
            $(this).fadeIn();
        });
        this.alt = "Imagen bonita";        
    });
    $("#contenedor_de_img_mo img").mouseleave(function (e) { 
        $(this).fadeOut(function (e){
            this.src ="imgs/img1.jfif"
            $(this).fadeIn();
        });
        this.alt = "Imagen no bonita";
    });

    // EXTRAER VALORES DE ELEMENTOS
    $(".input_sm").change(function () { 
        var valor1 =  parseInt($($(".input_sm")[0]).val());
        var valor2 = parseInt($($(".input_sm")[1]).val());

        if(isNaN(valor1))
            valor1 = 0
        if(isNaN(valor2))
            valor2 = 0

        $("#resultado")[0].innerText = valor1 + valor2;
    });

    // GENERAR HIJOS A UN ELEMENTO CON BUCLE
    $(".tbl_multiplicar").change(function () { 
        var numero =  parseInt($($("#input_multiplicar")[0]).val());
        var qty = parseInt($($("#qty")[0]).val());

        if(isNaN(numero))
            numero = 0
        if(isNaN(qty))
            qty = 10
        
        $("#tabla_multiplicar").empty();
        for (let index = 1 ; index < qty + 1; index++) {            
            var row = $("<tr>")
            var c1 = $("<td>", { 
                "text": numero + " x " + index 
            });
            var c2 = $("<td>", { 
                "text": numero * index 
            });

            row.append(c1);
            row.append(c2);
            $("#tabla_multiplicar").append(row);
        }
    });

    // GENERADOR DE ELEMENTOS SEGÚN EL DATO DE OTRO ELEMENTO
    $("#rango_imgs").change(function (e) { 
        var numero = parseInt($(this).val());

        if(isNaN(numero))
            numero = 0

        $("#contenedor_img").empty();
        for (let index = 0 ; index < numero ; index++) {  
            var img = $("<img>", {
                "src": "imgs/img1.jfif"
            });
            $("#contenedor_img").append(img);
        }          
    });

    // CAMBIA ESTILOS DE UN ELEMENTO CADA CIERTO INTERVALO
    $("#boton_colores").click(function (e) { 
        
        setInterval(ColoresRandom, 300); //  setInterval( function , milisgundos);

        function ColoresRandom(){
            var parrafos = $(".colores_p")
            parrafo = parrafos.length
            while (parrafo >= parrafos.length) {
                parrafo = parseInt(Math.random()*10);
            }
            var colores = ["Orange" , "Red" , "Blue" , "Purple", "Yellow"]
            var color_random = colores.length
            while (color_random >= colores.length) {
                color_random = parseInt(Math.random()*10);
            }
            $(parrafos[parrafo]).css("color", colores[color_random]);
        }
    });

    $("#rango_imgs2").change(function (e) { 
        var numero = parseInt($(this).val());

        if(isNaN(numero))
            numero = 0

        $("#lista_img").empty();
        $("#contenedor_btn").empty();
        for (let index = 1 ; index < numero +1 ; index++) {  

            var img = $("<img>", {
                "src": "imgs/img1.jfif",
            });
            $(img).data("imagen",index);
            
            var btn = $("<button>", {
                "text": "boton "+ index,
                "class": "botones_imgs",
            });
            $(btn).data("boton",index);

            btn.on("click", function () {
                $.each($("#lista_img img"), function () { 
                    if($(this).data("imagen") == index){
                        $(this).attr("src", "imgs/img2.jfif");
                    } 
                });
            });

            $("#lista_img").append(img);
            $("#contenedor_btn").append(btn);
        }        
    });

   
    $(".botones_imgs").click(function () { 
        
    });
});

