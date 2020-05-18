$(function () {
    $('body').on('click', '.modal-link', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('href'),
            success: function (result) {
                if (result.success === false) {
                    $('#modal').modal('hide');
                    location.reload();
                }
                else {
                    $('.modal-content').html(result);
                    $('#deletarModal').modal('show');
                }
            }
        });
    });

    $('body').on('click', '.modal-close-btn', function () {
        $('#modal-container').modal('hide');
    });

    $('#modal-container').on('hidden.bs.modal', function () {
        $(this).removeData('bs.modal');
    });

    $('#CancelModal').on('click', function () {
        return false;
    });
});
