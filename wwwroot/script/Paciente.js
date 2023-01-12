$(document).on("ready", init);

function init() {
    ListadoPacientes();
    $("#verFrmPaciente").hide();
    $("#verFrmDatRep").hide();
    $("#verListDatosRepresentantes").hide();
    $("#verListArchivosRep").hide();

    cboTipPac();
    cboTipIde();
    usuarioRegistrado();
    horaRegistro();
    ListadoRepresentantes();
    $("form#frmPaciente").submit(SaveorUpdatePaciente);
    $("form#frmDatRep").submit(SaveorUpdateRepresentantes);
    $("form#frmModRepAnexos").submit(SaveModRepAnexos);
    $("form#frmBusquedaPaciente").submit(BusquedaPaciente);

}

function ListadoPacientes() {
    $.post("./controller/PacienteController.php?op=list", function (r) {
        $("#listPacientes").html(r);
        $("#btnNuevoPaciente").show();

    });
}

function cboTipPac() {
    $.post("./controller/PacienteController.php?op=cboTipPac", function (data) {
        $("#cboTipPac").html(data);
    });
}

function cboTipIde() {
    $.post("./controller/PacienteController.php?op=cboTipIde", function (data) {
        $("#cboTipIde").html(data);
    });
}

/*
function calcularEdad() {

    //console.log(fecha.target.value);
   
    var hoy = new Date();
    var cumpleanos = new Date(fecha.target.value);
    var edad = hoy.getFullYear() - cumpleanos.getFullYear();
    var m = hoy.getMonth() - cumpleanos.getMonth();

    if (m < 0 || (m === 0 && hoy.getDate() < cumpleanos.getDate())) {
        edad--;
    }

    return $("#age").html(edad + " años");
}
*/

//calcular edad años meses y dias
function calcularEdad2() {
    // Si la fecha es correcta, calculamos la edad

    var fecha = $("#dateFecNac").val();
    if (typeof fecha != "string" && fecha && esNumero(fecha.getTime())) {
        fecha = formatDate(fecha, "yyyy-MM-dd");
    }

    var values = fecha.split("-");
    var dia = values[2];
    var mes = values[1];
    var ano = values[0];

    // cogemos los valores actuales
    var fecha_hoy = new Date();
    var ahora_ano = fecha_hoy.getYear();
    var ahora_mes = fecha_hoy.getMonth() + 1;
    var ahora_dia = fecha_hoy.getDate();

    // realizamos el calculo
    var edad = (ahora_ano + 1900) - ano;
    if (ahora_mes < mes) {
        edad--;
    }
    if ((mes == ahora_mes) && (ahora_dia < dia)) {
        edad--;
    }
    if (edad > 1900) {
        edad -= 1900;
    }

    // calculamos los meses
    var meses = 0;

    if (ahora_mes > mes && dia > ahora_dia)
        meses = ahora_mes - mes - 1;
    else if (ahora_mes > mes)
        meses = ahora_mes - mes
    if (ahora_mes < mes && dia < ahora_dia)
        meses = 12 - (mes - ahora_mes);
    else if (ahora_mes < mes)
        meses = 12 - (mes - ahora_mes + 1);
    if (ahora_mes == mes && dia > ahora_dia)
        meses = 11;

    // calculamos los dias
    var dias = 0;
    if (ahora_dia > dia)
        dias = ahora_dia - dia;
    if (ahora_dia < dia) {
        ultimoDiaMes = new Date(ahora_ano, ahora_mes - 1, 0);
        dias = ultimoDiaMes.getDate() - (dia - ahora_dia);
    }

    return $("#age").html(edad + " años, " + meses + " meses y " + dias + " días");
}

function esNumero(strNumber) {
    if (strNumber == null) return false;
    if (strNumber == undefined) return false;
    if (typeof strNumber === "number" && !isNaN(strNumber)) return true;
    if (strNumber == "") return false;
    if (strNumber === "") return false;
    var psInt, psFloat;
    psInt = parseInt(strNumber);
    psFloat = parseFloat(strNumber);
    return !isNaN(strNumber) && !isNaN(psFloat);
}


function usuarioRegistrado() {
    $.post("./controller/PacienteController.php?op=usuarioRegistrado", function (data) {
        $("#txtUsuReg").val(data);

    });
}

function horaRegistro() {

    var currentdate = new Date();
    var datetime = currentdate.getDate() + "-" +
        (currentdate.getMonth() + 1) + "-" +
        currentdate.getFullYear() + " " +
        currentdate.getHours() + ":" +
        currentdate.getMinutes() + ":" +
        currentdate.getSeconds();
    $("#txtReg").val(datetime);
}

