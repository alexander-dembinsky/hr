(function ($) {

    $.fn.material_checkbox = function () {
        
        this.each(function () {
            var checkbox = $(this);

            $(this).click(function () {
                var val = checkbox.attr('value');
                if (val == "true") {
                    checkbox.attr('value', 'false');
                } else {
                    checkbox.attr('value', 'true');
                }
            });

        });

    }

})(jQuery);