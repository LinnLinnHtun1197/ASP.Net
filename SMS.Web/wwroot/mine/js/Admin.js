
function setValidationRule() {
    $("#frmUser").validate({
        rules: {

            txtName: {
                required: true,
            },
            txtPassword: {
                required: true,
            },
            txtDOB: {
                required: true,
            },
            txtNRC: {
                required: true,
            },
            txtFatherName: {
                required: true,
            },

            txtFullAddress: {
                required: true,
            },
            txtPhoneNo: {
                required: true,
            },
            txtEmail: {
                required: true,
            },


        }
    });
}

function save() {
    if (!$("#frmUser").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/AdminCRUD/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Saving is done");
                $("#divSuccess").modal('toggle');
            } else {
                if (data == "duplicate") {
                    $("#pFailureMessage").text("NRC is duplicated");
                } else {
                    $("#pMessage").text("Saving is fail");
                }
                $("#divFailure").modal('toggle');
            }
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function update() {
    if (!$("#frmUser").valid()) {
        return;
    }

    var data = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/AdminCRUD/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Updating is done");
                $("#divSuccess").modal('toggle');
            } else {
                if (data == "duplicate") {
                    $("#pFailureMessage").text("Branch name is duplicated");
                } else {
                    $("#pMessage").text("Updating is fail");
                }
                $("#divFailure").modal('toggle');
            }
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function getInputData() {
    var data = JSON.stringify({
        "CreatedUserId": $("#CreatedUserId").val(),
        "PositionId": $("#selPosition").val(),
        "Name": $("#txtName").val(),
        "Password": $("#txtPassword").val(),
        "DOB": $("#txtDOB").val().replace(/-/g, ''),
        "NRC": $("#txtNRC").val(),
        "Gender": $('input[name=rdoGender]:checked').val(),
        "FatherName": $("#txtFatherName").val(),

        "FullAddress": $("#txtFullAddress").val(),
        "PhoneNo": $("#txtPhoneNo").val(),
        "Email": $("#txtEmail").val(),

    });

    return data;
}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "UpdatedUserId": $("#UpdatedUserId").val(),
        "PositionId": $("#selPosition").val(),
        "Name": $("#txtName").val(),
        "Password": $("#txtPassword").val(),
        "DOB": $("#txtDOB").val().replace(/-/g, ''),
        "NRC": $("#txtNRC").val(),
        "Gender": $('input[name=rdoGender]:checked').val(),
        "FatherName": $("#txtFatherName").val(),
        "FullAddress": $("#txtFullAddress").val(),
        "PhoneNo": $("#txtPhoneNo").val(),
        "Email": $("#txtEmail").val(),

    });

    return data;
}


var id, version;
function setRemoveData(itemId, itemVersion) {
    id = itemId;
    version = itemVersion;
}

function remove() {
    var data = JSON.stringify({
        "Id": id,
        "Version": version,
    });

    $.ajax({
        type: "POST",
        url: "/AdminCRUD/Delete",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#pMessage").text("Deleting is done");
            } else {
                $("#pMessage").text("Deleting is fail");
            }

            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}
