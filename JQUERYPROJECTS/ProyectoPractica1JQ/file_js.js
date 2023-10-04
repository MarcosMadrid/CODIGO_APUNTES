$(document).ready(function () {
    $("button").click(function (e) { 
        var list = []
        collection = $("input")
        $.each(collection, function (i,e) { 
                list.push(parseInt($(e).val())) 
        });

        list.sort(function(a, b) {
            return a - b;
          });          
          
        $.each($(".resultado"), function (i,e) { 
             e.innerText = list[i]
        });
    });
});

