function CreateDept(data, callBack) {
    var request = "/api/Departamentos/PostDepartamento";
    $.ajax({
        url: urlApiDept + request,
        type: "POST",
        contentType: "application/json",
        data: data,
        success: function (response) {
            console.log("Response:", response);
            callBack();
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}

function DeleteDept(data, callBack) {
    var request = "/api/Departamentos/DeleteDepartamento/" + data;
    $.ajax({
        url: urlApiDept + request,
        type: "DELETE",
        contentType: "application/json",        
        success: function (response) {
            console.log("Response:", response);
            callBack();
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}

function EditDept(data, callBack) {
    var request = "/api/Departamentos/PutDepartamento";
    $.ajax({
        url: urlApiDept + request,
        type: "PUT",
        contentType: "application/json",
        data: data,
        success: function (response) {
            console.log("Response:", response);
            callBack();
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}