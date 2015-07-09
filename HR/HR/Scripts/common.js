$(document).ready(function () {

    $('input[type=checkbox]').material_checkbox();


    $(".button-slide-menu").sideNav({
        menuWidth: 300
    });

    $(".button-slide-menu").click(function () {
        $('.button-collapse').sideNav('show');
    });

    
});