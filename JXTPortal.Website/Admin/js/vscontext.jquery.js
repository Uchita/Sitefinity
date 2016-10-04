/**
*  jQuery Very Simple Context Menu Plugin
*  @requires jQuery v1.3 or 1.4
*  http://intekhabrizvi.wordpress.com/
*
*  Copyright (c)  Intekhab A Rizvi (intekhabrizvi.wordpress.com)
*  Licensed under GPL licenses:
*  http://www.gnu.org/licenses/gpl.html
*
*  Version: 1.1
*  Dated : 28-Jan-2010
*  Version 1.1 : 2-Feb-2010 : Some Code Improvment
*/

(function ($) {
    jQuery.fn.vscontext = function (options, fileurl) {
        var defaults = {
            menuBlock: null,
            offsetX: 8,
            offsetY: -113,
            speed: 'slow'
        };
        var options = $.extend(defaults, options);
        var menu_item = '.' + options.menuBlock;

        return this.each(function () {
            $(this).bind("contextmenu", function (e) {
                return false;
            });
            $(this).mousedown(function (e) {
                var offsetX = e.pageX + options.offsetX;
                var offsetY = e.pageY + options.offsetY;

                if ($(this).find('input[type="hidden"]').get(1).value.toLowerCase() == 'false') {

                    if (e.button == "0" || e.button == "1") {
                        if ($('a[href$="#myModal6"]').length == 0) {
                            // alert("failed");
                        }
                        $('a[href$="#myModal6"]').attr('data-id', $(this).find('a').first().text());
                        $('#myModal').attr('data-id', fileurl);
                    }
                }

                if (e.button == "2") {
                    var classname = $(menu_item).attr('class');
                    if (classname == 'vs-context-menu1') {
                        $('div.vs-context-menu2').hide(options.speed);
                        $('div.vs-context-menu3').hide(options.speed);
                    }
                    else if (classname == 'vs-context-menu2') {
                        $('div.vs-context-menu1').hide(options.speed);
                        $('div.vs-context-menu3').hide(options.speed);
                    }
                    else if (classname == 'vs-context-menu3') {
                        $('div.vs-context-menu1').hide(options.speed);
                        $('div.vs-context-menu2').hide(options.speed);
                    }

                    $(menu_item).show(options.speed);
                    $(menu_item).css('display', 'block');
                    $(menu_item).css('top', offsetY);
                    $(menu_item).css('left', offsetX);
                    $(menu_item).find('a[href$="#myModal"]').attr('data-id', fileurl);
                    $(menu_item).find('a[href$="#myModal3"]').attr('data-id', fileurl);
                    $(menu_item).find('a[href$="#myModal4"]').attr('data-id', fileurl);
                    $(menu_item).find('input[type="hidden"]').first().val(fileurl);
                } else {
                    $(menu_item).hide(options.speed);
                }
            });
            $(menu_item).hover(function () { }, function () { $(menu_item).hide(options.speed); })

        });
    };
})(jQuery);
