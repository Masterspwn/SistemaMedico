
$(document).on("ready", init);

function init() {

} //CIERRA LLAVE DEL DOCUMENT READY 

function bloquearPantalla() {
    var message = '<h4><img src="./files/images/cargar1.gif" /></h4>';
    $.blockUI({
        baseZ: 16000,
        fadeIn: 0,
        timeout: 0,
        message: message,
        css: {

            opacity: .6
        }
    });
}

function justNumbers(e) {
    var keynum = window.event ? window.event.keyCode : e.which;
    if ((keynum == 8 || keynum == 48))
        return true;
    if (keynum <= 47 || keynum >= 58) return false;
    return /\d/.test(String.fromCharCode(keynum));
}

function justNumbersAndSlash(e, field) {
    key = e.keyCode ? e.keyCode : e.which
    if (key == 8) return true
    if (key > 47 && key < 58) {
        if (field.value == "") return true
        regexp = /.[0-9]{5}$/
        return !(regexp.test(field.value))
    }
    if (key == 47) {
        if (field.value == "") return false
        regexp = /^[0-9]+$/
        return regexp.test(field.value)
    }
    return false
}

function onKeyDecimal(e, field) {

    key = e.keyCode ? e.keyCode : e.which
    if (key == 8) return true
    if (key > 47 && key < 58) {
        if (field.value == "") return true
        regexp = /.[0-9]{5}$/
        return !(regexp.test(field.value))
    }
    if (key == 46) {
        if (field.value == "") return false
        regexp = /^[0-9]+$/
        return regexp.test(field.value)
    }
    return false
}
function soloLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " Ã¡Ã©Ã­Ã³ÃºabcdefghijklmnÃ±opqrstuvwxyz";
    especiales = "8-37-39-46";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function Mayusculas(a) {
    setTimeout(function () {
        a.value = a.value.toUpperCase();
    }, 1);
}