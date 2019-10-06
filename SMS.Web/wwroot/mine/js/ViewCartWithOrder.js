
function CheckUser() {
    var data = JSON.stringify({
        "Id": $("#UserId").val(),
    });

    $.ajax({
        type: "GET",
        url: "/User/CheckUser",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#message").text("order complete");
            } else {
                $("#message").text("Please Login to order");
                window.location = "/User/Login";
            }
            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });

}

