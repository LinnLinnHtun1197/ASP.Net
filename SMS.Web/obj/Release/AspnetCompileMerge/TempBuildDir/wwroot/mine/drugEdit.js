function save() {
    if (!$("#frmDrugCategory").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/DrugCategory/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function setValidationRule() {
    $("#frmDrugCategory").validate({
        ignore: "",
        rules: {
            txtName: {
                required: true,
            },
            txtDescription: {
                required: true,
            },
        }
    });
}

function getInputData() {
    var data = JSON.stringify({
        "Id": $("#hidId").val(),
        "Version": $("#hidVersion").val(),
        "Name": $("#txtName").val(),
        "Description": $("#txtDescription").val(),
        "ParentId": $("#hidParentCategoryId").val(),
        "Type": "Item",
    });

    return data;
}

