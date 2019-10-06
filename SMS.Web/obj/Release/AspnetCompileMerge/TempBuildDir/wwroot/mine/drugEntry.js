function save() {
    if (!$("#frmDrug").valid()) {
        return;
    }

    var data = getInputData();

    $.ajax({
        type: "POST",
        url: "/Drug/Entry",
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
    $("#frmDrug").validate({
        ignore: "",
        rules: {
            txtName: {
                required: true,
                maxlength: 500
            },
            txtDescription: {
                required: true,
            },
        }
    });
}

function getInputData() {
    var data = JSON.stringify({
        "Name": $("#txtName").val(),
        "Description": $("#txtDescription").val(),
        "ParentId": $("#hidParentCategoryId").val(),
        "Type": "Item",
    });

    return data;
}

