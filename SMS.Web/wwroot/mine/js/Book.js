function setValidationRule() {

    $("#frmBook").validate({
        rules: {
            txtBook_Title: {
                "required": true,
            },
            txtAuthor: {
                "required": true,
            },
            txtSummary: {
                "required": true,
            },
            txtQty: {
                "required": true,
            },
            txtPrice: {
                "required": true,
            },
            selCategory: {
                "required": true,
            },
        }
    });

}



function fillData(selectedPositionId) {
    $("#selCategory").val(selectedPositionId);

}

function update() {

    if (!$("#frmBook").valid()) {
        return;
    }

    var data1 = getInputDataForUpdate();

    $.ajax({
        type: "POST",
        url: "/Category/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data1,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#message").text("Updating is done");
            } else {
                $("#message").text("Updating is fail");
            }
            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });

}

function getInputDataForUpdate() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "UpdatedUserId": $("#UpdatedUserId").val(),
        "Name": $("#txtName").val(),
        "Remark": $("#txtRemark").val(),
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
        url: "/Book/Delete",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#message").text("Deleting is done");
            } else {
                $("#message").text("Deleting is fail");
            }
            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });

}