function SaveorUpdatePaciente(e) {
    e.preventDefault();
    //bloquearPantalla();
    var formData = new FormData($("#frmPaciente")[0]);
    $.ajax({
        url: "./controller/PacienteController.php?op=SaveorUpdatePaciente",
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (datos) {
            $.unblockUI();
            swal("Mensaje del Sistema", datos, "success");
            limpiarCampos();
            ListadoPacientes();
            $("#verListPacientes").show();
            $("#verFrmPaciente").hide();

        }
    });
};

function SaveorUpdateRepresentantes(e) {
    e.preventDefault();
    //bloquearPantalla();
    var formData = new FormData($("#frmDatRep")[0]);
    $.ajax({
        url: "./controller/PacienteController.php?op=SaveorUpdateRepresentantes",
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (datos) {
            $.unblockUI();
            swal("Mensaje del Sistema", datos, "success");
            $("#verListPacientes").show();
            $("#verFrmDatRep").hide();
            $("#btnNuevoPaciente").show();
            limpiarCamposRep();
        }
    });
};

function limpiarCampos() {
    $("#txtIdPaciente").val("");
    $("#cboTipPac").val("");
    $("#cboTipIde").val("");
    $("#txtIdentificacion").val("");
    $("#txtApellido").val("");
    $("#txtNombre").val("");
    $("#dateFecNac").val("");
    $("#cboGenero").val("");
    $("#txtInstruccion").val("");
    $("#txtRegistro").val("REGISTRADO");
    $("#txtInstitucion").val("");
    $("#txtDireccion").val("");
    $("#txtTelefono").val("");
    $("#txtEmergencia").val("");
    $("#txtCelular").val("");
    $("#txtEmail").val("");
    usuarioRegistrado();
    horaRegistro();
    $("#txtFecIng").val("");
    $("#txtCentro").val("QUITO");

}

function abrirFrmPaciente() {
    $("#verFrmPaciente").show();
    $("#btnNuevoPaciente").hide();
    $("#verListPacientes").hide();
    $("#btnNuevoPaciente").hide();

}

function cargarDataPaciente(id) {
    $.post("./controller/PacienteController.php?op=CargarDatosPaciente", {
        id: id
    }, function (r) {
        var data = $.parseJSON(r);
        $("#verListPacientes").hide();
        $("#verFrmPaciente").show();
        $("#btnNuevoPaciente").hide();

        $("#txtIdPaciente").val(data.PAC_ID);
        $("#cboTipPac").val(data.TPAC_ID);
        $("#cboTipIde").val(data.TIDE_ID);
        $("#txtIdentificacion").val(data.PAC_IDENTIFICACION);
        $("#txtApellido").val(data.PAC_APELLIDO);
        $("#txtNombre").val(data.PAC_NOMBRE);
        $("#dateFecNac").val(data.PAC_FECHANACIMIENTO);
        $("#cboGenero").val(data.PAC_GENERO);
        $("#txtInstruccion").val(data.PAC_INSTRUCCION);
        $("#cboRegistrado").val(data.PAC_REGISTRADO);
        $("#txtInstitucion").val(data.PAC_INSTITUCION);
        $("#txtUsuReg").val(data.PAC_USUARIO);
        $("#txtReg").val(data.PAC_FECHAREGISTRO);
        $("#dateFecIng").val(data.PAC_FECHAINGRESO);
        $("#cboCentro").val(data.PAC_CENTRO);
        $("#txtEmergencia").val(data.PAC_EMERGENCIA);
        $("#btnGuardarUsuario").html('<i class="fa fa-spinner" aria-hidden="true"></i> Actualizar');

        calcularEdad2();
    });
}

function eliminarPaciente(id) {
    bootbox.confirm("¿Esta Seguro de eliminar este paciente?", function (result) {
        if (result) {
            $.post("./controller/PacienteController.php?op=delete", {
                id: id
            }, function (e) {
                swal("Mensaje del Sistema", e, "success");
                ListadoPacientes();

            });
        }
    })
}

function agregarRepresentantes(idPac, identificacion, apellido, nombre) {
    $("#verListPacientes").hide();
    $("#btnNuevoPaciente").hide();
    $("#verListDatosRepresentantes").show();

    $("#DRIdPac").val(idPac);
    $("#DRIdentificacion").val(identificacion);
    $("#DRApellido").val(apellido);
    $("#DRNombre").val(nombre);


    ListadoRepresentantes(idPac);
    $("#txtNombreRepresentante").val(apellido + " " + nombre);
}

function limpiarCamposRep() {
    $("#repId").val("");

    $("#cboRTipDoc").val("");
    $("#txtRIdentifiacion").val("");
    $("#txtRNombre").val("");
    $("#txtRTelefono").val("");
    $("#txtRCelular").val("");
    $("#txtREmail").val("");
    $("#txtRDireccion").val("");
    $("#txtRParentesco").val("");
    $("#txtRObservacion").val("");
    $("#fileAnexo1").val("");
    $("#fileAnexo2").val("");
    $("#fileAnexo3").val("");
    $("#fileAnexo4").val("");

}

