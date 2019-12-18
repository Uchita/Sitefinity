(function ($) {
    var globalTreeIdCounter = 0;

    var dropDownOptions = {
        title: "Dropdown",
        data: [],
        closedArrow: '<i class="fas fa-angle-right" aria-hidden="true"></i>',
        openedArrow: '<i class="fas fa-angle-down" aria-hidden="true"></i>',
        checkboxIcon: '<i class="far fa-square select-box" aria-hidden="true"></i>',
        checkboxSelectedIcon: '<i class="far fa-check-square select-box" aria-hidden="true"></i>',
        checkboxIconClass: 'fa-square',
        checkboxSelectedIconClass: 'fa-check-square',
        buttonClass: 'btn btn-default dropdown-toggle',
        maxHeight: 300,
        multiSelect: false,
        selectChildren: false,
        addChildren: false,
        clickHandler: function (target) { },
        expandHandler: function (target, expanded) { },
        checkHandler: function (target, checked) { },
        expandElement: false,
        expandChildren: false,
        enableSearch: true,
        rtl: false,
        displayCount: false,
        clickTextSelect: true,
        selectParent: true,
        dropdownType: "dropdown", //dropdown,collapse
        ariaLabelId: 'dropdownMenu',
        prefixIdText: '',
        setSelectedElementsTitle: true
    };

    //data inits from options
    $.fn.DropDownTree = function (options) {
        //helpers
        $(this).attr("data-prefixidtext", options.prefixIdText);


        function RenderData(data, element) {
            for (var i = 0; i < data.length; i++) {
                globalTreeIdCounter++;
                if (data[i].Label !== '' && data[i].Label !== null) {
                    var dataAttrs = " data-title='" + data[i].Label.toUpperCase() + "'";
                    dataAttrs += " data-slug='" + (data[i].Slug || '') + "'";
                    if (typeof data[i].dataAttrs !== "undefined" && data[i].dataAttrs !== null) {
                        for (var d = 0; d < data[i].dataAttrs.length; d++) {
                            dataAttrs += " data-" + data[i].dataAttrs[d].Label + "='" + data[i].dataAttrs[d].Filters + "' ";
                        }
                    }
                    if (!element.is("li")) {
                        var activeCls = (data[i].Selected === true) ? 'active' : '';
                        var clickTxtSelCls = options.clickTextSelect ? 'drop-down-item' : '';

                        element.append('<li id=' + options.prefixIdText + data[i].ID + dataAttrs + '>' + ((options.multiSelect && data[i].Selected !== true) ? options.checkboxIcon : (!options.multiSelect ? '' : options.checkboxSelectedIcon)) + '<a href="' + ((typeof data[i].href !== "undefined" && data[i].href !== null) ? data[i].href : '#') + '" class="' + activeCls + " " + clickTxtSelCls + '">' + data[i].Label + '<small class="count">' + (options.displayCount === true && data[i].Count !== undefined ? '(' + data[i].Count + ')' : '') + '</small></a></li>');
                        if (data[i].Filters !== null && typeof data[i].Filters !== "undefined" && data[i].Filters.length > 0) {
                            if (subClassHasSomeJobs(data[i].Filters)) {
                                $("#" + options.prefixIdText + data[i].ID).append("<ul style='display:none'></ul>");
                                $("#" + options.prefixIdText + data[i].ID).find("a").first().prepend('<span class="arrow">' + options.closedArrow + '</span>');
                                RenderData(data[i].Filters, $("#" + options.prefixIdText + data[i].ID).find("ul").first());
                                if (data[i].Selected === true) {
                                    $("#" + options.prefixIdText + data[i].ID).find("ul").show();
                                    $("#" + options.prefixIdText + data[i].ID).find("a").first().find('span i').removeClass('fa-angle-right').addClass('fa-angle-down');
                                }
                            }
                        } else if (options.addChildren) {
                            $("#" + options.prefixIdText + data[i].ID).find("a").first().prepend('<span class="arrow">' + options.closedArrow + '</span>');
                        }
                    }
                    else {
                        element.find("ul").append('<li id=' + options.prefixIdText + data[i].ID + dataAttrs + '>' + (options.multiSelect ? options.checkboxIcon : '') + '<a href="' + ((typeof data[i].href !== "undefined" && data[i].href !== null) ? data[i].href : '#') + (options.clickTextSelect ? '"class=drop-down-item' : '"') + '>' + data[i].Label + '</a></li>');
                        if (data[i].Filters !== null && typeof data[i].Filters !== "undefined") {
                            $("#" + options.prefixIdText + data[i].ID).append("<ul style='display:none'></ul>");
                            $("#" + options.prefixIdText + data[i].ID).find("a").first().prepend('<span class="arrow">' + options.closedArrow + '</span>');
                            RenderData(data[i].Filters, $("#" + options.prefixIdText + data[i].ID).find("ul").first());
                        } else if (options.addChildren) {
                            $("#" + options.prefixIdText + data[i].ID).find("a").first().prepend('<span class="arrow">' + options.closedArrow + '</span>');
                        }
                    }
                }
            }

            if (options.expandChildren === true) {
                $(options.element).children("ul").find("ul").css('display', 'block');
                $(options.element).children("ul").find('span').children('i').removeClass('fa-angle-right');
                $(options.element).children("ul").find('span').children('i').addClass('fa-angle-down');
            }
        }

        options = $.extend({}, dropDownOptions, options, { element: this });


        //protos inits
        $(options.element).init.prototype.clickedElement = null;

        var tree = $(options.element);

        //handlers binders
        //element click handler
        $(options.element).on("click", "li", function (e) {
            tree.init.prototype.clickedElement = $(this);
            options.clickHandler(tree.clickedElement, e);
            e.stopPropagation();
        });

        $(options.element).on("click", "li a", function (e) {
            if ($(this).attr('href').indexOf('#') === 0) {
                e.preventDefault();
            }
            if ($(this).parent().find('ul').length && $(this).hasClass('active')) {
                $(this).find('.arrow').trigger('click');
            }
        });

        $(options.element).on("keyup", "input", function (o) {
            var text = $(this).val().toUpperCase();
            $(options.element).find("li").css("display", "block");
            $($(options.element).find("li")).each(function (i, el) {
                if (text !== '' && $(el).attr("data-title").startsWith(text)) {
                    $(el).addClass("filtered");
                }
                else if (text !== '') {
                    $(el).removeClass("filtered");
                    $(el).css("display", "none");
                }
            });
            $($(options.element).find("li").filter(".filtered")).each(function (i, t) {
                $(t).parents("li").css("display", "block");
            });

            if ($(this).val().length > 0) {
                $(options.element).children("ul").find("ul").css('display', 'block');
                $(options.element).children("ul").find('span').children('i').removeClass('fa-angle-right');
                $(options.element).children("ul").find('span').children('i').addClass('fa-angle-down');
            }
        });

        function subClassHasSomeJobs(subClassFilters) {
            var count = 0;
            for (var i = 0; i < subClassFilters.length; i++) {
                if (subClassFilters[i].Count === 0) {
                    count++;
                }
            }

            if (count === subClassFilters.length) {
                return false;
            } else {
                return true;
            }
        }

        function filterOptions(data, text) {

            if (text === '' || text === undefined)
                return data;
            text = text.toUpperCase();
            var filteredOptions = [];
            for (var i = 0; i < data.length; i++) {
                if (data[i].Filters !== undefined && data[i].Filters.length > 0) {
                    data[i].Filters = filterOptions(data[i].Filters, text);
                }
                if ((data[i].Filters !== undefined && data[i].Filters.length > 0) || data[i].Label.toUpperCase().startsWith(text))
                    filteredOptions.push(data[i]);
            }
            return filteredOptions;
        };

        //arrow click handler close/open
        $(options.element).on("click", ".arrow", function (e) {
            e.stopPropagation();
            e.preventDefault();
            $(this).empty();
            var expanded;
            if ($(this).parents("li").first().find("ul").first().is(":visible")) {
                expanded = false;
                $(this).prepend(options.closedArrow);
                $(this).parents("li").first().find("ul").first().hide();
            } else {
                expanded = true;
                $(this).prepend(options.openedArrow);
                $(this).parents("li").first().find("ul").first().show();
            }
            options.expandHandler($(this).parents("li").first(), e, expanded);
        });


        //select box click handler
        $(options.element).on("click", ".select-box", function (e) {
            e.stopPropagation();
            var checked;
            if ($(this).hasClass(options.checkboxIconClass)) {
                //will select
                checked = true;
                $(this).removeClass(options.checkboxIconClass);
                $(this).addClass(options.checkboxSelectedIconClass);
                $(this).parent("li").find("a").addClass("active");
                if (options.selectChildren) {
                    $(this).parents("li").first().find(".select-box").removeClass(options.checkboxIconClass);
                    $(this).parents("li").first().find(".select-box").addClass(options.checkboxSelectedIconClass);
                    $(this).parents("li").first().find("a").addClass("active");
                    $(this).parent("li").find("a .arrow").trigger('click');
                }
                if (options.selectParent) {
                    selectParent($(this));
                }
            } else {
                //will unselect
                checked = false;
                $(this).addClass(options.checkboxIconClass);
                $(this).removeClass(options.checkboxSelectedIconClass);
                $(this).parent("li").find("a").removeClass("active");
                if (options.selectChildren) {
                    $(this).parents("li").first().find(".select-box").addClass(options.checkboxIconClass);
                    $(this).parents("li").first().find(".select-box").removeClass(options.checkboxSelectedIconClass);
                    $(this).parents("li").first().find("a").removeClass("active");
                }
            }

            if (options.setSelectedElementsTitle)
                SetSelectedElementsTitle();

            options.checkHandler($(this).parents("li").first(), e, checked);
        });

        $(options.element).on("click", ".drop-down-item", function (e) {
            $(this).parent("li").children("i").first().trigger("click");
        });

        if (options.rtl) {
            $(options.element).addClass("rtl-dropdown-tree");
            if (options.closedArrow.indexOf("fa-angle-right") > -1) {
                options.closedArrow = options.closedArrow.replace("fa-angle-right", "fa-angle-left");
            }
        }

        var triggeringCls = '';
        var targetCls = '';
        var maxHt = Number(options.maxHeight) > 0 ? options.maxHeight + "px" : options.maxHeight;

        if (options.dropdownType === "collapse") {
            if (options.expandElement === true) {
                targetCls = 'show in';
            } else {
                triggeringCls = 'collapsed';
            }

            $(options.element).append('<a class="' + options.buttonClass + ' ' + triggeringCls + '" href="#' + options.ariaLabelId + '" data-toggle="collapse" aria-haspopup="true" aria-expanded="true" aria-controls="' + options.ariaLabelId + '"><span class="dropdowntree-name">' + options.title + '</span><span class="caret"></span></a>');
            $(options.element).append('<ul style="max-height: ' + maxHt + '" class="collapse ' + targetCls + '" id="' + options.ariaLabelId + '"></ul>');
        } else {
            if (options.expandElement === true) {
                targetCls = 'show';
            }
            $(options.element).append('<button class="' + options.buttonClass + '" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true"><span class="dropdowntree-name">' + options.title + '</span><span class="caret"></span></button>');
            $(options.element).append('<ul style="max-height: ' + maxHt + '" class="dropdown-menu ' + targetCls + '" aria-labelledby="' + options.ariaLabelId + '"></ul>');
        }

        if (options.enableSearch === true) {
            $(options.element).find("ul").first().append('<input type="text" class="form-control" placeholder="Type here to filter..." />');
        }

        if (options.data.length > 0) {
            options.data.forEach(option => {
                if (option.Slug) {
                    option.Slug = option.Slug.trim().replace(/[^\w]/gi, '-').replace(/-+/g, '-').toLowerCase();
                    if (option.Filters.length > 0) {
                        option.Filters.forEach(filter => {
                            if (filter.Slug) {
                                filter.Slug = filter.Slug.trim().replace(/[^\w\/]/gi, '-').replace(/-+/g, '-').replace(/-+$/g, '').toLowerCase();
                            }
                        })
                    }
                }
            });
        }

        //if (options) {
        //    options.element = $('#filtersPagePartialContent ' + $(options.element).selector);
        //    console.log(options.element);
        //}

        RenderData(options.data, $(options.element).find("ul").first());


        //protos inits
        $(options.element).init.prototype.GetParents = function () {
            var jqueryClickedElement = $(options.element).clickedElement;
            return $(jqueryClickedElement).parents("li");
        };


        $(options.element).init.prototype.SetTitle = function (title) {
            $(this).find(".dropdowntree-name").text(title);
        };

        $(options.element).init.prototype.GetSelected = function (title) {
            var selectedElements = [];
            $(this).find(".fa-check-square").each(function () {
                selectedElements.push($(this).parents("li").first());
            });
            return selectedElements;
        };

        $(options.element).init.prototype.GetSelectedElementIds = function (title) {
            var selectedElementIds = [];
            var prefixIdText = $(this).attr("data-prefixidtext");

            $.each($(this).GetSelected(), function (i, element) {
                var trimmedId = $(element).attr("id").slice(prefixIdText.length);
                selectedElementIds.push(trimmedId);
            });
            return selectedElementIds;
        };

        $(options.element).init.prototype.GetSelectedElementSlugs = function () {
            var selectedElementSlugs = [];

            $.each($(this).GetSelected(), function (i, element) {
                var trimmed = $.trim($(element).attr("data-slug"));
                if (trimmed !== '') {
                    selectedElementSlugs.push(trimmed);
                }
            });
            return selectedElementSlugs;
        };

        $(options.element).init.prototype.GetSelectedElementIdsAndSlugs = function (title) {
            var selectedElements = [];
            var prefixIdText = $(this).attr("data-prefixidtext");

            $.each($(this).GetSelected(), function (i, element) {
                element = $(element);

                var trimmedId = element.attr("id").slice(prefixIdText.length);
                var trimmedSlug = $.trim(element.attr("data-slug"));

                selectedElements.push({ id: trimmedId, slug: trimmedSlug });
            });

            return selectedElements;
        };

        $(options.element).init.prototype.GetSelectedElementsText = function (title) {
            var selectedElementText = [];
            $.each($(this).GetSelected(), function (i, element) {
                selectedElementText.push($(element).children('a').text());
            });
            return selectedElementText;
        };

        $(options.element).init.prototype.AddChildren = function (element, arrOfElements) {
            if (options.addChildren && $(element).find("ul").length === 0)
                $(element).append("<ul></ul>");
            element = $(element).find("ul").first();
            if (element.find("li").length === 0)
                RenderData(arrOfElements, element);
        };

        function SetSelectedElementsTitle() {
            var selectedElementText = $(options.element).GetSelectedElementsText();

            var titleText = options.title;
            if (selectedElementText.length > 3) {
                titleText = selectedElementText.length + " selected";
            }
            else if (selectedElementText.length > 0) {
                if (selectedElementText.length <= 2) {
                    titleText = selectedElementText.join(' - ');
                } else {
                    titleText = selectedElementText[0] + ' - ' + selectedElementText[1] + ', ' + selectedElementText[2];
                }
            }

            $(options.element).SetTitle(titleText);
        };

        function selectParent(ele) {
            var parent = ele.parent("li").first().parent("ul").first().parent("li").first();
            if (parent !== undefined && parent.length > 0) {
                parent.children("i").removeClass(options.checkboxIconClass);
                parent.children("i").addClass(options.checkboxSelectedIconClass);
                parent.children("a").addClass("active");
                selectParent(parent.children("i").first());
            }
        };

        if (options.setSelectedElementsTitle)
            SetSelectedElementsTitle();

        if ($('form[name="JobSearchResults"]').length > 0) {
            $('form[name="JobSearchResults"] select').each(function (index, element) {
                console.log($('form[name="JobSearchResults"] select[name="' + element.name + '"] > option'));
                $('form[name="JobSearchResults"] select[name="' + element.name + '"] > option').each(function (index, option) {
                    if ($(option).data('slug')) {
                        $(option).attr('data-slug', $(option).attr('data-slug').replace(/[^\w]/gi, '-').replace(/-+/g, '-').toLowerCase());
                        $(option).data('slug', $(option).data('slug').replace(/[^\w]/gi, '-').replace(/-+/g, '-').toLowerCase());
                    }
                })
            });
        }

    };
})(jQuery);

