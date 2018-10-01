(function ($) {

    $.extend($.fn, {

        showWaitScreen: function (callback) {
            $(this).initWaitScreen().fadeIn('fast', function () {
                if (typeof (callback) == 'function') callback();
            });
        },

        hideWaitScreen: function (callback) {
            $('.waitScreen').fadeOut('fast', function () {
                if (typeof (callback) == 'function') callback();
            });
        },

        initWaitScreen: function () {
            if ($('.waitScreen').size() > 0) {
                return $('.waitScreen');
            } else {
                var ws = $('<div class="waitScreen"><img src="/Content/images/loading.gif" alt="" /></div>').appendTo('body');
                $('.waitScreen').fitScreen();
                $(window).bind('scroll', function () {
                    $('.waitScreen').fitScreen();
                });
                $(window).bind('resize', function () {
                    $('.waitScreen').fitScreen();
                });
                return ws;
            }
        },

        fitScreen: function () {
            if (navigator.userAgent.match(/iPad/i) != null) {
                $(this).css('position', 'absolute');
                $(this).height($(window).scrollTop() + $(window).height());
            }
        },

        loadWidget: function (action, callback) {
            var content = $(this).children('.portlet-content');
            content.addClass('portlet-loading');
            $.ajax({
                url: action,
                type: 'POST',
                data: {},
                success: function (data) {
                    content.html(data);
                    content.removeClass('portlet-loading');
                    if (typeof (callback) == 'function') callback();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    var err = jqXHR.getResponseHeader('X-Error-Description');
                    if (!err) err = textStatus;
                    content.html('<p>' + err + '</p>');
                    content.removeClass('portlet-loading');
                }
            });
        },

        loadHtml: function (action, data, callback) {
            var content = $(this);
            content.empty().addClass('portlet-loading');
            $.ajax({
                url: action,
                type: 'POST',
                data: data,
                traditional: true,
                success: function (data) {
                    content.html(data);
                    content.removeClass('portlet-loading');
                    if (typeof (callback) == 'function') callback();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    var err = jqXHR.getResponseHeader('X-Error-Description');
                    if (!err) err = textStatus;
                    content.html('<p>' + err + '</p>');
                    content.removeClass('portlet-loading');
                }
            });
        }
    });

})(jQuery);