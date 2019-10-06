function setValidationRule() {

    $("#frmLogin").validate({
        rules: {
            txtName: {
                "required": true,
            },
            txtPassword: {
                "required": true,
            },
        }
    });

}

function Login() {
    if (!$("#frmLogin").valid()) {
        return;
    }
    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/User/LoginByUser",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#message").text("Login Successful");
                window.location = "/User/Index";
            } else {
                $("#message").text("UserName or Password is invalid");
            }
            $("#divError").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });

}


function getInputData() {
    return JSON.stringify({
        "Name": $("#txtName").val(),
        "Password": $("#txtPassword").val(),
    });
}

function enter(e) {
    e = e || window.event;
    if (e.keyCode == 13) {
        document.getElementById('btnSignIn').click();
        return false;
    }
    return true;
}
