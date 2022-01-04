// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(window).on('load', function () {
    setTimeout(function () {
        $("#exampleModalCenter").modal('show');
    }, Math.floor(Math.random() * (3000 - 500)) + 500);
});

// Simulate some time consuming JS calls
(function () {
    $('form input').on("keyup change", function () {
        setTimeout(function () {
            var empty = false;
            $('form input').each(function () {
                if ($(this).val() == '') {
                    empty = true;
                }
            });

            if (empty) {
                $('#Submit').attr('disabled', 'disabled');
            } else {
                $('#Submit').removeAttr('disabled');
            }
        }, Math.floor(Math.random() * (3000 - 500)) + 500);
    });
})();