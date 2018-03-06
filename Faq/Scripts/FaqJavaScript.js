$(document).ready(function () {

    HentFAQ();
    HentNyeSporsmal();

    $("#send-sporsmal").click(function () {
        var $ok = $('#sporsmal-skjema .sporsmal-motatt');
        $ok.show();
        setTimeout(function () {
            $ok.fadeOut();
        }, 3000);
    });

    var arrowUp = "<span class='glyphicon glyphicon-chevron-up'></span>";
    var arrowDown = "<span class='glyphicon glyphicon-chevron-down'></span>";

    $(".faq-innhold,.kunde-sporsmal-innhold").on("click", '.kategori', function () {
        var $expand = $(this).next();
        var $icon = $(this).find('.icon');
        $expand.toggle();
        if ($icon.html() == arrowUp) {
            $icon.html(arrowDown);
        } else {
            $icon.html(arrowDown);
        }
    });

    $(".faq-header,.kunde-sporsmal-header,.kontakt-header").on("click", function () {
        var $expand = $(this).next();
        var $icon = $(this).find('.icon');
        $expand.toggle();
        if ($icon.html() == arrowUp) {
            $icon.html(arrowDown);
        } else {
            $icon.html(arrowDown);
        }
    });
});


var $template = $(`
            <div class="container">
                <div class="panel-group">
                    <div class="panel panel-default">
                        <div class="panel-heading kategori">
                            <div data-toggle="collapse" class="panel-title expand" style="cursor:pointer">
                                <div class="icon right-arrow pull-right"><span class='glyphicon glyphicon-chevron-up'></span></div>
                                <div class="kategori-navn">kategori navn</div>
                            </div>
                        </div>
                        <div class="panel-collapse collapse">
                            <div class="panel-body kat-sporsmal">
                                jalla
                            </div>
                        </div>
                    </div>
                </div>
            </div>`);


function HentNyeSporsmal() {

    $.ajax({
        url: '/api/Kunde',
        type: 'GET',
        success: function (data) {
            VisAlleNyeSporsmal(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}


function VisAlleNyeSporsmal(rader) {

    var kategorier = {};
    rader.forEach(function (rad) {
        var kategoriNavn = rad['Kategori'];
        if (!kategorier[kategoriNavn]) {
            kategorier[kategoriNavn] = [];
        }
        kategorier[kategoriNavn].push(rad);

    });

    // Fyll inn data i templaten og legg til i DOM
    $('.kunde-sporsmal-innhold').html('');
    for (let kategori in kategorier) {
        $template.find('.kategori-navn').html(kategori);
        $template.find('.kat-sporsmal').html('');
        kategorier[kategori].forEach(function (rad) {
            if (rad.Svaret == null) {
                rad.Svaret = "Ikke besvart";
            }
            $template.find('.kat-sporsmal').append(`<div class='nye-sporsmal-box'>
                <p class='sporsmal-kunde'> <strong>${rad.Sporsmalet} </strong></p>
                <p class='svar-kunde'> <strong>Svar:</strong>  ${rad.Svaret}</p>
            </div>`);
        });
        $('.kunde-sporsmal-innhold').append($template.html());
    }

    
}

function LagreNyttSporsmal() {

    var nyttsporsmal = {
        Fornavn: $('#txtFornavn').val(),
        Etternavn: $('#txtEtternavn').val(),
        Epost: $('#txtEpost').val(),
        Sporsmalet: $('#txtSporsmal').val(),
        Kategori: $('#txtKategori').val()
    };
    $.ajax({
        url: '/api/Kunde/',
        type: 'POST',
        data: JSON.stringify(nyttsporsmal),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (data == null) {
                $("#skjema-validering-feil").html("Feil under servervalidering. Prøv igjen.");
            }
            else {
                $("#skjema-validering-feil").html("");
            }
            resetSkjema();
            HentNyeSporsmal();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}


function resetSkjema() {

    $("#txtFornavn").val("");
    $("#txtEtternavn").val("");
    $("#txtEpost").val("");
    $("#txtSporsmal").val("");
}


function HentFAQ() {

    $.ajax({
        url: '/api/Sporsmal',
        type: 'GET',
        success: function (data) {
            VisFAQ(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}


function VisFAQ(rader) {

    var kategorier = {};
    rader.forEach(function (rad) {
        var kategoriNavn = rad['Kategori'];
        if (!kategorier[kategoriNavn]) {
            kategorier[kategoriNavn] = [];
        }
        kategorier[kategoriNavn].push({
            sporsmal: rad['Sporsmalet'],
            svar: rad['Svaret']
        });

    });

    // Fyll inn data i templaten og legg til i dom
    for (let kategori in kategorier) {
        $template.find('.kategori-navn').html(kategori);
        $template.find('.kat-sporsmal').html('');
        kategorier[kategori].forEach(function (sporsmalOgSvar) {
            $template.find('.kat-sporsmal').append(`
            <div class="smorsmal-og-svar">
                <div class="sporsmal">${sporsmalOgSvar.sporsmal}</div>
                <div class="svar">${sporsmalOgSvar.svar}</div>
            </div>`);
        });
        $('.faq-innhold').append($template.html());
    }
   
}

