
function setValidationRule() {
    $("#frmOrder").validate({
        rules: {
            txtOrder_Date: {
                required: true,
            },
            txtName: {
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
            txtDelivery_Address: {
                required: true,
            },
            txtTitle: {
                required: true,
            },
            txtQty: {
                required: true,
            },
            txtPrice: {
                required: true,
            },

        }
    });
}



function update() {
    if (!$("#frmOrder").valid()) {
        return;
    }
    var data = getInputDataForUpdate();
    $.ajax({
        type: "POST",
        url: "/Order/Edit",
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
                    $("#pFailureMessage").text("Order name is duplicated");
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
        "UserId": $("#txtFullAddress").val(),
        "TownshipId": $("#selTownship").val(),
        "Name": $("#txtName").val(),
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
        url: "/Order/Delete",
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




function getInputData() {
    var data = JSON.stringify({
        "CityId": $("#selCity").val(),
        "TownshipId": $("#selTownship").val(),
        "Name": $("#txtName").val(),
        "FullAddress": $("#txtFullAddress").val(),
        "PhoneNo": $("#txtPhoneNo").val(),
        "Email": $("#txtEmail").val(),
    });
    return data;
}





