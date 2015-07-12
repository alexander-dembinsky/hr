$(document).ready(function () {

    prepareMaterialCheckboxes();
    prepareSlideNav();
    prepareSearchBar();
    
});


function prepareMaterialCheckboxes() {
    $('input[type=checkbox]').material_checkbox();
}

function prepareSlideNav() {
    $(".button-slide-menu").sideNav({
        menuWidth: 300
    });

    $(".button-slide-menu").click(function () {
        $('.button-collapse').sideNav('show');
    });

}

function prepareSearchBar() {
    $("#search-bar").hide();

    $("#search-button").click(function () {
        $("#search-button").parent().toggleClass('active');
        $("#search-bar").slideToggle();
    });

    $("#search-clear-button").click(function() {
        $("#search-input").val('');
    });
}
