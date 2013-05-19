(function ($) {

    $.fn.Command = function (options) {
        $.extend({}, options);
        this.click(function () {
            eval(jQuery(this).find('td.command > a').attr('href'));
        });
    }

})(jQuery);

var prm = Sys.WebForms.PageRequestManager.getInstance();

prm.add_pageLoaded(function (sender, args) {
    jQuery(".command").Command();
});


jQuery.noConflict();
jQuery(window).bind('unload', function () { jQuery('*').unbind(); });

