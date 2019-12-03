(function ($) {
    $(function () {
        // $(this) is used to refer to the current link element

        $(document).on('click', '[data-sf-role=toggleLink]', function () {
            expandElement($(this));
            checkIfAllExpandedCollapsed($(this));
        });

        $(document).on('click', '[data-sf-role=expandAll]', function () {
            ToggleContent($(this), true)
            checkIfAllExpandedCollapsed($(this));
        });

        $(document).on('click', '[data-sf-role=collapseAll]', function () {
            ToggleContent($(this), false)
            checkIfAllExpandedCollapsed($(this));
        });

        function ToggleContent(link, expand) {
            var wrapper = link.closest('[data-sf-role=lists]');
            var links = wrapper.find('[data-sf-role=toggleLink]');
            expand ? links.addClass('expanded') : links.removeClass('expanded');
            expand ? links.next('div').css('display', 'block') : links.next('div').css('display', 'none');
        }

        function checkIfAllExpandedCollapsed(link) {
            var wrapper = link.closest('[data-sf-role=lists]');

            var linkCount = wrapper.find('[data-sf-role=toggleLink]').length;
            var expandedLinkCount = wrapper.find('[data-sf-role=toggleLink].expanded').length;

            // only show expand all links if all items are not expanded
            linkCount === expandedLinkCount ? toggleExpandOrCollapse(wrapper, 'expand', false) : toggleExpandOrCollapse(wrapper, 'expand', true);

            // only show collapse all links if all items are not collapsed
            expandedLinkCount == 0 ? toggleExpandOrCollapse(wrapper, 'collapse', false) : toggleExpandOrCollapse(wrapper, 'collapse', true);
        }

        function expandElement(link) {
            if (link.hasClass('expanded')) {
                link.removeClass('expanded');
            } else {
                link.addClass('expanded');
                var itemTitle = link.text().trim();

                // no idea what it does. Keeping it assuming that removing it would cause an issue.
                sendSentence(itemTitle);
            }

            var content = link.next();
            $(content).toggle();
        }

        function toggleExpandOrCollapse(wrapper, text, display) {
            wrapper.find(`[data-sf-role=${text}All]`).css('display', display ? 'block' : 'none');
        }

        // no idea what it does. Keeping it assuming that removing it would cause an issue.
        function sendSentence(itemTitle) {
            if (window.DataIntelligenceSubmitScript) {
                DataIntelligenceSubmitScript._client.sentenceClient.writeSentence({
                    predicate: "Expand list",
                    object: itemTitle,
                    objectMetadata: [{
                        'K': 'PageTitle',
                        'V': document.title
                    },
                    {
                        'K': 'PageUrl',
                        'V': location.href
                    }
                    ]
                });
            }
        }
    });
}(jQuery));