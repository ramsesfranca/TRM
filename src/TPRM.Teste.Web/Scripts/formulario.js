/*!
 * Formulário
 */

(function ($) {
    jQuery(function ($) {
        $(".campoPlaca").mask('aaa-9999');
        $(".campoCPF").mask("999.999.999-99");
        $(".campoCNPJ").mask("99.999.999/9999-99");
        $(".campoMoeda").maskMoney({ allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
    });
})(jQuery);
