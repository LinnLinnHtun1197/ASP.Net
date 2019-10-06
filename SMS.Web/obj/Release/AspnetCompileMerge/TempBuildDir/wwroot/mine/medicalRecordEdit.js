var dataDoctorChecking = [];
var dataMedicationPlan = [];
var dataMonitoringProgress = [];
var dataMedicalRecordItems = [];
var tblDoctorsChecking;
var tblMedicationPlan;
var tblMonitoringProgress;
var doctorCheckingEditIndex = -1;
var medicationEditIndex = -1;
var monitoringProgressEditIndex = -1;

function save() {
    if (!$("#frmPatient").valid() || !$("#frmRegistration").valid()) {
        return;
    }

    var data = getMedicalRecord();

    $.ajax({
        type: "POST",
        url: "/MedicalRecord/Edit",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        data: data,
        cache: false,
        success: function (data) {
            data = data.split(",");
            $("#spnRegistrationNo").text(data[0]);
            $("#spnPatientCode").text(data[1]);
            $("#divSuccess").modal('toggle');
        },
        error: function (xhr, status, error) {
            alert(xhr.responseText);
        }
    });
}

function setValidationRuleForPatient() {
    $("#frmRegistration").validate({
        ignore: "",
        rules: {
            txtRegistrationDate: {
                required: true,
                maxlength: 500
            },
        }
    });

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

function getMedicalRecord() {
    var medicalRecordItems = [];

    /* Vital Sign */
    if ($("#txtGCS").val())
        medicalRecordItems.push({ "Code": "GCS", "Value": $("#txtGCS").val(), "CodeType": "VitalSign", "UIReference": "txtGCS,Textbox" });

    if ($("#txtEye").val())
        medicalRecordItems.push({ "Code": "Eye", "Value": $("#txtEye").val(), "CodeType": "VitalSign", "UIReference": "txtEye,Textbox" });

    if ($("#txtVerbal").val())
        medicalRecordItems.push({ "Code": "Verbal", "Value": $("#txtVerbal").val(), "CodeType": "VitalSign", "UIReference": "txtVerbal,Textbox" });

    if ($("#txtMotor").val())
        medicalRecordItems.push({ "Code": "Motor", "Value": $("#txtMotor").val(), "CodeType": "VitalSign", "UIReference": "txtMotor,Textbox" });

    if ($("#txtTotal").val())
        medicalRecordItems.push({ "Code": "Total", "Value": $("#txtTotal").val(), "CodeType": "VitalSign", "UIReference": "txtTotal,Textbox" });

    if ($("#txtRightPupil").val())
        medicalRecordItems.push({ "Code": "RightPupil", "Value": $("#txtRightPupil").val(), "CodeType": "VitalSign", "UIReference": "txtRightPupil,Textbox" });

    if ($("#txtLeftPupil").val())
        medicalRecordItems.push({ "Code": "LeftPupil", "Value": $("#txtLeftPupil").val(), "CodeType": "VitalSign", "UIReference": "txtLeftPupil,Textbox" });

    if ($("#txtBloodPressure").val())
        medicalRecordItems.push({ "Code": "BloodPressure", "Value": $("#txtBloodPressure").val(), "CodeType": "VitalSign", "UIReference": "txtBloodPressure,Textbox" });

    if ($("#txtPulseRate").val())
        medicalRecordItems.push({ "Code": "PulseRate", "Value": $("#txtPulseRate").val(), "CodeType": "VitalSign", "UIReference": "txtPulseRate,Textbox" });

    if ($("#txtRespiratoryRate").val())
        medicalRecordItems.push({ "Code": "RespiratoryRate", "Value": $("#txtRespiratoryRate").val(), "CodeType": "VitalSign", "UIReference": "txtRespiratoryRate,Textbox" });

    if ($("#txtCentralReactionTime").val())
        medicalRecordItems.push({ "Code": "CentralReactionTime", "Value": $("#txtCentralReactionTime").val(), "CodeType": "VitalSign", "UIReference": "txtCentralReactionTime,Textbox" });

    if ($("#txtSaturationOfPeripheralOxygen").val())
        medicalRecordItems.push({ "Code": "SaturationOfPeripheralOxygen", "Value": $("#txtSaturationOfPeripheralOxygen").val(), "CodeType": "VitalSign", "UIReference": "txtSaturationOfPeripheralOxygen,Textbox" });

    if ($("#txtRandomBloodSugar").val())
        medicalRecordItems.push({ "Code": "RandomBloodSugar", "Value": $("#txtRandomBloodSugar").val(), "CodeType": "VitalSign", "UIReference": "txtRandomBloodSugar,Textbox" });

    if ($("#txtTemperature").val())
        medicalRecordItems.push({ "Code": "Temperature", "Value": $("#txtTemperature").val(), "CodeType": "VitalSign", "UIReference": "txtTemperature,Textbox" });

    if ($("#txtLastMenstrualPeriod").val())
        medicalRecordItems.push({ "Code": "LastMenstrualPeriod", "Value": $("#txtLastMenstrualPeriod").val(), "CodeType": "VitalSign", "UIReference": "txtLastMenstrualPeriod,Textbox" });

    if ($("#txtElectrocardiogram").val())
        medicalRecordItems.push({ "Code": "Electrocardiogram", "Value": $("#txtElectrocardiogram").val(), "CodeType": "VitalSign", "UIReference": "txtElectrocardiogram,Textbox" });

    /* Relevant History and Findings */
    if ($("#txtGeneral").val())
        medicalRecordItems.push({ "Code": "General", "Value": $("#txtGeneral").val(), "CodeType": "RelevantHistoryFindings", "UIReference": "txtGeneral,Textarea" });

    if ($("#txtHeart").val())
        medicalRecordItems.push({ "Code": "Heart", "Value": $("#txtHeart").val(), "CodeType": "RelevantHistoryFindings", "UIReference": "txtHeart,Textarea" });

    if ($("#txtLungs").val())
        medicalRecordItems.push({ "Code": "Lungs", "Value": $("#txtLungs").val(), "CodeType": "RelevantHistoryFindings", "UIReference": "txtLungs,Textarea" });

    if ($("#txtAbdomen").val())
        medicalRecordItems.push({ "Code": "Adbomen", "Value": $("#txtAbdomen").val(), "CodeType": "RelevantHistoryFindings", "UIReference": "txtAbdomen,Textarea" });

    if ($("#txtRelevantEye").val())
        medicalRecordItems.push({ "Code": "RelevantEye", "Value": $("#txtRelevantEye").val(), "CodeType": "RelevantHistoryFindings", "UIReference": "txtRelevantEye,Textarea" });

    if ($("#txtNeurological").val())
        medicalRecordItems.push({ "Code": "Neurological", "Value": $("#txtNeurological").val(), "CodeType": "RelevantHistoryFindings", "UIReference": "txtNeurological,Textarea" });

    /* ED-Airway */
    if ($('#chkED_Airway_None').is(":checked"))
        medicalRecordItems.push({ "Code": "None", "Value": $('#chkED_Airway_None').is(":checked"), "CodeType": "ED_Airway", "UIReference": "chkED_Airway_None,Checkbox" });

    if ($('#chkED_Airway_Suction').is(":checked"))
        medicalRecordItems.push({ "Code": "Suction", "Value": $('#chkED_Airway_Suction').is(":checked"), "CodeType": "ED_Airway", "UIReference": "chkED_Airway_Suction,Checkbox" });

    if ($('#chkED_Airway_OPA').is(":checked"))
        medicalRecordItems.push({ "Code": "OPA", "Value": $('#chkED_Airway_OPA').is(":checked"), "CodeType": "ED_Airway", "UIReference": "chkED_Airway_OPA,Checkbox" });

    if ($('#chkED_Airway_NPA').is(":checked"))
        medicalRecordItems.push({ "Code": "NPA", "Value": $('#chkED_Airway_NPA').is(":checked"), "CodeType": "ED_Airway", "UIReference": "chkED_Airway_NPA,Checkbox" });

    if ($('#chkED_Airway_LMA').is(":checked"))
        medicalRecordItems.push({ "Code": "LMA", "Value": $('#chkED_Airway_LMA').is(":checked"), "CodeType": "ED_Airway", "UIReference": "chkED_Airway_LMA,Checkbox" });

    if ($('#chkED_Airway_ETT').is(":checked"))
        medicalRecordItems.push({ "Code": "ETT", "Value": $('#chkED_Airway_ETT').is(":checked"), "CodeType": "ED_Airway", "UIReference": "chkED_Airway_ETT,Checkbox" });

    if ($('#chkED_Airway_RSI').is(":checked"))
        medicalRecordItems.push({ "Code": "RSI", "Value": $('#chkED_Airway_RSI').is(":checked"), "CodeType": "ED_Airway", "UIReference": "chkED_Airway_RSI,Checkbox" });

    if ($('#chkED_Airway_Ccollar').is(":checked"))
        medicalRecordItems.push({ "Code": "Ccollar", "Value": $('#chkED_Airway_Ccollar').is(":checked"), "CodeType": "ED_Airway", "UIReference": "chkED_Airway_Ccollar,Checkbox" });

    /* ED-Breathing */
    if ($('#chkED_Breathing_None').is(":checked"))
        medicalRecordItems.push({ "Code": "None", "Value": $('#chkED_Breathing_None').is(":checked"), "CodeType": "ED_Breathing", "UIReference": "chkED_Breathing_None,Checkbox" });

    if ($('#chkED_Breathing_NasalCatheter').is(":checked"))
        medicalRecordItems.push({ "Code": "NasalCatheter", "Value": $('#chkED_Breathing_NasalCatheter').is(":checked"), "CodeType": "ED_Breathing", "UIReference": "chkED_Breathing_NasalCatheter,Checkbox" });

    if ($('#chkED_Breathing_Mask').is(":checked"))
        medicalRecordItems.push({ "Code": "Mask", "Value": $('#chkED_Breathing_Mask').is(":checked"), "CodeType": "ED_Breathing", "UIReference": "chkED_Breathing_Mask,Checkbox" });

    if ($('#chkED_Breathing_BagValueMask').is(":checked"))
        medicalRecordItems.push({ "Code": "BagValueMask", "Value": $('#chkED_Breathing_BagValueMask').is(":checked"), "CodeType": "ED_Breathing", "UIReference": "chkED_Breathing_BagValueMask,Checkbox" });

    if ($('#chkED_Breathing_VentilatorVolRate').is(":checked"))
        medicalRecordItems.push({ "Code": "VentilatorVolRate", "Value": $('#chkED_Breathing_VentilatorVolRate').is(":checked"), "CodeType": "ED_Breathing", "UIReference": "chkED_Breathing_VentilatorVolRate,Checkbox" });

    /* ED-Circulation */
    if ($('#chkED_Circulation_IV1').is(":checked"))
        medicalRecordItems.push({ "Code": "IV1", "Value": $('#chkED_Circulation_IV1').is(":checked"), "CodeType": "ED_Circulation", "UIReference": "chkED_Circulation_IV1,Checkbox" });

    if ($('#chkED_Circulation_IV2').is(":checked"))
        medicalRecordItems.push({ "Code": "IV2", "Value": $('#chkED_Circulation_IV2').is(":checked"), "CodeType": "ED_Circulation", "UIReference": "chkED_Circulation_IV2,Checkbox" });

    /* ED */
    if ($("#txtNS").val())
        medicalRecordItems.push({ "Code": "NS", "Value": $("#txtNS").val(), "CodeType": "ED", "UIReference": "txtNS,Textbox" });

    if ($("#txtRL").val())
        medicalRecordItems.push({ "Code": "RL", "Value": $("#txtRL").val(), "CodeType": "ED", "UIReference": "txtRL,Textbox" });

    if ($("#txtDS").val())
        medicalRecordItems.push({ "Code": "DS", "Value": $("#txtDS").val(), "CodeType": "ED", "UIReference": "txtDS,Textbox" });

    if ($("#txtBlood").val())
        medicalRecordItems.push({ "Code": "Blood", "Value": $("#txtBlood").val(), "CodeType": "ED", "UIReference": "txtBlood,Textbox" });

    /* IVX */
    if ($("#txtXRayChest").val())
        medicalRecordItems.push({ "Code": "X-ray Chest", "Value": $("#txtXRayChest").val(), "CodeType": "IVX", "UIReference": "txtXRayChest,Textbox" });

    if ($("#txtXRayABD").val())
        medicalRecordItems.push({ "Code": "X-ray ABD", "Value": $("#txtXRayABD").val(), "CodeType": "IVX", "UIReference": "txtXRayABD,Textbox" });

    if ($("#txtUSG").val())
        medicalRecordItems.push({ "Code": "USG (Abd)", "Value": $("#txtUSG").val(), "CodeType": "IVX", "UIReference": "txtUSG,Textbox" });

    if ($("#txtABD").val())
        medicalRecordItems.push({ "Code": "ABD CT Scan (head)", "Value": $("#txtABD").val(), "CodeType": "IVX", "UIReference": "txtABD,Textbox" });

    /* Lab */
    if ($("#txtUrea").val())
        medicalRecordItems.push({ "Code": "Urea", "Value": $("#txtUrea").val(), "CodeType": "Lab", "UIReference": "txtUrea,Textbox" });

    if ($("#txtCreatitine").val())
        medicalRecordItems.push({ "Code": "Creatitine", "Value": $("#txtCreatitine").val(), "CodeType": "Lab", "UIReference": "txtCreatitine,Textbox" });

    if ($("#txtNa").val())
        medicalRecordItems.push({ "Code": "Na", "Value": $("#txtNa").val(), "CodeType": "Lab", "UIReference": "txtNa,Textbox" });

    if ($("#txtK").val())
        medicalRecordItems.push({ "Code": "K", "Value": $("#txtK").val(), "CodeType": "Lab", "UIReference": "txtK,Textbox" });

    if ($("#txtCI").val())
        medicalRecordItems.push({ "Code": "CI", "Value": $("#txtCI").val(), "CodeType": "Lab", "UIReference": "txtCI,Textbox" });

    if ($("#txtTrop").val())
        medicalRecordItems.push({ "Code": "Others", "Value": $("#txtTrop").val(), "CodeType": "Lab", "UIReference": "txtTrop,Textbox" });

    if ($("#txtUSG").val())
        medicalRecordItems.push({ "Code": "Trop", "Value": $("#txtUSG").val(), "CodeType": "Lab", "UIReference": "txtUSG,Textbox" });

    if ($("#txtCBP").val())
        medicalRecordItems.push({ "Code": "ABDCBP", "Value": $("#txtCBP").val(), "CodeType": "Lab", "UIReference": "txtCBP,Textbox" });

    if ($("#txtHb").val())
        medicalRecordItems.push({ "Code": "Hb", "Value": $("#txtHb").val(), "CodeType": "Lab", "UIReference": "txtHb,Textbox" });

    if ($("#txtUCG").val())
        medicalRecordItems.push({ "Code": "UCG", "Value": $("#txtUCG").val(), "CodeType": "Lab", "UIReference": "txtUCG,Textbox" });

    if ($("#txtBG").val())
        medicalRecordItems.push({ "Code": "BG", "Value": $("#txtBG").val(), "CodeType": "Lab", "UIReference": "txtBG,Textbox" });

    /* Consultation */
    if ($('#chkConsultation_Med').is(":checked"))
        medicalRecordItems.push({ "Code": "Med", "Value": $('#chkConsultation_Med').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_Med,Checkbox" });

    if ($('#chkConsultation_Sug').is(":checked"))
        medicalRecordItems.push({ "Code": "Sug", "Value": $('#chkConsultation_Sug').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_Sug,Checkbox" });

    if ($('#chkConsultation_ICU').is(":checked"))
        medicalRecordItems.push({ "Code": "ICU", "Value": $('#chkConsultation_ICU').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_ICU,Checkbox" });

    if ($('#chkConsultation_CCU').is(":checked"))
        medicalRecordItems.push({ "Code": "CCU", "Value": $('#chkConsultation_CCU').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_CCU,Checkbox" });

    if ($('#chkConsultation_Pead').is(":checked"))
        medicalRecordItems.push({ "Code": "Pead", "Value": $('#chkConsultation_Pead').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_Pead,Checkbox" });

    if ($('#chkConsultation_OG').is(":checked"))
        medicalRecordItems.push({ "Code": "OG", "Value": $('#chkConsultation_OG').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_OG,Checkbox" });

    if ($('#chkConsultation_ENT').is(":checked"))
        medicalRecordItems.push({ "Code": "ENT", "Value": $('#chkConsultation_ENT').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_ENT,Checkbox" });

    if ($('#chkConsultation_OMFU').is(":checked"))
        medicalRecordItems.push({ "Code": "OMFU", "Value": $('#chkConsultation_OMFU').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_OMFU,Checkbox" });

    if ($('#chkConsultation_NSU').is(":checked"))
        medicalRecordItems.push({ "Code": "NSU", "Value": $('#chkConsultation_NSU').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_NSU,Checkbox" });

    if ($('#chkConsultation_Eye').is(":checked"))
        medicalRecordItems.push({ "Code": "Eye", "Value": $('#chkConsultation_Eye').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_Eye,Checkbox" });

    if ($('#chkConsultation_Uro').is(":checked"))
        medicalRecordItems.push({ "Code": "Uro", "Value": $('#chkConsultation_Uro').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_Uro,Checkbox" });

    if ($('#chkConsultation_Ortho').is(":checked"))
        medicalRecordItems.push({ "Code": "Ortho", "Value": $('#chkConsultation_Ortho').is(":checked"), "CodeType": "Consultation", "UIReference": "chkConsultation_Ortho,Checkbox" });

    /* Medications */
    if ($("#txtPMH").val())
        medicalRecordItems.push({ "Code": "PHM", "Value": $("#txtPMH").val(), "CodeType": "Medications", "UIReference": "txtPMH,Textarea" });

    if ($("#txtPSH").val())
        medicalRecordItems.push({ "Code": "PSH", "Value": $("#txtPSH").val(), "CodeType": "Medications", "UIReference": "txtPSH,Textarea" });

    if ($("#txtMed").val())
        medicalRecordItems.push({ "Code": "Med", "Value": $("#txtMed").val(), "CodeType": "Medications", "UIReference": "txtMed,Textarea" });

    if ($("#txtAllergy").val())
        medicalRecordItems.push({ "Code": "Allergy", "Value": $("#txtAllergy").val(), "CodeType": "Medications", "UIReference": "txtAllergy,Textarea" });

    for (var i = 0; i < dataDoctorChecking.length; i++)
    {
        dataDoctorChecking[i].CheckedDateTime = dataDoctorChecking[i].CheckedDateTime.replace(/-/g, "").replace(/ /g, "").replace(/:/g, "");
    }

    for (var i = 0; i < dataMonitoringProgress.length; i++) {
        dataMonitoringProgress[i].MonitoredDateTime = dataMonitoringProgress[i].MonitoredDateTime.replace(/-/g, "").replace(/ /g, "").replace(/:/g, "");
    }

    var data = JSON.stringify({
        Id: $("#hidMedicalRecordId").val(),
        RegistrationNo: $("#txtRegistrationNo").val(),
        Version: $("#hidMedicalRecordVersion").val(),
        RegistrationDate: $("#txtRegistrationDate").val().replace(/-/g, "").replace(/ /g, "").replace(/:/g, ""),
        "PatientId": $("#hidPatientId").val(),
        "Patient.Id": $("#hidPatientId").val(),
        "Patient.Version": $("#hidPatientVersion").val(),
        "Patient.PatientCode": $("#hidPatientCode").val(),
        "Patient.Name": $("#txtName").val(),
        "Patient.Age": $("#txtAge").val(),
        "Patient.DOB": $("#txtDOB").val().replace(/-/g, "").replace(/ /g, "").replace(/:/g, ""),
        "Patient.Sex": $('input:radio[name=sex]:checked').val(),
        "Patient.City": $("#txtCity").val(),
        ArrivalTime: $("#txtArrivalTime").val().replace(/-/g, "").replace(/ /g, "").replace(/:/g, ""),
        TreatmentTime: $("#txtTreatmentTime").val().replace(/-/g, "").replace(/ /g, "").replace(/:/g, ""),
        DCTime: $("#txtDCTime").val().replace(/-/g, "").replace(/ /g, "").replace(/:/g, ""),
        TriageValue: $('input:radio[name=Triage]:checked').val(),
        TransportationValue: $('input:radio[name=Transportation]:checked').val(),
        OtherTransportation: $("#txtOtherTransportation").val(),
        ComeInByValue: $('input:radio[name=Comeinby]:checked').val(),
        ComeFrom: $("#txtFromHospital").val(),
        ComeReason: $("#txtReason").val(),
        Procedures: $("#txtProcedures").val(),
        DispositionValue: $('input:radio[name=disposition]:checked').val(),
        GeneralRemarks: $("#txtGeneralRemarks").val(),
        MedicalOfficerName: $("#txtMedicalOfficerName").val(),

        MedicalRecordItems: medicalRecordItems,
        DoctorCheckings: dataDoctorChecking,
        MedicationPlans: dataMedicationPlan,
        MonitoringProgresses: dataMonitoringProgress
    });

    return data;
}

function fillData() {
    for (var i = 0; i < dataMedicalRecordItems.length; i++) {
        var uiReference = dataMedicalRecordItems[i].UIReference.split(",");
        switch (uiReference[1]) {
            case "Textbox":
                $("#" + uiReference[0]).val(dataMedicalRecordItems[i].Value);
                break;

            case "Checkbox":
                $("#" + uiReference[0]).prop('checked', dataMedicalRecordItems[i].Value);
                break;

            case "Textarea":
                $("#" + uiReference[0]).html(dataMedicalRecordItems[i].Value.replace(/<br>/g, "\n"));
                break;
        }
    }
}

/* Doctor Checking */
function setValidationRuleForDoctorChecking() {
    $("#frmDoctorChecking").validate({
        ignore: "",
        rules: {
            txtCheckedDateTime: {
                required: true,
            },
            txtDoctor: {
                required: true,
            },
            txtRemarks: {
                required: true,
            },
        }
    });
}

function addDoctorChecking() {
    if (!$("#frmDoctorChecking").valid()) {
        return;
    }

    if (doctorCheckingEditIndex > -1) {
        dataDoctorChecking[doctorCheckingEditIndex].CheckedDateTime = $("#txtCheckedDateTime").val();
        dataDoctorChecking[doctorCheckingEditIndex].DoctorName = $("#txtDoctor").val();
        dataDoctorChecking[doctorCheckingEditIndex].Remarks = $("#txtRemarks").val();
    } else {
        var item = {
            "CheckedDateTime": $("#txtCheckedDateTime").val(),
            "DoctorName": $("#txtDoctor").val(),
            "Remarks": $("#txtRemarks").val()
        };

        dataDoctorChecking.push(item);
    }
    
    tblDoctorsChecking = bindDoctorChecking();
    $('#divDoctorsCheckModal').modal('toggle');
}

function bindDoctorChecking() {
    if (tblDoctorsChecking) {
        tblDoctorsChecking.destroy();
    }

    table = $("#tblDoctorsChecking").DataTable({
        "info": true,
        "filter": true,
        "pageLength": 20,
        "paging": false,
        "destory": true,
        "data": dataDoctorChecking,
        "bSort": false,
        "columns": [
            { data: "CheckedDateTime" },
            { data: "DoctorName" },
            { data: "Remarks" },
            {
                data: null,
                className: "center",
            },
            {
                data: null,
                className: "center",
            }],
        "createdRow": function (row, data, dataIndex) {
            $('td:eq(3)', row).html('<a data-toggle="modal" href="#divDoctorsCheckModal" onclick="clearDoctorCheckings(); editDoctorCheckings(' + dataIndex + ');"><span  class="glyphicon glyphicon-edit " aria-hidden="true"></span></a>');
            $('td:eq(4)', row).html('<a data-toggle="modal" href="#divDoctorCheckingDeleteConfirmation" onclick="setRemoveDoctorCheckingIndex(' + dataIndex + ')"><span class="glyphicon glyphicon-trash " aria-hidden="true"></span></a>');
            return row;
        },
    });

    return table;
}

function clearDoctorCheckings() {
    doctorCheckingEditIndex = -1;
    $("#txtCheckedDateTime").val('');
    $("#txtDoctor").val('');
    $("#txtRemarks").val('');
}

function editDoctorCheckings(rowIndex) {
    doctorCheckingEditIndex = rowIndex;
    var data = $('#tblDoctorsChecking').DataTable().rows().data();
    $("#txtCheckedDateTime").val(decodeData(data.rows(rowIndex).data()[0].CheckedDateTime));
    $("#txtDoctor").val(decodeData(data.rows(rowIndex).data()[0].DoctorName));
    $("#txtRemarks").val(decodeData(data.rows(rowIndex).data()[0].Remarks));
}

function setRemoveDoctorCheckingIndex(rowIndex) {
    doctorCheckingEditIndex = rowIndex;
}

function removeDoctorChecking() {
    dataDoctorChecking.splice(doctorCheckingEditIndex, 1);
    tblDoctorsChecking = bindDoctorChecking();
    $('#divDoctorCheckingDeleteConfirmation').modal('toggle');
}
/* Doctor Checking */

/* Medication */
function setValidationRuleForMedication() {
    $("#frmMedicationPlan").validate({
        ignore: "",
        rules: {
            txtMedicatedDate: {
                required: true,
            },
            selDrug: {
                required: true,
            },
            txtDose: {
                required: true,
            },
            txtRoute: {
                required: true,
            },
        }
    });
}

function addMedication() {
    if (!$("#frmMedicationPlan").valid()) {
        return;
    }

    if (medicationEditIndex > -1) {
        dataMedicationPlan[medicationEditIndex].MedicatedDate = $("#txtMedicatedDate").val();
        dataMedicationPlan[medicationEditIndex].Drug = $("#selDrug").val();
        dataMedicationPlan[medicationEditIndex].Dose = $("#txtDose").val();
        dataMedicationPlan[medicationEditIndex].Route = $("#txtRoute").val();
        dataMedicationPlan[medicationEditIndex].Remarks = $("#txtMedicationRemarks").val();
    } else {
        var item = {
            "MedicatedDate": $("#txtMedicatedDate").val(),
            "Drug": $("#selDrug").val(),
            "Dose": $("#txtDose").val(),
            "Route": $("#txtRoute").val(),
            "Remarks": $("#txtMedicationRemarks").val()
        };

        dataMedicationPlan.push(item);
    }

    tblMedicationPlan = bindMedication();
    $('#divMedicationModal').modal('toggle');
}

function bindMedication() {
    if (tblMedicationPlan) {
        tblMedicationPlan.destroy();
    }

    table = $("#tblMedicationPlan").DataTable({
        "info": true,
        "filter": true,
        "pageLength": 20,
        "paging": false,
        "destory": true,
        "data": dataMedicationPlan,
        "bSort": false,
        "columns": [
            { data: "MedicatedDate" },
            { data: "Drug" },
            { data: "Dose" },
            { data: "Route" },
            { data: "Remarks" },
            {
                data: null,
                className: "center",
            },
            {
                data: null,
                className: "center",
            }],
        "createdRow": function (row, data, dataIndex) {
            $('td:eq(5)', row).html('<a data-toggle="modal" href="#divMedicationModal" onclick="clearMedication(); editMedication(' + dataIndex + ');"><span  class="glyphicon glyphicon-edit " aria-hidden="true"></span></a>');
            $('td:eq(6)', row).html('<a data-toggle="modal" href="#divMedicationDeleteConfirmation" onclick="setRemoveMedicationIndex(' + dataIndex + ')"><span class="glyphicon glyphicon-trash " aria-hidden="true"></span></a>');
            return row;
        },
    });

    return table;
}

function clearMedication() {
    medicationEditIndex = -1;
    $("#txtMedicatedDate").val('');
    $("#selDrug").val('');
    $("#txtDose").val('');
    $("#txtRoute").val('');
    $("#txtMedicationRemarks").val('');
}

function editMedication(rowIndex) {
    medicationEditIndex = rowIndex;
    var data = $('#tblMedicationPlan').DataTable().rows().data();
    $("#txtMedicatedDate").val(decodeData(data.rows(rowIndex).data()[0].MedicatedDate));
    $("#selDrug").val(decodeData(data.rows(rowIndex).data()[0].Drug));
    $("#txtDose").val(decodeData(data.rows(rowIndex).data()[0].Dose));
    $("#txtRoute").val(decodeData(data.rows(rowIndex).data()[0].Route));
    $("#txtMedicationRemarks").val(decodeData(data.rows(rowIndex).data()[0].Remarks));
}

function setRemoveMedicationIndex(rowIndex) {
    medicationEditIndex = rowIndex;
}

function removeMedication() {
    dataMedicationPlan.splice(medicationEditIndex, 1);
    tblMedicationPlan = bindMedication();
    $('#divMedicationDeleteConfirmation').modal('toggle');
}
/* Medication */

/* Monitoring and Progress */
function setValidationRuleForMonitoringProgress() {
    $("#frmMonitoringProgress").validate({
        ignore: "",
        rules: {
            txtMonitoredDateTime: {
                required: true,
            },
        }
    });
}

function addMonitoringProgress() {
    if (!$("#frmMonitoringProgress").valid()) {
        return;
    }

    if (monitoringProgressEditIndex > -1) {
        dataMonitoringProgress[monitoringProgressEditIndex].MonitoredDateTime = $("#txtMonitoredDateTime").val();
        dataMonitoringProgress[monitoringProgressEditIndex].BP = $("#txtBP").val();
        dataMonitoringProgress[monitoringProgressEditIndex].PR = $("#txtPR").val();
        dataMonitoringProgress[monitoringProgressEditIndex].RR = $("#txtRR").val();
        dataMonitoringProgress[monitoringProgressEditIndex].SpO2 = $("#txtSpO2").val();
        dataMonitoringProgress[monitoringProgressEditIndex].GCS = $("#txtMonitoringGCS").val();
        dataMonitoringProgress[monitoringProgressEditIndex].FluidTotal = $("#txtFluidTotal").val();
        dataMonitoringProgress[monitoringProgressEditIndex].UrineOutput = $("#txtUrineOutput").val();
        dataMonitoringProgress[monitoringProgressEditIndex].Antibiotic = $("#txtAntibiotic").val();
        dataMonitoringProgress[monitoringProgressEditIndex].PainKiller = $("#txtPainKiller").val();
        dataMonitoringProgress[monitoringProgressEditIndex].Remarks = $("#txtMonitoringProgressRemarks").val();
    } else {
        var item = {
            "MonitoredDateTime": $("#txtMonitoredDateTime").val(),
            "BP": $("#txtBP").val(),
            "PR": $("#txtPR").val(),
            "RR": $("#txtRR").val(),
            "SpO2": $("#txtSpO2").val(),
            "GCS": $("#txtMonitoringGCS").val(),
            "FluidTotal": $("#txtFluidTotal").val(),
            "UrineOutput": $("#txtUrineOutput").val(),
            "Antibiotic": $("#txtAntibiotic").val(),
            "PainKiller": $("#txtPainKiller").val(),
            "Remarks": $("#txtMonitoringProgressRemarks").val()
        };

        dataMonitoringProgress.push(item);
    }

    tblMonitoringProgress = bindMonitoringProgress();
    $('#divMonitoringProgress').modal('toggle');
}

function bindMonitoringProgress() {
    if (tblMonitoringProgress) {
        tblMonitoringProgress.destroy();
    }

    table = $("#tblMonitoringProgress").DataTable({
        "info": true,
        "filter": true,
        "pageLength": 20,
        "paging": false,
        "destory": true,
        "data": dataMonitoringProgress,
        "bSort": false,
        "columns": [
            { data: "MonitoredDateTime" },
            { data: "BP" },
            { data: "PR" },
            { data: "RR" },
            { data: "SpO2" },
            { data: "GCS" },
            { data: "FluidTotal" },
            { data: "UrineOutput" },
            { data: "Antibiotic" },
            { data: "PainKiller" },
            { data: "Remarks" },
            {
                data: null,
                className: "center",
            },
            {
                data: null,
                className: "center",
            }],
        "createdRow": function (row, data, dataIndex) {
            $('td:eq(11)', row).html('<a data-toggle="modal" href="#divMonitoringProgress" onclick="clearMonitoringProgress(); editMonitoringProgress(' + dataIndex + ');"><span  class="glyphicon glyphicon-edit " aria-hidden="true"></span></a>');
            $('td:eq(12)', row).html('<a data-toggle="modal" href="#divMonitoringProgressDeleteConfirmation" onclick="setRemoveMonitoringProgressIndex(' + dataIndex + ')"><span class="glyphicon glyphicon-trash " aria-hidden="true"></span></a>');
            return row;
        },
    });

    return table;
}

function clearMonitoringProgress() {
    monitoringProgressEditIndex = -1;
    $("#txtMonitoredDateTime").val('');
    $("#txtBP").val('');
    $("#txtPR").val('');
    $("#txtRR").val('');
    $("#txtSpO2").val('');
    $("#txtMonitoringGCS").val('');
    $("#txtFluidTotal").val('');
    $("#txtUrineOutput").val('');
    $("#txtAntibiotic").val('');
    $("#txtPainKiller").val('');
    $("#txtMonitoringProgressRemarks").val('');
}

function editMonitoringProgress(rowIndex) {
    monitoringProgressEditIndex = rowIndex;
    var data = $('#tblMonitoringProgress').DataTable().rows().data();
    $("#txtMonitoredDateTime").val(decodeData(data.rows(rowIndex).data()[0].MonitoredDateTime));
    $("#txtBP").val(decodeData(data.rows(rowIndex).data()[0].BP));
    $("#txtPR").val(decodeData(data.rows(rowIndex).data()[0].PR));
    $("#txtRR").val(decodeData(data.rows(rowIndex).data()[0].RR));
    $("#txtSpO2").val(decodeData(data.rows(rowIndex).data()[0].SpO2));
    $("#txtMonitoringGCS").val(decodeData(data.rows(rowIndex).data()[0].GCS));
    $("#txtFluidTotal").val(decodeData(data.rows(rowIndex).data()[0].FluidTotal));
    $("#txtUrineOutput").val(decodeData(data.rows(rowIndex).data()[0].UrineOutput));
    $("#txtAntibiotic").val(decodeData(data.rows(rowIndex).data()[0].Antibiotic));
    $("#txtPainKiller").val(decodeData(data.rows(rowIndex).data()[0].PainKiller));
    $("#txtMonitoringProgressRemarks").val(decodeData(data.rows(rowIndex).data()[0].Remarks));
}

function setRemoveMonitoringProgressIndex(rowIndex) {
    monitoringProgressEditIndex = rowIndex;
}

function removeMonitoringProgress() {
    dataMonitoringProgress.splice(monitoringProgressEditIndex, 1);
    tblMonitoringProgress = bindMonitoringProgress();
    $('#divMonitoringProgressDeleteConfirmation').modal('toggle');
}
/* Medication */

function decodeData(html) {
    var txt = document.createElement("textarea");
    txt.innerHTML = html;
    return txt.value;
}

