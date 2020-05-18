/*
 * Página Usuário.
 */

function validarOperador() {
    var perfilId = $("#PerfilId").val();
    if (perfilId !== "" && perfilId == 2) {
        $(".operador").removeClass("hidden");
        $("#ClienteId").removeAttr("disabled", false);
    }
    else {
        $(".operador").addClass("hidden");
        $("#ClienteId").attr("disabled", true).val("");
        $("#EstacionamentoId").attr("disabled", true).val("");
        $("#CancelaId").attr("disabled", true).val("");
    }
}

$(document).ready(function () {
    validarOperador();

    $("#PerfilId").change(function () {
        validarOperador();
    });

    $("#EstacionamentoId").change(function () {
        if ($("#EstacionamentoId").val() !== "") {
            $.ajax({
                type: 'POST',
                url: urlCancela,
                dataType: 'json',
                data: { estacionamentoId: $("#EstacionamentoId").val() },
                async: false,
                success: function (itens) {
                    if (itens.length > 0) {
                        $("#CancelaId").removeAttr("disabled", false);
                        $("#CancelaId option").remove();
                        $("#CancelaId").empty().append($("<option value=''></option>").text("Selecione"));
                        $.each(itens, function (i, item) {
                            $("#CancelaId").append($("<option></option>").val(item.Value).html(item.Text));
                        });
                    }
                    else {
                        $("#CancelaId option").remove();
                        $("#CancelaId").empty().append($("<option value=''></option>").text("Nenhum registro cadastrado"));
                        alert("Nenhum estacionamento foi cadastrado para esse cliente.");
                    }
                },
                error: function (ex) {
                    alert("Erro ao carregar a(s) cancela(s) no servidor.");
                }
            });
        }
        else {
            $("#CancelaId option").remove();
            $("#CancelaId").empty().append($("<option value=''></option>").text("Selecione o Estacionamento"));
            $("#CancelaId").attr("disabled", true);
        }
    });
});
