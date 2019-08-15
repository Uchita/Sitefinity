var salarySurvey = salarySurvey || {};

(function ($) {
    var WidgetData = {
        EmptyOptionLabel: 'empty-option-label'
    };
    /**
     * Helper method to send json request and parse response as json.
     * 
     * @param {string} method
     * @param {string} url
     * @param {string|object} data
     * @param {function} scallback
     * @param {function} ecallback
     * @param {function} ecallback
    *  @param {object} container
     */
    function submitJsonRequest(method, url, data, scallback, ecallback, container) {
        var wait = null;

        var buttons = null;

        if (container) {
            buttons = container.find('button');

            buttons.attr('disabled', 'disabled');

            wait = container.find('.container-loader');
            if (wait.length == 0) {
                wait = null;
            }
            else {
                wait.show();
            }
        }

        $.ajax({
            method: method,
            url: url,
            data: data,
            dataType: 'json',
            cache: false
        }).done(function (response) {
            if (scallback) {
                scallback(response);
            }
        }).fail(function (jqXHR, textStatus) {
            if (ecallback) {
                var response;
                if (typeof (jqXHR.responseText) == 'undefined') {
                    response = {};
                }
                else {
                    try {
                        response = $.parseJson(jqXHR.responseText);
                    }
                    catch (err) {
                        response = {};
                    }
                }

                ecallback(response, jqXHR, textStatus);
            }
        }).always(function () {
            if (wait) {
                wait.hide();
            }

            if (buttons) {
                buttons.removeAttr('disabled');
                buttons.prop('disabled', false);
            }
        });
    }

    /**
     * Callback function to populate location list based on selected country.
     */
    function populateLocations(country) {
        var widget = country.closest('.salary-survey-widget');

        // clear location dropdown
        var location = widget.find('select[name="LocationId"]');
        location.html('<option value="">' + widget.data(WidgetData.EmptyOptionLabel) + '</option>');

        var val = country.val();
        if (val == null || val == '') {
            return;
        }

        var loader = location.closest('.form-group').find('.element-loader');

        loader.show();

        var onSuccess = function (response) {
            loader.hide();

            var option;

            var len = response.length;

            for (var i = 0; i < len; i++) {
                option = response[i];

                location.append('<option value="' + option.Value + '">' + option.Text + '</option>');
            }

            var lastValue = location.data('last_value');
            if (lastValue != null) {
                location.val(lastValue);
            }
        };

        var onError = function (response, jqXHR, textStatus) {
            loader.hide();

            console.log(jqXHR);
        };

        submitJsonRequest('GET', SalarySurvey_CurrentPage + '/GetLocations', { countryId: val }, onSuccess, onError);
    }

    /**
     * Callback function to populate classification list based on selected industry.
     */
    function populateClassifications(industry) {
        var widget = industry.closest('.salary-survey-widget');

        // clear classification dropdown
        var classification = widget.find('select[name="ClassificationId"]');
        classification.html('<option value="">' + widget.data(WidgetData.EmptyOptionLabel) + '</option>');

        // clear sub-classification dropdown
        var subClassification = widget.find('select[name="SubClassificationId"]');
        subClassification.html('<option value=""></option>');

        var val = industry.val();
        if (val == null || val == '') {
            return;
        }

        var loader = classification.closest('.form-group').find('.element-loader');

        loader.show();

        var onSuccess = function (response) {
            loader.hide();

            var option;

            var len = response.length;

            for (var i = 0; i < len; i++) {
                option = response[i];

                classification.append('<option value="' + option.Value + '">' + option.Text + '</option>');
            }

            var lastValue = classification.data('last_value');
            if (lastValue != null) {
                classification.val(lastValue);
            }

            populateSubClassifications(classification);
        };

        var onError = function (response, jqXHR, textStatus) {
            loader.hide();

            console.log(jqXHR);
        };

        submitJsonRequest('GET', SalarySurvey_CurrentPage + '/GetClassifications', { industryId: val }, onSuccess, onError);
    }

    /**
     * Callback function to populate sub-classification list based on selected classification.
     */
    function populateSubClassifications(classification) {
        var widget = classification.closest('.salary-survey-widget');

        // clear sub-classification
        var subClassification = widget.find('select[name="SubClassificationId"]');
        subClassification.html('<option value="">' + widget.data(WidgetData.EmptyOptionLabel) + '</option>');

        var val = classification.val();
        if (val == null || val == '') {
            return;
        }

        var subClassificationLoader = subClassification.closest('.form-group').find('.element-loader');

        subClassificationLoader.show();

        var onSuccess = function (response) {
            subClassificationLoader.hide();

            var option;

            var len = response.length;

            for (var i = 0; i < len; i++) {
                option = response[i];

                subClassification.append('<option value="' + option.Value + '">' + option.Text + '</option>');
            }

            var lastValue = subClassification.data('last_value');
            if (lastValue != null) {
                subClassification.val(lastValue);
            }
        };

        var onError = function (response, jqXHR, textStatus) {
            subClassificationLoader.hide();

            console.log(jqXHR);
        };

        var industry = widget.find('select[name="IndustryId"]');

        submitJsonRequest('GET', SalarySurvey_CurrentPage + '/GetSubClassifications', { industryId: industry.val(), classificationId: val }, onSuccess, onError);
    }

    /**
     * Callback function to populate money to leave list.
     */
    function populateMoneyToLeaveOptions(widget, hourly) {
        var el = widget.find('select[name="MoneyToLeave"]');

        el.html('<option value="">' + widget.data(WidgetData.EmptyOptionLabel) + '</option>');

        el.append('<option value="-1">None - I\'m happy where I am</option>');
        el.append('<option value="0">None - I\'d leave for LESS money</option>');

        if (hourly) {
            var max = salarySurveyMaxHourlyMoneyToLeave;

            for (var i = 1; i <= 50; i++) {
                el.append('<option value="' + i + '">A ' + salarySurveyCurrencySymbol + i + ' increase per hour</option>');
            }

            for (var i = 60; i <= max; i += 10) {
                el.append('<option value="' + i + '">A ' + salarySurveyCurrencySymbol + i + (i == max ? '+' : '') + ' increase per hour</option>');
            }
        }
        else {
            var max = salarySurveyMaxAnnualMoneyToLeave;

            el.append('<option value="100">A ' + salarySurveyCurrencySymbol + '100 increase per year</option>');

            for (var i = 500; i <= max; i += 500) {
                el.append('<option value="' + i + '">A ' + salarySurveyCurrencySymbol + i + (i == max ? '+' : '') + ' increase per year</option>');
            }
        }

        el.val(widget.find('[name="SelectedMoneyToLeave"]').val());
    }

    /**
     * Callback function to submit a form via AJAX request.
     */
    function submitAjaxForm(e) {
        e.preventDefault();

        var form = $(this);

        var onSuccess = function (response) {
            console.log(response);

            alert(1);
        };

        var onError = function (response, jqXHR, textStatus) {
            console.log(jqXHR);

            alert(response.response);
        };

        submitJsonRequest(
            form.attr('method'),
            form.attr('action'),
            form.serialize(),
            onSuccess,
            onError,
            form
        );
    }

    /**
     * Callback function to draw various graphs present in the page.
     */
    function drawGraphs() {
        var searchResult = typeof (salarySearchResult) == 'undefined' ? {} : salarySearchResult;

        var calculatorResult = typeof (salaryCalculatorResult) == 'undefined' ? {} : salaryCalculatorResult;

        // for median graph widget
        $('.median-salary-graph').each(function () {
            var el = $(this);

            var result = $.extend({
                medianMin: 0,
                medianLower: 0,
                median: 0,
                medianUpper: 0,
                medianMax: 0,
                salaryLabel: 'Salary'
            }, searchResult);

            var heading = el.closest('.salary-survey-widget').find('.widget-heading');
            heading.text(heading.text().replace("{0}", result.salaryLabel));

            el.highcharts({
                chart: {
                    type: 'column'
                },
                credits: {
                    enabled: false
                },
                legend: {
                    enabled: false
                },
                title: {
                    text: null
                },
                subtitle: {
                    text: null
                },
                xAxis: {
                    categories: ['0%', '25%', '50%', '75%', '100%']
                },
                yAxis: {
                    title: {
                        text: null
                    },
                    min: 0,
                    plotLines: [{
                        value: 0,
                        width: 1,
                        color: el.data('plot-lines-colour')
                    }]
                },
                tooltip: {
                    formatter: function () {
                        return this.point.name;
                    }
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true,
                            format: '${y:,.0f}'
                        }
                    }
                },
                series: [{
                    color: el.data('series-bar-colour'),
                    data: [
                        { name: 'Minimum', y: result.medianMin },
                        { name: 'Lower Quartile', y: result.medianLower },
                        { name: 'Median', y: result.median },
                        { name: 'Upper Quartile', y: result.medianUpper },
                        { name: 'Maximum', y: result.medianMax }
                    ]
                },
                {
                    type: 'spline',
                    color: el.data('series-spline-colour'),
                    data: [
                        { name: 'Minimum', y: result.medianMin },
                        { name: 'Lower Quartile', y: result.medianLower },
                        { name: 'Median', y: result.median },
                        { name: 'Upper Quartile', y: result.medianUpper },
                        { name: 'Maximum', y: result.medianMax }
                    ]
                }]
            });
        });

        // for salary calculator graph widget
        $('.salary-calculator-graph').each(function () {
            var el = $(this);

            var result = $.extend({
                years: 0,
                s1: [],
                s2: [],
                s3: []
            }, calculatorResult);

            var heading = el.closest('.salary-survey-widget').find('.widget-heading');
            if (heading.length > 0) {
                heading.text(heading.text().replace("%1", result.salaryLabel));
            }

            var idx;

            var categories = new Array();
            for (idx = 1; idx <= result.years; idx++) {
                categories[idx - 1] = idx;
            }

            el.highcharts({
                chart: {
                    type: 'column'
                },
                credits: {
                    enabled: false
                },
                legend: {
                    enabled: true
                },
                title: {
                    text: null
                },
                subtitle: {
                    text: null
                },
                xAxis: {
                    categories: categories,
                    color: el.data('plot-lines-colour'),
                },
                yAxis: {
                    title: {
                        text: null
                    },
                    min: 0,
                    lineColor: el.data('plot-lines-colour'),
                    plotLines: [{
                        value: 0,
                        width: 5,
                        color: el.data('plot-lines-colour')
                    }]
                },
                tooltip: {
                    enabled: false
                },
                plotOptions: {
                    spline: {
                        dataLabels: {
                            enabled: false,
                            format: '${y:,.0f}'
                        },
                        marker: {
                            enabled: false
                        },
                        lineWidth: 4,
                        color: el.data('plot-lines-colour'),
                    }
                },
                series: [
                    {
                        type: 'spline',
                        name: 'Cumulative Increase',
                        data: result.s1,
                        color: el.data('salary-increase-spline-colour')
                    },
                    {
                        type: 'spline',
                        name: 'Increase in Super',
                        data: result.s2,
                        color: el.data('super-increase-spline-colour')
                    },
                    {
                        type: 'spline',
                        name: 'Total Increase',
                        data: result.s3,
                        color: el.data('total-increase-spline-colour')
                    }
                ]
            });
        });
    }

    /**
     * Callback function to show hide wages field based on selected job type.
     */
    function showHideWagesField() {
        el = $(this);

        var widget = el.closest('.salary-survey-widget');

        var target = widget.find('.form-group-Wages');
        if (target.length == 0) {
            return;
        }

        var val = el.val();

        var annual;

        if (val == '') {
            annual = true;
        }
        else {
            annual = false;

            for (var i in annualSalaryJobTypes) {
                if (annualSalaryJobTypes[i] == val) {
                    annual = true;

                    break;
                }
            }
        }

        if (annual) {
            target.find('.hourly-rate-section').hide();
            target.find('.annual-salary-section').show();

            populateMoneyToLeaveOptions(widget, false);
        }
        else {
            target.find('.hourly-rate-section').show();
            target.find('.annual-salary-section').hide();

            populateMoneyToLeaveOptions(widget, true);
        }
    }

    /**
     * Callback function to show hide fields for contact request.
     */
    function showHideNameContactRequestFields() {
        el = $(this);

        var widget = el.closest('.salary-survey-widget');

        var checked = widget.find('input[name="ContactRequest"]:checked');

        var yes = false;

        if (checked.length == 1 && checked.val() == 'true') {
            yes = true;
        }

        if (yes) {
            widget.find('input[name="Name"]').show();
            widget.find('input[name="Phone"]').show();
        }
        else {
            widget.find('input[name="Name"]').hide();
            widget.find('input[name="Phone"]').hide();
        }
    }

    /**
     * Callback function to set last value data for an element.
     */
    function setLastValueData() {
        var el = $(this);

        el.data('last_value', el.val());
    }

    /**
     * To initialise submit and search widget.
     */
    function initSubmitSearchWidget(widget) {
        // Populate location list on country change.
        var countryEl = widget.find('select[name="CountryId"]');
        countryEl.change(function () {
            populateLocations($(this));
        });

        // Check if we need to populate locations on page load
        var locationEl = widget.find('select[name="LocationId"]');
        if (countryEl.length > 0 && locationEl.length > 0 && locationEl.children().length < 2) {
            populateLocations(countryEl);
        }

        // Populate classification list on industry change.
        var industryEl = widget.find('select[name="IndustryId"]');
        industryEl.change(function () {
            populateClassifications($(this));
        });

        // Check if we need to populate classification on page load
        var classificationEl = widget.find('select[name="ClassificationId"]');
        if (industryEl.length > 0 && classificationEl.length > 0 && classificationEl.children().length < 2) {
            populateClassifications(industryEl);
        }

        // Populate sub-classification list on classification change.
        classificationEl.change(function () {
            populateSubClassifications($(this));
        });

        // Check if we need to populate sub-classification on page load
        var subClassificationEl = widget.find('select[name="SubClassificationId"]');
        if (classificationEl.length > 0 && subClassificationEl.length > 0 && subClassificationEl.children().length < 2) {
            populateSubClassifications(classificationEl);
        }

        // Show/Hide wages field.
        widget.find('select[name="JobTypeId"]').change(showHideWagesField).change();

        // Show/Hide contact fields.
        widget.find('input[name="ContactRequest"]').change(showHideNameContactRequestFields).change();
    }

    var widgets = $('.salary-survey-widget');

    // Preserve current value of dropdown for use in dynamic list loading
    var select = widgets.find('select');
    select.on('change', setLastValueData);
    select.each(setLastValueData);

    // initialse each widgets
    widgets.each(function () {
        var widget = $(this);

        if (widget.hasClass('salary-survey-widget-submit-salary') || widget.hasClass('salary-survey-widget-search-salary')) {
            initSubmitSearchWidget(widget);
        }
    });

    // Submit forms via AJAX.
    $('.salary-survey-widget form.ajax').on('submit', submitAjaxForm);

    $.getScript('https://jxtco01-01-prod-php-public.s3.amazonaws.com/common/highcharts/js/highcharts.js', drawGraphs);

    salarySurvey.showHideGrossNetOptions = function (el) {
        el = $(el);

        var widget = el.closest('.salary-survey-widget');

        var target = widget.find('.calculator-options');

        if (target.is(':visible')) {
            target.slideUp();

            el.find('.more').show();
            el.find('.less').hide();
        }
        else {
            target.slideDown();

            el.find('.more').hide();
            el.find('.less').show();
        }
    };
})(jQuery);