/**
 * For job search filter.
 * 
 * This creates a SEO friendly URL by converting GUID based search to Slug based search.
 *
 * Following properties should be set to same as what is used in backend:
 *    - JobSearchFilter.filterItemsDelimeter
 *    - JobSearchFilter.filterHierarchyDelimeter
 *    - JobSearchFilter.urlClassificationIdentifier
 *    - JobSearchFilter.urlCountryIdentifier
 * 
 * @see JXTNext.Sitefinity.Common.Constants.JobConstants
 */
var JobSearchFilter = {
    SeoUrlPartsModel: function () {
        this.Classification = null;
        this.SubClassification = null;
        this.Country = null;
        this.Location = null;
        this.Area = null;
    },

    filterItemsDelimeter: ',',
    filterHierarchyDelimeter: '/',
    urlClassificationIdentifier: 'jobs-in-',
    urlCountryIdentifier: 'in-',

    submitSearchForm: function (form) {
        var formData = {};
        var filterNames = {};

        var el, name, val, match, filterName;

        form = $(form);

        form.find(':input').each(function () {
            el = $(this);

            name = el.attr('name');
            if (!name) {
                return;
            }

            val = el.val();
            if (!val) {
                return;
            }

            // match input name with format Filters[xxx].Yyy;
            match = name.match(/^Filters\[(\d)\]\.(.+)/);
            if (match) {
                if (match[2] === 'rootId') {
                    filterNames[match[1]] = val;
                    formData[val] = [];
                }
                else {
                    filterName = filterNames[match[1]];
                    if (filterName) {
                        if (typeof (val) === 'object') {
                            for (var v in val) {
                                formData[filterName].push($('select[name="' + name + '"]').find('option[value="' + val[v] + '"]').data('slug'));
                            }
                        }
                        else {
                            formData[filterName].push($('select[name="' + name + '"]').find('option[value="' + val + '"]').data('slug'));
                        }
                    }
                }

                return;
            }

            formData[name] = val;
        });

        var seoUrlParts = new JobSearchFilter.SeoUrlPartsModel();

        var filterModel = {
            Filters: []
        };

        // following is not required
        delete formData['Salary.RootName'];

        for (var nameFData in formData) {
            val = formData[nameFData];

            if (nameFData === 'Classifications') {
                JobSearchFilter.createClassificationSeoPart(seoUrlParts, filterModel, val);
            }
            else if (nameFData === 'CountryLocationArea') {
                JobSearchFilter.createLocationSeoPart(seoUrlParts, filterModel, val);
            }
            else if (nameFData === 'WorkType') {
                JobSearchFilter.createWorkTypeSeoPart(seoUrlParts, filterModel, val);
            }
            else if (nameFData === 'CompanyName') {
                JobSearchFilter.createCompanyNameSeoPart(seoUrlParts, filterModel, val);
            }
            else if (nameFData === 'Salary.TargetValue') {
                val = $('select[name="' + name + '"]').find('option[value="' + val + '"]').data('slug');

                if (val) {
                    filterModel.SalaryType = val;
                }
            }
            else if (nameFData === 'Salary.LowerRange') {
                if (filterModel.SalaryType) {
                    filterModel.SalaryMin = val;
                }
            }
            else if (nameFData === 'Salary.UpperRange') {
                if (filterModel.SalaryType) {
                    filterModel.SalaryMax = val;
                }
            }
            else {
                filterModel[nameFData] = val;
            }
        }

        var url = form.attr('action');

        if (JobSearchFilter.hasSeoUrlParts(seoUrlParts)) {
            url += '/' + JobSearchFilter.createSeoPushStateUrl(seoUrlParts, filterModel);
        }
        else {
            var queryString = JobSearchFilter.makeQueryString(filterModel, '', false);
            if (queryString !== '') {
                url += '?' + queryString;
            }
        }

        window.location.href = url;

        return false;
    },

    createClassificationSeoPart: function (seoUrlPartsModel, filterModel, selectedItems) {
        if (selectedItems.length === 0) {
            return;
        }

        var hasMultipleClassifications = false;

        var classifications = [];
        var subClassifications = [];

        var selectedSlug;
        var parts;

        var length = selectedItems.length;

        for (var i = 0; i < length; i++) {
            selectedSlug = selectedItems[i];

            parts = selectedSlug.split(JobSearchFilter.filterHierarchyDelimeter);

            if (parts.length === 1) {
                classifications.push(selectedSlug);
            } else {
                subClassifications.push(selectedSlug);
            }
        }

        if (classifications.length > 0) {
            if (classifications.length === 1) {
                seoUrlPartsModel.Classification = classifications[0];
            }
            else {
                hasMultipleClassifications = true;
            }

            filterModel.Classification = classifications.join(JobSearchFilter.filterItemsDelimeter);
        }

        if (subClassifications.length > 0) {
            if (subClassifications.length === 1 && !hasMultipleClassifications) {
                seoUrlPartsModel.SubClassification = subClassifications[0];
            }

            filterModel.SubClassification = subClassifications.join(JobSearchFilter.filterItemsDelimeter);
        }
    },

    createLocationSeoPart: function (seoUrlPartsModel, filterModel, selectedItems) {
        if (selectedItems.length === 0) {
            return;
        }

        var hasMultipleCountries = false;
        var hasMultipleLocations = false;

        var countries = [];
        var locations = [];
        var areas = [];

        var selectedSlug;
        var parts;

        var length = selectedItems.length;

        for (var i = 0; i < length; i++) {
            selectedSlug = selectedItems[i];

            parts = selectedSlug.split(JobSearchFilter.filterHierarchyDelimeter);

            if (parts.length === 1) {
                countries.push(selectedSlug);
            } else if (parts.length === 2) {
                locations.push(selectedSlug);
            } else {
                areas.push(selectedSlug);
            }
        }

        if (countries.length > 0) {
            if (countries.length === 1) {
                seoUrlPartsModel.Country = countries[0];
            }
            else {
                hasMultipleCountries = true;
            }

            filterModel.Country = countries.join(JobSearchFilter.filterItemsDelimeter);
        }

        if (locations.length > 0) {
            if (locations.length === 1 && !hasMultipleCountries) {
                seoUrlPartsModel.Location = locations[0];
            }
            else {
                hasMultipleLocations = true;
            }

            filterModel.Location = locations.join(JobSearchFilter.filterItemsDelimeter);
        }

        if (areas.length > 0) {
            if (areas.length === 1 && !hasMultipleCountries && !hasMultipleLocations) {
                seoUrlPartsModel.Area = areas[0];
            }

            filterModel.Area = areas.join(JobSearchFilter.filterItemsDelimeter);
        }
    },

    createWorkTypeSeoPart: function (seoUrlPartsModel, filterModel, selectedItems) {
        if (selectedItems.length === 0) {
            return;
        }

        filterModel.WorkType = selectedItems.join(JobSearchFilter.filterItemsDelimeter);
    },

    createCompanyNameSeoPart: function (seoUrlPartsModel, filterModel, selectedItems) {
        if (selectedItems.length === 0) {
            return;
        }

        filterModel.CompanyName = selectedItems.join(JobSearchFilter.filterItemsDelimeter);
    },

    createSeoPushStateUrl: function (seoUrlParts, filterModel) {
        // work on a copy
        filterModel = filterModel ? $.extend({}, filterModel) : null;

        var urlParts = [];

        var classificationIdentifier = JobSearchFilter.urlClassificationIdentifier;
        var locationIdentifier = JobSearchFilter.urlCountryIdentifier;

        // check classification and sub-classification
        if (seoUrlParts.SubClassification) {
            urlParts.push(classificationIdentifier + seoUrlParts.SubClassification);

            if (filterModel) {
                delete filterModel['Classification'];
                delete filterModel['SubClassification'];
            }
        }
        else if (seoUrlParts.Classification) {
            urlParts.push(classificationIdentifier + seoUrlParts.Classification);

            if (filterModel) {
                delete filterModel['Classification'];
            }
        }

        // check country, location and area
        if (seoUrlParts.Area) {
            urlParts.push(locationIdentifier + seoUrlParts.Area);

            if (filterModel) {
                delete filterModel['Country'];
                delete filterModel['Location'];
                delete filterModel['Area'];
            }
        }
        else if (seoUrlParts.Location) {
            urlParts.push(locationIdentifier + seoUrlParts.Location);

            if (filterModel) {
                delete filterModel['Location'];
                delete filterModel['Country'];
            }
        }
        else if (seoUrlParts.Country) {
            urlParts.push(locationIdentifier + seoUrlParts.Country);

            if (filterModel) {
                delete filterModel['Country'];
            }
        }

        var result = urlParts.join('/');

        if (filterModel) {
            var queryString = JobSearchFilter.makeQueryString(filterModel, "", false);
            if (queryString !== '') {
                result += '?' + queryString;
            }
        }

        return result;
    },

    hasSeoUrlParts: function (seoUrlParts) {
        for (var i in seoUrlParts) {
            if (seoUrlParts[i]) {
                return true;
            }
        }

        return false;
    },

    makeQueryString: function (obj, prefix, isArray, queryStringArr) {
        if (!queryStringArr) {
            queryStringArr = [];
        }

        for (var p in obj) {
            if (obj.hasOwnProperty(p)) {
                var k, v;

                if (isArray)
                    k = prefix ? prefix + "%5B" + p + "%5D" : p, v = obj[p];
                else {
                    if (prefix.match(".values$"))
                        k = prefix ? prefix : p, v = obj[p];
                    else
                        k = prefix ? prefix + "." + p + "" : p, v = obj[p];
                }

                if (v !== null && typeof v === "object") {
                    if (Array.isArray(v)) {
                        if (k.match(".values$"))
                            JobSearchFilter.makeQueryString(v, k, false, queryStringArr);
                        else
                            JobSearchFilter.makeQueryString(v, k, true, queryStringArr);
                    } else {
                        JobSearchFilter.makeQueryString(v, k, false, queryStringArr);
                    }
                } else {
                    if (v === null || v === "undefined")
                        v = "";

                    var query = k + "=" + v;
                    queryStringArr.push(query);
                }
            }
        }

        return queryStringArr.join("&");
    }
};

if (typeof (JobSearchFilterOptions) !== "undefined") {
    JobSearchFilter = Object.assign(JobSearchFilter, JobSearchFilterOptions);
}

//code snipit to replace the "URLSearchParams"
//how it works was: https://developer.mozilla.org/en-US/docs/Web/API/URLSearchParams
$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results === null) {
        return null;
    }
    else {
        return decodeURI(results[1]) || 0;
    }
}
