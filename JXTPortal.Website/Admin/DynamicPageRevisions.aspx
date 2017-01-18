<%@ Page Title="Dynamic Page Edit" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="True" CodeBehind="DynamicPageRevisions.aspx.cs" Inherits="JXTPortal.Website.Admin.DynamicPageRevisions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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
    <link rel="stylesheet" href="/admin/styles/dynamicPageRevisions/styles.css" type="text/css" />
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
