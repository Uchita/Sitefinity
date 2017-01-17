<%@ Page Title="Dynamic Page Edit" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="True" CodeBehind="DynamicPageRevisions.aspx.cs" Inherits="JXTPortal.Website.Admin.DynamicPageRevisions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <!-- External JS files -->
    <%-- script type="text/javascript" src="http://www.psc.nsw.gov.au/include/js/jquery-1.7.min.js"></script --%>
    <script type="text/javascript" src="/admin/js/myjs.js"></script>
    <script type="text/javascript" src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
    <!-- External CSS files -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <link href="/admin/css/select2.css" rel="stylesheet" />
    <link href="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/build/css/bootstrap-datetimepicker.css"
        rel="stylesheet">
    <script type="text/javascript" src="/admin/js/select2.js"></script>
    <script type="text/javascript">
        function CharaterCount(textboxid, spanid, max) {
            var len = $("#" + textboxid).val().length;
            $("#" + spanid).text("Character Count: " + len);
            if (len > max) {
                $("#" + spanid).css("color", "red");
            }
            else {
                $("#" + spanid).css("color", "black");
            }
        }
        /*
        $(function () {

        var hostName = (window.location.hostname);
        //alert(hostName.toLowerCase().indexOf("fmplus.com"));

        if (hostName.toLowerCase().indexOf("chandlermacleod.com") >= 0) {
        $('#Li3').hide();
        }
        });*/
        $(function () {

            $(".edit-detail-link").click(function (e) {
                e.preventDefault();
                $(this).parent().next(".detail-edit").show();
            });
            $(".cancel-button").click(function (e) {
                e.preventDefault();
                $(this).closest(".detail-edit").hide();
            });

            //init
            if(<%= (Request["revisioncode"] != null).ToString().ToLower() %>)
            {
                $(".detail-edit").show();
            }

        });
    </script>
    <!--<script type="text/javascript">
/* ========================================================================
 * Bootstrap: collapse.js v3.3.6
 * http://getbootstrap.com/javascript/#collapse
 * ========================================================================
 * Copyright 2011-2016 Twitter, Inc.
 * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
 * ======================================================================== */


