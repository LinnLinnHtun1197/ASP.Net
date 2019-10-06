function setValidationRule() {

    $("#frmCategory").validate({
        rules: {
            txtName: {
                "required": true,
            },
            txtRemark: {
                "required": true,
            },

        }
    });

}

function save() {

    if (!$("#frmCategory").valid()) {
        return;
    }

    var data1 = getInputData();

    $.ajax({
        type: "POST",
        url: "/Category/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data1,
        cache: false,
        success: function (data) {
            if (data == "success") {
                $("#message").text("Saving is done");
            } else {
                $("#message").text("Saving is fail");
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
        "CreatedUserId": $("#CreatedUserId").val(),
        "Name": $("#txtName").val(),
        "Remark": $("#txtRemark").val(),
    });
    return data;
}

function fillData(selectedRelativeToStudent, selectedBranch, selectedGrade) {
    $("#selRelativeToStudent").val(selectedRelativeToStudent);
    $("#selBranch").val(selectedBranch);
    $("#selGrade").val(selectedGrade);

}

function update() {

    if (!$("#frmCategory").valid()) {
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
        url: "/Category/Delete",
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
