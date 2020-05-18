/*
 * Página Cancela.
 */

$("#ClienteId").change(function () {
    if ($("#ClienteId").val() !== "") {
        $.ajax({
            type: 'POST',
            url: urlEstacionamento,
            dataType: 'json',
            data: { clienteId: $("#ClienteId").val() },
            async: false,
            success: function (itens) {
                if (itens.length > 0) {
                    $("#EstacionamentoId").removeAttr("disabled", false);
                    $("#EstacionamentoId option").remove();
                    $("#EstacionamentoId").empty().append($("<option value=''></option>").text("Selecione"));
                    $.each(itens, function (i, item) {
                        $("#EstacionamentoId").append($("<option></option>").val(item.Value).html(item.Text));
                    });
                }
                else {
                    $("#EstacionamentoId option").remove();
                    $("#EstacionamentoId").empty().append($("<option value=''></option>").text("Nenhum registro cadastrado"));
                    alert("Nenhum estacionamento foi cadastrado para esse cliente.");
                }
            },
            error: function (ex) {
                alert("Erro ao carregar o(s) estacionamento(s) no servidor.");
            }
        });
    }
    else {
        $("#EstacionamentoId option").remove();
        $("#EstacionamentoId").empty().append($("<option value=''></option>").text("Selecione o Cliente"));
        $("#EstacionamentoId").attr("disabled", true);
    }
});