+function ($) {
  'use strict';

  // COLLAPSE PUBLIC CLASS DEFINITION
  // ================================

  var Collapse = function (element, options) {
    this.$element      = $(element)
    this.options       = $.extend({}, Collapse.DEFAULTS, options)
    this.$trigger      = $('[data-toggle="collapse"][href="#' + element.id + '"],' +
                           '[data-toggle="collapse"][data-target="#' + element.id + '"]')
    this.transitioning = null

    if (this.options.parent) {
      this.$parent = this.getParent()
    } else {
      this.addAriaAndCollapsedClass(this.$element, this.$trigger)
    }

    if (this.options.toggle) this.toggle()
  }

  Collapse.VERSION  = '3.3.6'

  Collapse.TRANSITION_DURATION = 350

  Collapse.DEFAULTS = {
    toggle: true
  }

  Collapse.prototype.dimension = function () {
    var hasWidth = this.$element.hasClass('width')
    return hasWidth ? 'width' : 'height'
  }

  Collapse.prototype.show = function () {
    if (this.transitioning || this.$element.hasClass('in')) return

    var activesData
    var actives = this.$parent && this.$parent.children('.panel').children('.in, .collapsing')

    if (actives && actives.length) {
      activesData = actives.data('bs.collapse')
      if (activesData && activesData.transitioning) return
    }

    var startEvent = $.Event('show.bs.collapse')
    this.$element.trigger(startEvent)
    if (startEvent.isDefaultPrevented()) return

    if (actives && actives.length) {
      Plugin.call(actives, 'hide')
      activesData || actives.data('bs.collapse', null)
    }

    var dimension = this.dimension()

    this.$element
      .removeClass('collapse')
      .addClass('collapsing')[dimension](0)
      .attr('aria-expanded', true)

    this.$trigger
      .removeClass('collapsed')
      .attr('aria-expanded', true)

    this.transitioning = 1

    var complete = function () {
      this.$element
        .removeClass('collapsing')
        .addClass('collapse in')[dimension]('')
      this.transitioning = 0
      this.$element
        .trigger('shown.bs.collapse')
    }

    if (!$.support.transition) return complete.call(this)

    var scrollSize = $.camelCase(['scroll', dimension].join('-'))

    this.$element
      .one('bsTransitionEnd', $.proxy(complete, this))
      .emulateTransitionEnd(Collapse.TRANSITION_DURATION)[dimension](this.$element[0][scrollSize])
  }

  Collapse.prototype.hide = function () {
    if (this.transitioning || !this.$element.hasClass('in')) return

    var startEvent = $.Event('hide.bs.collapse')
    this.$element.trigger(startEvent)
    if (startEvent.isDefaultPrevented()) return

    var dimension = this.dimension()

    this.$element[dimension](this.$element[dimension]())[0].offsetHeight

    this.$element
      .addClass('collapsing')
      .removeClass('collapse in')
      .attr('aria-expanded', false)

    this.$trigger
      .addClass('collapsed')
      .attr('aria-expanded', false)

    this.transitioning = 1

    var complete = function () {
      this.transitioning = 0
      this.$element
        .removeClass('collapsing')
        .addClass('collapse')
        .trigger('hidden.bs.collapse')
    }

    if (!$.support.transition) return complete.call(this)

    this.$element
      [dimension](0)
      .one('bsTransitionEnd', $.proxy(complete, this))
      .emulateTransitionEnd(Collapse.TRANSITION_DURATION)
  }

  Collapse.prototype.toggle = function () {
    this[this.$element.hasClass('in') ? 'hide' : 'show']()
  }

  Collapse.prototype.getParent = function () {
    return $(this.options.parent)
      .find('[data-toggle="collapse"][data-parent="' + this.options.parent + '"]')
      .each($.proxy(function (i, element) {
        var $element = $(element)
        this.addAriaAndCollapsedClass(getTargetFromTrigger($element), $element)
      }, this))
      .end()
  }

  Collapse.prototype.addAriaAndCollapsedClass = function ($element, $trigger) {
    var isOpen = $element.hasClass('in')

    $element.attr('aria-expanded', isOpen)
    $trigger
      .toggleClass('collapsed', !isOpen)
      .attr('aria-expanded', isOpen)
  }

  function getTargetFromTrigger($trigger) {
    var href
    var target = $trigger.attr('data-target')
      || (href = $trigger.attr('href')) && href.replace(/.*(?=#[^\s]+$)/, '') // strip for ie7

    return $(target)
  }


  // COLLAPSE PLUGIN DEFINITION
  // ==========================

  function Plugin(option) {
    return this.each(function () {
      var $this   = $(this)
      var data    = $this.data('bs.collapse')
      var options = $.extend({}, Collapse.DEFAULTS, $this.data(), typeof option == 'object' && option)

      if (!data && options.toggle && /show|hide/.test(option)) options.toggle = false
      if (!data) $this.data('bs.collapse', (data = new Collapse(this, options)))
      if (typeof option == 'string') data[option]()
    })
  }

  var old = $.fn.collapse

  $.fn.collapse             = Plugin
  $.fn.collapse.Constructor = Collapse


  // COLLAPSE NO CONFLICT
  // ====================

  $.fn.collapse.noConflict = function () {
    $.fn.collapse = old
    return this
  }


  // COLLAPSE DATA-API
  // =================

  $(document).on('click.bs.collapse.data-api', '[data-toggle="collapse"]', function (e) {
    var $this   = $(this)

    if (!$this.attr('data-target')) e.preventDefault()

    var $target = getTargetFromTrigger($this)
    var data    = $target.data('bs.collapse')
    var option  = data ? 'toggle' : $this.data()

    Plugin.call($target, option)
  })

}(jQuery);
</script> -->
    <style type="text/css">
/* 3col styles */

.dropdown-menu
{
	top:30px !important;
	bottom:auto !important;
}
.bootstrap-datetimepicker-widget.dropdown-menu { width: auto; }
#left-column
{
  float: left;
  width: 67%;
}
#right-column
{
  float: right;
  margin-left: 3%;
  width: 30%;
  margin-top: 50px;
}

.glyphicon-calendar {display:none; }
.add-edit-page /*name of form */
{

}
#publish 
{
  /*overflow: hidden;*/
/*  padding:0 5px 0 15px; */
  border: solid 1px #ccc;
  border-radius: 5px;
  position: relative;
}
#publish h2 
{
  padding: 10px;
  color: #000;
  margin-bottom: 20px;
  margin-top: 0;
}
#publish > input[type=submit]
{
  width: 48%;
  margin: 15px 0;
}
#publish > input[type=submit][disabled]
{
  background: #ccc;
}
#publish > input[type=submit]:nth-of-type(2n+1)
{
  clear: both;
  float: left;
}
#publish > input[type=submit]:nth-of-type(2n+2)
{
  float: right;
}

#publish #publish-details
{
  padding: 0;
  margin: 10px;
}
#publish .publish-label
{
  clear: both;
  float: left;
  min-width: 30%;
  padding: 10px 0;
}
#publish .publish-detail
{
/*  float: right; */
  width: 100%;
  font-weight: bold;
  border-bottom: 1px solid #f4f4f4;
  padding: 10px 0;
}
#publish .detail-edit
{
  clear: both;
  background: #fcfcfc;
  padding: 0 10px;
  border-left: 1px solid #f4f4f4;
  border-right: 1px solid #f4f4f4;
  border-bottom: 1px solid #f4f4f4;
}

#publish select
{
  padding: 4px 5px;
  height: 30px;
  box-sizing: border-box;
  margin-right: 5px;
}

#publish .publish-detect-changes
{
	margin-left:35px;
	list-style: square;
	clear:both;
}

#publish input[type=text]
{
  padding: 5px;
  margin-right: 5px;
  font-size: 16px;
  box-sizing: border-box;
  height: 30px;
}

.detail-edit
{
  display: none;
}

#tableRevision tr.selected
{
    background-color:#d9edf7;
}

.cancel-button
{
  display: inline-block;
/*  padding: 6px 10px; */
  margin: 15px 0;
  line-height: 1.5;
}

#tableRevision
{
  border: 0;
}

#tableRevision th, 
#tableRevision td
{
  border: 0;
  border-right: solid 1px #000;
  border-bottom: solid 1px #000;

  background: transparent;
  color: #000;
  font-size: 12px;
}
#tableRevision th:last-child, 
#tableRevision td:last-child
{
  border-right: 0;
}


#download-documentation
{
  clear: both;
}
#pending-jobs
{
  float:left;
  width: 48%;
  margin: 0 0 3em 0;
}
#pending-jobs table
{
  width: 100%;

  box-sizing: border-box;
}



.InputAddOn {
  display: flex;
  margin-bottom: 0;
  width: 77% !important;
}

.InputAddOn-field {
  flex: 1;
}
.InputAddOn-field:not(:first-child) {
  border-left: 0;
}
.InputAddOn-field:not(:last-child) {
  border-right: 0;
}

.InputAddOn-item {
  background-color: rgba(147, 128, 108, 0.1);
  color: #666666;
  font: inherit;
  font-weight: normal;
}

.InputAddOn-field,
.InputAddOn-item {
  border: 1px solid rgba(147, 128, 108, 0.25);
  padding: 0.35em 0.75em;
}
.InputAddOn-field:first-child,
.InputAddOn-item:first-child {
  border-radius: 2px 0 0 2px;
}
.InputAddOn-field:last-child,
.InputAddOn-item:last-child {
  border-radius: 0 2px 2px 0;
}

#pending-pages
{
  float: right;
  width: 48%;
  margin: 0 0 3em 0;
}
#pending-pages table
{
  width: 100%;

  box-sizing: border-box;
}

/*.coda-slider, .coda-slider .panel {
  width:100% !important;
}*/

.btn-half {
  width:45%;
}

.publish-btn-holder .btn {
  background: #3498db;
  background-image: -webkit-linear-gradient(top, #3498db, #2980b9);
  background-image: -moz-linear-gradient(top, #3498db, #2980b9);
  background-image: -ms-linear-gradient(top, #3498db, #2980b9);
  background-image: -o-linear-gradient(top, #3498db, #2980b9);
  background-image: linear-gradient(to bottom, #3498db, #2980b9);
  -webkit-border-radius: 3;
  -moz-border-radius: 3;
  border-radius: 3px;
  font-family: Arial;
  color: #ffffff;
  font-size: 14px;
  padding: 7px 20px;
  text-decoration: none;
  margin:0 5px;
  text-align: center;
  min-width:70px;
}

.publish-btn-holder {
  margin:0;
  clear:both;
  display: block;
  width: 100%;
  background: #f4f4f4;
  padding-top: 10px;
  padding-right: 5px;
}
.preview-btn-holder {
  margin:10px 5px;
  clear:both;
  position: absolute;
  right: 0;
  top: 0;
}

.publish-btn-holder .btn{
  margin-bottom: 10px;
}

@media screen and (min-width: 1335px) and (max-width: 2000px) {
    .publish-btn-holder .btn, .preview-btn-holder .btn, #publish-details input[type="submit"] .btn{
  font-size: 12px;
  padding: 10px;
  }
  .preview-btn-holder .btn, #publish-details input[type="submit"] .btn{
    background: #f4f3f0 !important;
    color: #000 !important;
    border:1px solid #dcd7d0 !important;
  }
  .preview-btn-holder .btn:hover, #publish-details input[type="submit"] .btn:hover{
    background: #f4f4f4;
    color: #000000;
  }
}



@media screen and (max-width: 1335px) {
    .publish-btn-holder .btn{
  width: 50%;
  }
  #publish .publish-label{

  }
}

@media screen and (max-width: 1400px) {
  .preview-btn-holder{
    position: relative;
    display: inline-block;
  }
  #publish h2{
    margin-bottom: 0;
  }

}

.pull-right {
  float:right;
}

.pull-left {
  float:left;
}

.publish-btn-holder .btn:hover {
  background: #3cb0fd;
  background-image: -webkit-linear-gradient(top, #3cb0fd, #3498db);
  background-image: -moz-linear-gradient(top, #3cb0fd, #3498db);
  background-image: -ms-linear-gradient(top, #3cb0fd, #3498db);
  background-image: -o-linear-gradient(top, #3cb0fd, #3498db);
  background-image: linear-gradient(to bottom, #3cb0fd, #3498db);
  text-decoration: none;
  color:#FFF;
}


#content input[type="button"], #content input[type="submit"], #content input[type="reset"] {
    background:background: #49c0f0; /* Old browsers */
/* IE9 SVG, needs conditional override of 'filter' to 'none' */
background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iIzQ5YzBmMCIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiMyY2FmZTMiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
background: -moz-linear-gradient(top, #49c0f0 0%, #2cafe3 100%); /* FF3.6+ */
background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#49c0f0), color-stop(100%,#2cafe3)); /* Chrome,Safari4+ */
background: -webkit-linear-gradient(top, #49c0f0 0%,#2cafe3 100%); /* Chrome10+,Safari5.1+ */
background: -o-linear-gradient(top, #49c0f0 0%,#2cafe3 100%); /* Opera 11.10+ */
background: -ms-linear-gradient(top, #49c0f0 0%,#2cafe3 100%); /* IE10+ */
background: linear-gradient(to bottom, #49c0f0 0%,#2cafe3 100%); /* W3C */
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#49c0f0', endColorstr='#2cafe3',GradientType=0 ); /* IE6-8 */
    border-radius: 5px;
    border:1px solid #2cafe3;
    color: #fff;
    font-family: helvetica;
    padding: 5px 10px;
    white-space: pre;
}

.section-header {
    font-size: 2em;
    color:#333;
    font-weight: bold;
    margin:10px 0 5px;
    line-height: 2em;
    }
    .label-holder {
        display:inline-block;
        width:20%;
        float:left;
        text-align: right;
    }

    .label-holder label {
        font-weight: normal;
        font-size:13px;
        color:#333;
        vertical-align: baseline;
        line-height: 2.2em;
    }

    .form-element-holder {
/*        display: inline-block; */
        width: 77%;
        margin-left: 2%;
        float: left;
        text-align: left;
    }

    .form-element-holder2 {
        display: inline-block;
        width: 100%;
        float: left;
        text-align: left;
    }
    .form-element {
        width:100%;
        height:30px;
        vertical-align: center;
        padding:0px 5px;
        border:1px solid rgba(147, 128, 108, 0.25);
    }

    input.form-element.small {
        width:18%;
        height:30px;
        vertical-align: center;
        padding:0px 5px;
    }

    input.form-element.med {
/*        width:44%; */
        height:30px;
        vertical-align: center;
        padding:0px 5px;
    }

    textarea.form-element {
        width:100%;
        height:auto;
        vertical-align: center;
        padding:5px 5px;
    }
    select.form-element {
        width:100%;
        height:35px;
        vertical-align: center;
        padding:5px 5px !important;
    }

    .form-elements-linebreak {
        border: 1px dashed #DADADA;
        margin-bottom: 20px;
        width: 100%;
        }

     .required {
        color:red;
     }

    .form-elements-group {
        clear:both;
        display:block;
        width:100%;
        margin-bottom: 20px;
        float:left;
    }
    .help-block {
        font-size: 11px;
        color:#333;
        opacity: 0.7;
        text-align: left;
        line-height:2em;
        margin-left: 23%;
        margin-top: 5px;
        clear:both;
    }
    .help-block-error {
        font-size: 11px;
        color:red;
        opacity: 0.7;
        line-height:2em;
        color:red;
        text-align: left;
        margin-left: 23%;
        margin-top: 5px;
        clear:both;
    }

    .help-block-success {
        font-size: 11px;
        color:green;
        opacity: 0.7;
        line-height:2em;
        text-align: left;
        margin-left: 23%;
        margin-top: 5px;
        clear:both;
    }

    .form-elements-group label {
        clear:both;
        display:block;
        width:100%;
        line-height: 2.2em;
        font-size: 13px;
    }
    .form-elements-group input[type="checkbox"] {
        margin-right:10px;
    }

    .no-marg-btm { 
margin-bottom: 0px;
}

.stickem-container {
  position: relative;
}

.stickit {
    margin-left: 660px;
    position: fixed;
    top: 0;`
}

.stickit-end {
    bottom: 40px;
    position: absolute;
    right: 0;
}


/* Additional styles */
/*.coda-slider-wrapper{
  overflow: visible !important;
}*/
.edit-detail-link{
  font-weight: normal;
  margin-left: 10px;
}
#publish-details input[type="submit"]{
  background: #f4f3f0;
  color: #000;
  border: 1px solid #dcd7d0;
  border-radius: 3px;
  font-size: 12px;
}
.fa-trash{
  font-size:20px;
  padding: 6px 15px;
  color: #000;
}
.fa-trash:hover{
  color: red;
}
.button-panel, .button-panel .btn{
  margin-left: 0;
}
.coda-slider{
  padding: 0 !important;
}
#content h2{
  text-transform: uppercase;
  font-size: 130%;
  font-weight: bold;
}
/*#coda-nav-1 .tab1{
  float: right;
  padding-bottom: 10px !important;
}*/
.fa-comments-o{
  color: #fff;
  font-size: 23px !important;
}
.edit-detail-link, td a, .cancel-button{
  text-decoration: underline;
  font-size: 12px;
}

/* end 3col styles */

/* accordion styles */

#accordion {
    clear: both;
}
#accordion .panel {
    border-radius: 3px;
    box-shadow: none;
/*    border: 1px solid #0085cc; */
    margin: 0 0 10px 0;
}
#accordion .panel h4 {
    background: #f4f4f4;
    padding: 10px 15px;
    position: relative;
/*    font-family: 'Gotham-Bold'; */
    color: #756f67;
    font-size: 110%;
    text-transform: uppercase;
    margin: 0;
/*    min-height: 90px; */
    cursor: pointer;
}
#accordion .panel h4 span {
    font-size: 80%;
    font-family: 'Gotham-Book';
    display: block;
    padding: 10px 0 0 0;
}
#accordion .panel .arrow {
    /*display: block;
    background: #00a88f url(/images/UserUploadedImages/480/arrow-down-white.png) no-repeat  25px -40px;
    width: 90px;
    height: 90px;*/
    position: absolute;
    top: 0;
    right: 0;
    width: 90px;
/*    min-height: 90px;*/
    height: 100%;
} 
#accordion .panel h4 span.arrow:after { 
    background: #f4f4f4 none repeat scroll 0 0;
    color: #b4b4b4;
    content: "\f077";
    font-family: "FontAwesome";
    font-size: 20px;
    font-weight: normal;
    height: 100%;
    padding-left: 50%;
    padding-top: 9%;
    position: absolute;
    top: 0;
    width: 100%;
}
#accordion .panel h4.collapsed span.arrow:after { 
    content: "\f078";
}
/*#accordion .panel h4.collapsed .arrow {
    background-position:  25px 30px;
}*/
#accordion .panel .panel-collapse {
    padding: 0;
}
#accordion .panel .panel-collapse .section {
    padding: 30px 10px 10px;
    margin: 0 0 2px 0;
    display: inline-block;
    width: 100%;
}
#accordion .panel .panel-collapse h3 {
    font-size: 115%;
    font-family: 'Gotham-Bold';
}
#accordion .panel .panel-collapse ul, #accordion .panel .panel-collapse ul li {
/*    list-style: none; 
    padding: 0;
    margin: 2px;*/
}
/*#accordion .panel .panel-collapse ul > li {
   color: #333;
    font-size: 13px;
}*/
#accordion .panel .panel-collapse ul > li > span {
    font-family: 'Gotham-Book';
    color: #756f67;
}

/*------------------*/
/* Other classes */
body{
    background: #eaeaea;
}
#aside ul li ul li a{
    width: 100%;
}
#aside #logo{
    display: inline-block;
}
.coda-slider{
    background: none;
    border:none;
}
.coda-slider-wrapper{
    padding: 0;
}
/*.coda-slider .panel-wrapper{
    padding: 0;
}*/
.fa{
    margin-right: 5px;
}
.btn{
    border-radius: 2px;
}
/*.coda-nav ul{
  display: inline;
}*/
#content ul{
    margin: 0;
}
.jxt-help-page{
    background: none;
    width: auto;
    line-height: normal;
    padding: 0;
    font-size: 16px;
}
/*--- end --- */
</style>
    <link rel="stylesheet" href="/admin/styles/coda-slider/coda-slider-2.0.css" type="text/css"
        media="screen" />
    <script type='text/javascript'>

        var FriendlyUrlValue = '';

        function checkFriendlyUrlChanged() {

            var currentValue = $('#ctl00_ContentPlaceHolder1_txtPageFriendlyName').val().toLowerCase();

            FriendlyUrlValue = currentValue;
            FriendlyUrlValue = $('#ctl00_ContentPlaceHolder1_txtPageName').val().toLowerCase();

            FriendlyUrlValue = FriendlyUrlValue.replace("+", "plus").replace("?", "").replace("&", "and").replace("'", "-").replace(/  +/g, "-").replace(/[\W]/gi, "-").replace(/[-]+/gi, "-");

            if (FriendlyUrlValue.substring(FriendlyUrlValue.length - 1, FriendlyUrlValue.length) == '-')
                FriendlyUrlValue = FriendlyUrlValue.substring(0, FriendlyUrlValue.length - 1);

            $("#ctl00_ContentPlaceHolder1_txtPageFriendlyName").val(FriendlyUrlValue);

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Dynamic Pages - Add/Edit <a href='http://support.jxt.com.au/solution/articles/116442-dynamic-pages'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>
        <li class="fa fa-comments-o"></li>
        Help</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all add-edit-page">
        <asp:HiddenField ID="hfCode" runat="server" />
        <div id="left-column">
            <asp:Literal ID="ltlMessageSave" runat="server" />
            <asp:Literal ID="ltlMessage" runat="server" />
            <script>

                $(".form-elements-group").find(".help-block-success, .help-block-error, .help-block").each(function () {
                    $(this).closest('.form-elements-group').css("margin-bottom", "0");
                });

            </script>
            <h2 class="section-header">
                Page settings</h2>
            <div class="form-all">
                <div class="form-elements-linebreak">
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <asp:Label ID="lbPageName" runat="server" AssociatedControlID="txtPageName"> Unique Page Code <span class="required">*</span></asp:Label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="txtPageName" runat="server" CssClass="form-element med" placeholder="Enter unique page code" />
                        <asp:RequiredFieldValidator ID="ReqVal_PageName" runat="server" Display="Dynamic"
                            ControlToValidate="txtPageName" ErrorMessage="Required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CusVal_PageName" runat="server" ControlToValidate="txtPageName"
                            Display="Dynamic" OnServerValidate="CusVal_PageName_ServerValidate"></asp:CustomValidator>
                    </div>
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <asp:Label ID="lbPageFriendlyName" runat="server" AssociatedControlID="txtPageFriendlyName"> Page Friendly URL <span class="required">*</span></asp:Label></div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="txtPageFriendlyName" runat="server" CssClass="form-element med"
                            placeholder="Enter a page friendly url" /><asp:RequiredFieldValidator ID="ReqVal_PageFriendlyName"
                                runat="server" Display="Dynamic" ControlToValidate="txtPageFriendlyName" ErrorMessage="Required"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                        &nbsp;<a href="javascript:void(0);" onclick="checkFriendlyUrlChanged()">Generate</a>
                    </div>
                </div>
                <div class="form-elements-group no-marg-btm">
                    <div class="label-holder">
                        <asp:Label ID="lbCustomURL" runat="server" AssociatedControlID="tbCustomUrl"> Custom URL (optional)</asp:Label></div>
                    <div class="form-element-holder InputAddOn">
                        <span class="InputAddOn-item">
                            <asp:Literal ID="ltSiteUrl" runat="server" /></span>
                        <asp:TextBox ID="tbCustomUrl" runat="server" CssClass="form-element med InputAddOn-field"
                            placeholder="Enter custom url" /><asp:CustomValidator ID="CusVal_tbCustomUrl" runat="server"
                                ControlToValidate="tbCustomUrl" Display="Dynamic" OnServerValidate="CusVal_tbCustomUrl_ServerValidate"></asp:CustomValidator></div>
                    <p class="help-block">
                        This URL will overwrite both page friendly URL and overwrite link. e.g. contact-us,
                        about/meet-the-team</p>
                </div>
                <div class="form-elements-group no-marg-btm">
                    <div class="label-holder">
                        <asp:Label ID="lbHyperlink" runat="server" AssociatedControlID="txtHyperlink"> Overwrite Link </asp:Label>
                    </div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="txtHyperlink" runat="server" CssClass="form-element med" placeholder="Enter you overwrite link" />
                        <asp:CustomValidator ID="CusVal_txtHyperLink" runat="server" ControlToValidate="txtHyperLink"
                            Display="Dynamic" OnServerValidate="CusVal_txtHyperLink_ServerValidate" />
                    </div>
                    <p class="help-block">
                        e.g. Sitemap.aspx, http://www.google.com</p>
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <asp:Label ID="lbSequence" runat="server" AssociatedControlID="txtSequence"> Sequence <span class="required">*</span></asp:Label>
                    </div>
                    <div class="form-element-holder">
                        <asp:TextBox ID="txtSequence" runat="server" CssClass="form-element small" /><asp:RequiredFieldValidator
                            ID="ReqVal_dataSequence" runat="server" Display="Dynamic" ControlToValidate="txtSequence"
                            ErrorMessage="Required" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:RangeValidator
                                ID="RangeVal_dataSequence" runat="server" Display="Dynamic" ControlToValidate="txtSequence"
                                ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                                Type="Integer" SetFocusOnError="true"></asp:RangeValidator>
                    </div>
                </div>
                <div class="form-elements-group">
                    <div class="label-holder">
                        <asp:Label ID="lbMenuDisplay" runat="server" AssociatedControlID="lbMainNavigation"> Menu Display</asp:Label></div>
                    <div class="form-element-holder">
                        <asp:Label ID="lbOpenNewWindow" runat="server" AssociatedControlID="cbOpenNewWindow">
                            <input id="cbOpenNewWindow" runat="server" type="checkbox" />Open In New Window</asp:Label>
                        <asp:Label ID="lbMainNavigation" runat="server" AssociatedControlID="cbOnTopNav">
                            <input id="cbOnTopNav" runat="server" type="checkbox" />Main Navigation</asp:Label>
                        <asp:Label ID="lbOnLeftNav" runat="server" AssociatedControlID="cbOnLeftNav">
                            <input id="cbOnLeftNav" runat="server" type="checkbox" />Dynamic Navigation</asp:Label>
                        <asp:Label ID="lbChkValid" runat="server" AssociatedControlID="chkValid">
                            <input id="chkValid" runat="server" type="checkbox" />Left Navigation</asp:Label>
                        <asp:Label ID="lbOnBottomNav" runat="server" AssociatedControlID="cbOnBottomNav">
                            <input id="cbOnBottomNav" runat="server" type="checkbox" />Footer Navigation</asp:Label>
                        <asp:Label ID="lbSiteMapYes" runat="server" AssociatedControlID="cbOnSiteMap">
                            <input id="cbOnSiteMap" runat="server" type="checkbox" />On Site Map</asp:Label>
                        <asp:Label ID="lbBreadcrumb" runat="server" AssociatedControlID="chkBreadcrumb">
                            <input id="chkBreadcrumb" runat="server" type="checkbox" />Generate Breadcrumb</asp:Label>
                    </div>
                </div>
            </div>
            <div id="accordion">
                <asp:PlaceHolder ID="phWidgets" runat="server">
                    <div class="panel panel-default">
                        <h4 role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne"
                            aria-expanded="false" aria-controls="collapseOne">
                            Widgets / sidebars <span class="arrow"></span>
                        </h4>
                        <div id="collapseOne" class="panel-collapse collapsed in" role="tabpanel">
                            <div class="section">
                                <!-- Widgets and Sidebars -->
                                <div class="form-elements-group">
                                    <div class="label-holder">
                                        <asp:Label ID="lbRelatedDynamicPages" runat="server" AssociatedControlID="ddlRelatedDynamicPages"> Related Dynamic Pages </asp:Label>
                                    </div>
                                    <div class="form-element-holder">
                                        <asp:HiddenField ID="ddlRelatedDynamicPages" runat="server" ClientIDMode="Static" />
                                    </div>
                                </div>
                                <div class="form-elements-group">
                                    <div class="label-holder">
                                        <asp:Label ID="lbLeftColumn" runat="server" AssociatedControlID="ddlLeftColumn"> Widget - left column</asp:Label></div>
                                    <div class="form-element-holder">
                                        <asp:HiddenField ID="ddlLeftColumn" runat="server" ClientIDMode="Static" />
                                    </div>
                                </div>
                                <div class="form-elements-group">
                                    <div class="label-holder">
                                        <asp:Label ID="lbRightColumn" runat="server" AssociatedControlID="ddlRightColumn"> Widget - right column</asp:Label></div>
                                    <div class="form-element-holder">
                                        <asp:HiddenField ID="ddlRightColumn" runat="server" ClientIDMode="Static" />
                                    </div>
                                </div>
                                <!-- End -->
                            </div>
                        </div>
                    </div>
                </asp:PlaceHolder>
                <div class="panel panel-default">
                    <h4 class="panel-title " data-toggle="collapse" data-parent="#accordion" href="#collapseTwo"
                        aria-expanded="false" aria-controls="collapseTwo">
                        Page contents <span class="arrow" id="spPageContentsArrow"></span>
                    </h4>
                    <asp:HiddenField ID="hfRelatedDynamicPages" runat="server" ClientIDMode="Static" />
                    <div id="collapseTwo" class="" role="tabpanel" aria-labelledby="headingTwo">
                        <div class="section">
                            <!-- Page Contents -->
                            <asp:Repeater ID="rptDynamicPages" runat="server" OnItemDataBound="rptDynamicPages_ItemDataBound">
                                <HeaderTemplate>
                                    <div class="coda-slider-wrapper">
                                        <div class="coda-slider preload" id="coda-slider-1">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="panel2">
                                        <div class="panel-wrapper">
                                            <h2 class="title">
                                                <asp:Literal ID="litLanguageName" runat="server" /></h2>
                                            <div class="form-all">
                                                <JXTControl:DynamicPageRevisionsField ID="ucDynamicPage" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div> </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <!-- End -->
                        </div>
                    </div>
                </div>
                <div class="panel panel-default" style="display: none">
                    <h4 class="panel-title collapsed" data-toggle="collapse" data-parent="#accordion"
                        href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                        SEO Settings <span class="arrow"></span>
                    </h4>
                    <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                        <div class="section">
                            <!-- SEO Settings -->
                            <div class="form-elements-group">
                                <div class="label-holder">
                                    <label for="">
                                        Meta Title</label></div>
                                <div class="form-element-holder">
                                    <input type="text" class="form-element" /></div>
                            </div>
                            <div class="form-elements-group">
                                <div class="label-holder">
                                    <label for="">
                                        Meta Keywords</label></div>
                                <div class="form-element-holder">
                                    <textarea name="" class="form-element" id="" cols="30" rows="10"></textarea></div>
                            </div>
                            <div class="form-elements-group">
                                <div class="label-holder">
                                    <label for="">
                                        Meta Description</label></div>
                                <div class="form-element-holder">
                                    <textarea name="" class="form-element" id="" cols="30" rows="10"></textarea></div>
                            </div>
                            <!-- End -->
                        </div>
                    </div>
                </div>
            </div>
            <%--            <div class="form-elements-group">
                <div class="form-element-holder button-panel">
                    <asp:LinkButton ID="lbCancel" runat="server" CssClass="btn" Text="Cancel" OnClick="lbCancel_Click" />
                </div>
            </div>
            --%>
        </div>
        <div id="right-column">
            <asp:Panel ID="pl_publish" runat="server">
                <div id="publish">
                    <h2>
                        Publish Settings</h2>
                    <div class="preview-btn-holder">
                        <asp:HyperLink ID="hlPreviewChanges" runat="server" CssClass="btn pull-left" Target="_blank"
                            Text="Preview Page" />
                    </div>
                    <div id="publish-details">
                        <asp:PlaceHolder ID="phStatus" runat="server">
                            <div class="publish-label">
                                <i class="fa fa-map-pin"></i>Status:</div>
                            <div class="publish-detail">
                                <asp:Literal ID="ltStatus" runat="server" />
                                <asp:DropDownList ID="ddlStatus" runat="server">
                                </asp:DropDownList>
                            </div>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phPublishSettings" runat="server">
                            <asp:PlaceHolder ID="phVisibility" runat="server">
                                <div class="publish-label">
                                    <i class="fa fa-eye"></i>Visibility:</div>
                                <div class="publish-detail">
                                    <asp:Literal ID="ltVisibility" runat="server" /><asp:DropDownList ID="ddlVisibility"
                                        runat="server">
                                        <asp:ListItem Text="Public" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Password Protected" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Private" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="phPublishedOn" runat="server" Visible="true">
                                <div class="publish-label">
                                    <i class="fa fa-calendar-o"></i>Publish on:</div>
                                <div class="publish-detail">
                                    <asp:Literal ID="ltPublishedOn" runat="server" />
                                    <asp:PlaceHolder ID="phPublishDate" runat="server">
                                        <div class='input-group date' id='datetimepicker1'>
                                            <asp:TextBox ID="txtPublishDate" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                        <%--
                                        <asp:DropDownList ID="ddlPublishedOnMonth" runat="server">
                                            <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                            <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                            <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="tbPublishedOnDay" runat="server" MaxLength="2" size="2" />
                                        <asp:TextBox ID="tbPublishedOnYear" runat="server" MaxLength="4" size="4" />
                                        @
                                        <asp:TextBox ID="tbPublishedOnHour" runat="server" MaxLength="2" size="2" />
                                        :
                                        <asp:TextBox ID="tbPublishedOnMinute" runat="server" MaxLength="2" size="2" />--%>
                                    </asp:PlaceHolder>
                                </div>
                                <div class="clearfix"></div>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="phComment" runat="server" Visible="true">
                                <div class="publish-label">
                                    <i class="fa fa-eye"></i>Comments:</div>
                                <div class="publish-detail">
                                    <asp:TextBox ID="tbComment" runat="server" TextMode="MultiLine" Rows="5" Columns="40" />
                                </div>
                            </asp:PlaceHolder>
                            <asp:PlaceHolder ID="phRevision" runat="server">
                                <div class="publish-label">
                                    <i class="fa fa-clock-o"></i>Revisions:</div>
                                <div class="publish-detail">
                                    <asp:Literal ID="ltRevisions" runat="server" />&nbsp; revisions
                                    <asp:LinkButton ID="lbBrowse" runat="server" Text="Browse" CssClass="edit-detail-link" />
                                </div>
                                <div class="detail-edit">
                                    <asp:Repeater ID="rptRevision" runat="server" OnItemDataBound="rptRevision_ItemDataBound"
                                        OnItemCommand="rptRevision_ItemCommand">
                                        <HeaderTemplate>
                                            <table id="tableRevision" width="100%" border="1" cellpadding="0" cellspacing="0">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            Revision Date &amp; Time
                                                        </th>
                                                        <th>
                                                            Author
                                                        </th>
                                                        <th>
                                                            Action
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr runat="server" id="rowItem">
                                                <td>
                                                    <asp:Literal ID="ltRevisionDate" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltRevisionBy" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="lbRevisionRevert" runat="server" Text="Browse" CommandName="Revert"
                                                        CausesValidation="false" />
                                                    |
                                                    <asp:HyperLink ID="hlRevisionView" runat="server" Text="View" Target="_blank" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody> </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <a href="#" id="cancel-published-date" class="cancel-button">Cancel</a>
                                </div>
                            </asp:PlaceHolder>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phVisibilityDisplay" runat="server" Visible="false">
                            <div class="publish-label">
                                <i class="fa fa-eye"></i>Visibility:</div>
                            <div class="publish-detail">
                                <asp:Literal ID="ltVisibilityDisplay" runat="server" />
                            </div>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phCommentDisplay" runat="server" Visible="false">
                            <div class="publish-label">
                                <i class="fa fa-eye"></i>Comments:</div>
                            <div class="publish-detail">
                                <asp:Literal ID="ltCommentDisplay" runat="server" />
                            </div>
                        </asp:PlaceHolder>
                        <div class="publish-label">
                            <i class="fa fa-calendar"></i>Last Modified:</div>
                        <div class="publish-detail">
                            <asp:Literal ID="ltLastModified" runat="server" />
                        </div>
                        <div class="publish-label">
                            <i class="fa fa-eye"></i>Last Modified By:</div>
                        <div class="publish-detail">
                            <asp:Literal ID="ltLastModifiedBy" runat="server" />
                        </div>
                        <asp:Panel ID="plDetectedChanges" runat="server" Visible="false">
                            <div class="publish-label">
                                <i class="fa fa-info"></i>Detected Changes:</div>
                            <div class="publish-detail">
                                <asp:Literal ID="ltDetectedChanges" runat="server" />
                            </div>
                        </asp:Panel>
                        <div class="clearfix">
                        </div>
                    </div>
                </div>
                <asp:Panel ID="plButtonsHolder" runat="server">
                    <div class="publish-btn-holder">
                        <asp:PlaceHolder ID="phDelete" runat="server" Visible="false">
                            <asp:LinkButton ID="lbDelete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this page?');"
                                CssClass="pull-left delete" OnClick="lbDelete_Click"> <i class="fa fa-trash"></i></asp:LinkButton>
                        </asp:PlaceHolder>
                        <asp:LinkButton ID="lbAdminUpdate" runat="server" CssClass="btn pull-right" Text="Update"
                            OnClick="lbAdminUpdate_Click" />
                        <asp:LinkButton ID="lbSaveDraft" runat="server" CssClass="btn pull-right" Text="Save Draft"
                            OnClick="lbSaveDraft_Click" Visible="false" />
                        <asp:HyperLink ID="hlRevert" runat="server" CssClass="btn pull-right" Text="Revert"
                            Visible="false" />
                        <asp:LinkButton ID="lbCancel" runat="server" CssClass="btn btn-danger" Text="Cancel"
                            OnClick="lbCancel_Click" />
                    </div>
                </asp:Panel>
            </asp:Panel>
        </div>
    </div>
    <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.9.0/moment-with-locales.js"></script>
    <script src="//cdn.rawgit.com/Eonasdan/bootstrap-datetimepicker/e8bddc60e73c1ec2475f827be36e1957af72e2ea/src/js/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#txtPublishDate').datetimepicker({
                showClear: true,
                format: '<%=DateFormat %> hh:mm:ss A'
            });
        });
    </script>
</asp:Content>
