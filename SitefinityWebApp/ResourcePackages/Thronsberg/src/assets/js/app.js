import $ from 'jquery';
import 'what-input';

// Foundation JS relies on a global varaible. In ES6, all imports are hoisted
// to the top of the file so if we used`import` to import Foundation,
// it would execute earlier than we have assigned the global variable.
// This is why we have to use CommonJS require() here since it doesn't
// have the hoisting behavior.
window.jQuery = $;
//require('foundation-sites');

// If you want to pick and choose which modules to include, comment out the above and uncomment
// the line below
import './lib/foundation-explicit-pieces';
var jq32 = jQuery.noConflict(true);

(function ($) {
    $(document).foundation();

    $(document).ready(function () {

        $('.js-bg-img').setAsBackground();

        var elem = new Foundation.Sticky($('#tracking-consent-dialog'));
    });

    jq32.fn.extend({
        setAsBackground: function () {
            if ($(this).is('img')) {
                var image = $(this);
                var parent = image.parent();

                parent.addClass('is-bg-img-container');
                parent.css({ 'background-image': 'url(' + image.attr('src') + ')' })
                image.css({ display: 'none' });
            }
        }
    });
}(jq32));