function ListadoRepresentantes(idPac) {

    $.post("./controller/PacienteController.php?op=listRep", {
        idPac: idPac
    }, function (r) {
        $("#listRepresentantes").html(r);
    });
}

function abrirFrmRepresentante() {
    $("#verListDatosRepresentantes").hide();
    $("#verFrmDatRep").show();
    $('#anexosRepresentantes').show();
}

function cargarDataRep(id) {
    $.post("./controller/PacienteController.php?op=cargarDataRepresentante", {
        id: id
    }, function (r) {
        var data = $.parseJSON(r);
        $("#verListDatosRepresentantes").hide();
        $("#verFrmDatRep").show();

        $("#repId").val(data.REP_ID);
        $("#DRIdPac").val(data.PAC_ID);
        $("#DRIdentificacion").val(data.PAC_IDENTIFICACION);

        $("#cboRTipDoc").val(data.REP_TDOCUMENTO);
        $("#txtRIdentifiacion").val(data.REP_IDENTIFICACION);
        $("#txtRNombre").val(data.REP_NOMBRE);
        $("#txtRTelefono").val(data.REP_TELEFONO);
        $("#txtRCelular").val(data.REP_CELULAR);
        $("#txtREmail").val(data.REP_EMAIL);
        $("#txtRDireccion").val(data.REP_DIRECCION);
        $("#txtRObservacion").val(data.REP_OBSERVACION);
        $("#txtRParentesco").val(data.REP_PARENTESCO);
        //$('#fileAnexo1').attr('src', data.REP_ANEXO1);
        $('#anexosRepresentantes').hide();

        $("#btnGuardarDatRep").html('<i class="fa fa-spinner" aria-hidden="true"></i> Actualizar');
    });
}

function eliminarRep(id) {
    bootbox.confirm("¿Esta Seguro de eliminar este representante?", function (result) {
        if (result) {
            $.post("./controller/PacienteController.php?op=deleteRep", {
                id: id
            }, function (e) {
                swal("Mensaje del Sistema", e, "success");
                $("#verListPacientes").show();
                $("#verListDatosRepresentantes").hide();
                $("#btnNuevoPaciente").show();

            });
        }
    })
}

function cargarModalRep(idPac, identificacionRep, idRep) {
    $("#modIdPaciente").val(idPac);
    $("#modIdeRep").val(identificacionRep);
    $("#modIdRep").val(idRep);
    limpiarModalRep();

}

function limpiarModalRep() {
    $("#modNomAne").val("");
    $("#fileAnexo").val("");
}

function SaveModRepAnexos(e) {
    e.preventDefault();
    //bloquearPantalla();
    var formData = new FormData($("#frmModRepAnexos")[0]);
    $.ajax({
        url: "./controller/PacienteController.php?op=SaveModRepAnexos",
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (datos) {
            $.unblockUI();
            var data = $.parseJSON(datos);
            if (data[0] == "Anexo Registrado correctamente.") {
                swal("Mensaje del Sistema", data[0], "success");
            } else if (data[0] == "El Anexo no ha podido ser registado.") {
                swal("Mensaje del Sistema", data[0], "error");
            } else if (data[0] == "tamaño del archivo excedido") {
                swal("Mensaje del Sistema", data[0], "error");
            }

            limpiarModalRep();

        }
    });
};

function cargarArchivosRep(idRep, idenRep, nomRep) {
    $("#verListDatosRepresentantes").hide();
    $("#verListArchivosRep").show();
    $("#txtidRep").val(idRep);
    $("#txtidenRep").val(idenRep);
    $("#txtnomRep").val(nomRep);
    ListadoAnexosRep(idenRep);
}

function ListadoAnexosRep(idenRep) {

    $.post("./controller/PacienteController.php?op=listAnexosRep", {
        idenRep: idenRep
    }, function (r) {
        $("#anexosDescargables").html(r);
    });
}

function BusquedaPaciente(e) {
    e.preventDefault();
    //bloquearPantalla();
    var formData = new FormData($("#frmBusquedaPaciente")[0]);
    $.ajax({
        url: "./controller/PacienteController.php?op=BusquedaPaciente",
        type: "POST",
        data: formData,
        contentType: false,
        processData: false,
        success: function (datos) {
            $.unblockUI();
            $("#listPacientes").html(datos);
            //ListadoPacientes();

        }
    });
};

function eliminarAnexo(idAne, idenRep) {

    swal({
        title: "Estas seguro?",
        text: "Se borrará este anexo para siempre",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Si, Borrar!",
        closeOnConfirm: false
    },
        function () {
            $.post("./controller/PacienteController.php?op=deleteAnexo", {
                idAne: idAne
            }, function (e) {
                swal("Mensaje del Sistema", e, "success");
                ListadoAnexosRep(idenRep);
            });

        });
}

function verRepresentantes() {
    $("#verListArchivosRep").hide();
    $("#verListDatosRepresentantes").show();

}