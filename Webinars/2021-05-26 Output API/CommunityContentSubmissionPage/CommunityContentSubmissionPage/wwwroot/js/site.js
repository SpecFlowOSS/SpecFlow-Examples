// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: 'api/AvailableTypes',
        success: function (result, status, message) {

            var selectElement = $("#txtType")[0];

            var listOfTypes = result.types;

            for (var i = 0; i < listOfTypes.length; i++) {
                var text = listOfTypes[i];

                var option = document.createElement('option');
                option.innerHTML = text;

                if (text === result.selectedType) {
                    option.selected = true;
                }

                selectElement.appendChild(option);
            }

        },
        error: function (error, type) { }
    });
});