
/**
 * Validering Kontakt skjema
 */

var ok = {
    fornavn: false,
    etternavn: false,
    epost: false,
    sporsmal: false
};

$(document).ready(function () {

    $("#txtFornavn").change(function () {
        valider_fornavn();
        sjekkForm();
    });
    $("#txtEtternavn").change(function () {
        valider_etternavn();
        sjekkForm();
    });
    $("#txtEpost").change(function () {
        valider_epost();
        sjekkForm();
        console.log(ok)
    });
    $("#txtSporsmal").change(function () {
        valider_sporsmal();
        sjekkForm();
    });
    $('#send-sporsmal').on('click', function () {
        LagreNyttSporsmal();
    });
});


function sjekkForm() {
    if (ok.fornavn && ok.etternavn && ok.epost && ok.sporsmal) {
        $('#send-sporsmal').removeAttr('disabled');
    } else {
        $('#send-sporsmal').attr('disabled', '');
    }
}

function valider_fornavn() {

    var regEx = /^[a-zæøåA-ZÆØÅ''-'\s]{1,40}$/;
    var OK = regEx.test($("#txtFornavn").val());
    if (!OK) {
        $("#feilFornavn").html("Feil i fornavnet.");
        ok.fornavn = false;
    } else {
        $("#feilFornavn").html("");
        ok.fornavn = true;
    }
}

function valider_etternavn() {
    var regEx = /^[a-zæøåA-ZÆØÅ''-'\s]{1,40}$/;
    var OK = regEx.test($("#txtEtternavn").val());
    if (!OK) {
        $("#feilEtternavn").html("Feil i etternavnet.");
        ok.etternavn = false;
    } else {
        $("#feilEtternavn").html("");
        ok.etternavn = true;
    }
}

function valider_epost() {
    var regEx = /^([\w\.\-]+)@((?!\.|\-)[\w\-]+)((\.(\w){2,3})+)$/;
    var OK = regEx.test($("#txtEpost").val());
    if (!OK) {
        $("#feilEpost").html("Feil i epost.");
        ok.epost = false;
    }
    else {
        $("#feilEpost").html('');
        ok.epost = true;
    }
}

function valider_sporsmal() {
    var regEx = /^[a-zæøåA-ZÆØÅ1-9? ''-'\s]{1,250}$/;
    var OK = regEx.test($("#txtSporsmal").val());
    if (!OK) {
        $("#feilSporsmal").html("Feil i fri tekst.");
        ok.sporsmal = false;
    }
    else {
        $("#feilSporsmal").html("");
        ok.sporsmal = true;
    }
}

function valider_alle() {
    var okFornavn = valider_fornavn();
    var okEtternavn = valider_etternavn();
    var okEpost = valider_epost();
    var okSporsmal = valider_sporsmal();
    if (okNavn && okFornavn && okEpost && okSporsmal) {
        return true;
    }
    $('#send-sporsmal').attr('disabled', '');
    return false;
}