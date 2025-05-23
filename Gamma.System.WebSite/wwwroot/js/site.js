// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Toggle del sidebar
$(document).ready(function () {
    $('#sidebarToggle').on('click', function () {
        $('#sidebar').toggleClass('active');
        $('.main-content').toggleClass('sidebar-collapsed');

        // Ajustar el margen del contenido principal
        if ($('#sidebar').hasClass('active')) {
            $('.main-content').css('margin-left', '250px');
        } else {
            $('.main-content').css('margin-left', '0');
        }
    });

    // Activar tooltips
    $('[data-bs-toggle="tooltip"]').tooltip();

    // Activar popovers
    $('[data-bs-toggle="popover"]').popover();
});