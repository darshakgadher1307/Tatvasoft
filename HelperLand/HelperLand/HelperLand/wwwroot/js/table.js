$(document).ready(function () {
    $('#Data').DataTable({
        "dom": 'rt<"bottom"lip><"clear">',
        "ordering": false,
        "lengthMenu": [[10, 20, 30, -1], [10, 20, 30, "All"]],
        "language": {
            "info": "Total Record : _MAX_",
            "paginate": {
                "previous": "<i class='fa fa-angle-left'></i>",
                "next": "<i class='fa fa-angle-right'></i>"
            }
        }
    });
});