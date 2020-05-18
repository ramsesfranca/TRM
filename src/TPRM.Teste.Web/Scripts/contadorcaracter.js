function contadorcaracter(id) {
    $("#" + id).characterCounter({
        limit: $("#" + id).attr("data-val-maxlength-max"),
        counterCssClass: 'contadortexto',
        counterFormat: '%1 caracteres restantes.',
        onExceed: function () {
            $("#" + id).val($("#" + id).val().substring(0, ($("#" + id).val().length - 1)));
        }
    });
}
