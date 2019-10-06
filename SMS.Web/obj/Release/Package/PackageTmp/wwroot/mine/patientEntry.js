
function save() {
    if (!$("#frmPatient").valid()) {
        return;
    }

    var data = getPatient();

    $.ajax({
        type: "POST",
        url: "/Patient/Entry",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            $("#spnPatientCode").text(data);
            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function setValidationRuleForPatient() {
    $("#frmPatient").validate({
        ignore: "",
        rules: {
            txtName: {
                required: true,
                maxlength: 500
            },
            txtAge: {
                required: true,
            },
            txtDOB: {
                required: true,
                date: true,
            },
            txtCity: {
                maxlength: 1000
            },
        }
    });
}

function getPatient() {
    var data = JSON.stringify({
        "Name": $("#txtName").val(),
        "Age": $("#txtAge").val(),
        "DOB": $("#txtDOB").val().replace(/-/g, "").replace(/ /g, "").replace(/:/g, ""),
        "Sex": $('input:radio[name=sex]:checked').val(),
        "City": $("#txtCity").val(),
    });

    return data;
}

function decodeData(html) {
    var txt = document.createElement("textarea");
    txt.innerHTML = html;
    return txt.value;
}

