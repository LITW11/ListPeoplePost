$(() => {
    const modal = new bootstrap.Modal($("#demo-modal")[0]);

    $("#add-with-modal").on('click', function () {
       modal.show();
    });

    $(".btn-secondary").on('click', function () {
        modal.hide();
    });
})