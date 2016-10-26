<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobApply.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucJobApply" %>
<%@ Register TagPrefix="uc1" TagName="ucApplyWithLinkedIn" Src="~/usercontrols/job/ucApplyWithLinkedIn.ascx" %>
<div class="job-detail-centre">
    <div class="jobdetail-padding">
        <asp:Label ID="lbApplied" runat="server" Visible="false" ForeColor="Red" />
        <asp:Label ID="lblJobSaved" runat="server" Visible="false" ForeColor="Red" />
        <div id="divApplyNow" runat="server" class="apply-now-image">
            <div class="apply-now-link">
                <asp:HyperLink ID="lbApplyNow" runat="server" />
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hiddenMobiProductID" />
        <asp:HiddenField runat="server" ID="hiddenMobiJobName" />
        <asp:HiddenField runat="server" ID="hiddenMobiJobURL" />
        <div class="jobdetail-options">
            <asp:PlaceHolder ID="phJobMapLocation" runat="server" Visible="false">
                <div id="jobdetail-job-location-map">
                    <h2>
                        <JXTControl:ucLanguageLiteral ID="ltJobFieldJobLocation" runat="server" SetLanguageCode="LabelJobLocation" />
                    </h2>
                    <div id="map" style="height: 180px;">
                    </div>
                </div>
            </asp:PlaceHolder>
            <div id="jobdetail-interested-in-job">
                <h2>
                    <JXTControl:ucLanguageLiteral ID="ltucJobInterest" runat="server" SetLanguageCode="LabelInterestedInThisJob" />
                </h2>
                <ul>
                    <li class="save-image">
                        <asp:LinkButton ID="lnkSavedJobs" runat="server" OnClick="lnkSavedJobs_Click" />
                    </li>
                    <li class="print-image">
                        <asp:HyperLink ID="hypPrintJob" runat="server" />
                    </li>
                    <li class="email-image">
                        <asp:HyperLink ID="hypEmailJob" runat="server" />
                    </li>
                </ul>
            </div>
            <div id="jobdetail-social-media">
                <h2>
                    <JXTControl:ucLanguageLiteral ID="ltucJobSocialMedia" runat="server" SetLanguageCode="LabelSocialMedia" />
                </h2>
                <ul>
                    <li class="facebook-image">
                        <asp:HyperLink ID="hypFacebookJob" runat="server" NavigateUrl="http://www.facebook.com/share.php?u=window.location"
                            onclick="javascript:u=location.href;t=document.title;window.open('http://www.facebook.com/sharer.php?u='+encodeURIComponent(u)+'&amp;t='+ encodeURIComponent(t),'sharer','toolbar=0,status=0,width=626,height=436');return false;" />
                    </li>
                    <li class="twitter-image">
                        <asp:HyperLink ID="hypTwitterJob" runat="server" />
                    </li>
                    <li class="linked-in-image">
                        <asp:HyperLink ID="hypLinkedInJob" runat="server" NavigateUrl="javascript:function%20liSub(_LIN_sU){_LIN_t=document.title;_LIN_sT=%27%27;try{_LIN_sT=((window.getSelection%20&amp;&amp;%20window.getSelection())%20||%20(document.getSelection%20&amp;&amp;%20document.getSelection())%20||%20(document.selection%20&amp;&amp;%20document.selection.createRange%20&amp;&amp;%20document.selection.createRange().text));}catch(e){_LIN_sT=%27%27;};_LIN_sU+=%27&amp;summary=%27+encodeURIComponent(_LIN_sT)+%27&amp;title=%27+encodeURIComponent(_LIN_t)+%27&amp;url=%27+encodeURIComponent(location.href);_LIN_w=window.open(_LIN_sU,%27News%27,%27width=650,height=700,toolbar=0,location=0,status=0,scrollbars=yes%27);};void(liSub(%27http://www.linkedin.com/shareArticle?mini=true%27));" />
                    </li>
                    <li class="googleplus-in-image">
                        <asp:HyperLink ID="hypGooglePlusJob" runat="server" NavigateUrl="https://plus.google.com/share?url=window.location"
                            onclick="javascript:u=location.href;window.open('https://plus.google.com/share?url='+encodeURIComponent(u),'sharer','toolbar=0,status=0,width=626,height=436');return false;" />
                    </li>
                </ul>
            </div>
        </div>
        <!-- Where LinkedIn goes -->
        <asp:ImageButton ID="ibApplyWithLinkedIn" runat="server" ImageUrl="/Images/buttons/applywithlinkedin.svg"
            OnClick="ibApplyWithLinkedIn_Click" AlternateText="Apply with Linkedin" Width="190px" />
        <asp:PlaceHolder ID="phApplyWithIndeed" runat="server" Visible="false">
            <div style="width: 230px">
                <div>
                    <span class="indeed-apply-widget" data-indeed-apply-apitoken="<%=IndeedAPIToken %>"
                        data-indeed-apply-jobid="<%=JobID %>" data-indeed-apply-joblocation="<%=JobLocation %>"
                        data-indeed-apply-jobcompanyname="<%=CompanyName %>" data-indeed-apply-jobtitle="<%=JobTitle %>"
                        data-indeed-apply-joburl="<%=JobURL %>" data-indeed-apply-posturl="<%=PostURL %>"
                        data-indeed-apply-onapplied="OnIndeedCompleted"></span>
                    <script>                        (function (d, s, id) {
                            var js, iajs = d.getElementsByTagName(s)[0];
                            if (d.getElementById(id)) { return; }
                            js = d.createElement(s); js.id = id; js.async = true;
                            js.src = "https://apply.indeed.com/indeedapply/static/scripts/app/bootstrap.js";
                            iajs.parentNode.insertBefore(js, iajs);
                        } (document, 'script', 'indeed-apply-js'));
                    </script>
                </div>
            </div>
        </asp:PlaceHolder>

        
        
        <asp:PlaceHolder ID="phSimilarJobs" runat="server" Visible="false">
        
        <!-- html that goes at the end of .jobdetail-padding, after where the apply with linkedin button would be. -->
        <div class="jxt-similar-jobs-container">
	        <h2><JXTControl:ucLanguageLiteral ID="ltSimilarJobsTitle" runat="server" SetLanguageCode="LabelSimilarJobs" /></h2>
	        <div class="jxt-similar-jobs-holder">
                <asp:Literal ID="ltlSimilarJobs" runat="server"></asp:Literal>
		        <%--<ul>
			        <li>
				        <a href="" class="jxt-similar-job">
					        <span class="jxt-similar-job-title">Project Manager</span>
					        <span class="jxt-similar-job-location"><i class="fa fa-map-marker"></i> Sydney</span>
					        <span class="jxt-similar-job-worktype"><i class="fa fa-briefcase"></i> Full Time</span>
				        </a>
			        </li>
			        <li>
				        <a href="" class="jxt-similar-job">
					        <span class="jxt-similar-job-title">
						        Project Manager
					        </span>
					        <span class="jxt-similar-job-location">
						        <i class="fa fa-map-marker"></i> Sydney
					        </span>
					        <span class="jxt-similar-job-worktype">
						        <i class="fa fa-briefcase"></i> Full Time
					        </span>
				        </a>
			        </li>
			        <li>
				        <a href="" class="jxt-similar-job">
					        <span class="jxt-similar-job-title">
						        Project Manager
					        </span>
					        <span class="jxt-similar-job-location">
						        <i class="fa fa-map-marker"></i> Sydney
					        </span>
					        <span class="jxt-similar-job-worktype">
						        <i class="fa fa-briefcase"></i> Full Time
					        </span>
				        </a>
			        </li>
			        <li>
				        <a href="" class="jxt-similar-job">
					        <span class="jxt-similar-job-title">
						        Project Manager
					        </span>
					        <span class="jxt-similar-job-location">
						        <i class="fa fa-map-marker"></i> Sydney
					        </span>
					        <span class="jxt-similar-job-worktype">
						        <i class="fa fa-briefcase"></i> Full Time
					        </span>
				        </a>
			        </li>
			        <li>
				        <a href="" class="jxt-similar-job">
					        <span class="jxt-similar-job-title">
						        Project Manager sdfasdf asdf asdf asdf asdfasdf asdf s
					        </span>
					        <span class="jxt-similar-job-location">
						        <i class="fa fa-map-marker"></i> Sydney
					        </span>
					        <span class="jxt-similar-job-worktype">
						        <i class="fa fa-briefcase"></i> Full Time
					        </span>
				        </a>
			        </li>
		        </ul>--%>
	        </div>
        </div>

        
        <!-- This widget needs jcarousellite. may be a good idea to store this on Boardy so nobody deletes it. -->
        <script src="//images.jxt.net.au/COMMON/js/jquery.jcarousellite.min.js"></script>
        
        <!-- script for similar jobs widget -->
        <script>

            // In the head, before any JS loads, we should load a global object with settings for this widget. These settings can then be edited in myjs before implemented below.
            var jxt = {
                settings: {
                    similarJobs: {
                        visible: 3,
                        auto: 3000,
                        speed: 1000,
                        vertical: true
                    }
                }
            }
            // This would be good to have for all widgets on the platform, containing different information for different widgets.

            !(function () {
                $(function () {
                    // This is why we need the addition of the global object
                    // with default values at the top of this file.
                    // these options NEED to be editable. Clients WILL want to change these individually.

                    // only run jcarousellite if there are more jobs than visible.
                    if ($(".jxt-similar-job").length > jxt.settings.similarJobs.visible) {
                        $(".jxt-similar-jobs-holder").jCarouselLite({
                            visible: jxt.settings.similarJobs.visible,
                            auto: jxt.settings.similarJobs.auto,
                            speed: jxt.settings.similarJobs.speed,
                            vertical: jxt.settings.similarJobs.vertical
                            // this won't work with horizontal scrolling, too complicated with all the variables. But I'm keeping the option in the global object anyway.
                        });
                    }
                });
            })();
        </script>
        </asp:PlaceHolder>



    </div>
</div>
<div class="jd-btm-description">
    <div class="jobdetail-padding">
        <div id="divApplyNowBottom" runat="server">
            <div class="apply-now-image2">
                <div class="apply-now-link">
                    <asp:HyperLink ID="lbApplyNowBottom" runat="server" />
                </div>
            </div>
        </div>
    </div>
</div>
<%
    if ((MapLat != null && MapLng != null) || JobAddress != "")
    {
        if (string.IsNullOrEmpty(MapKey))
        {
%>
<script type="text/javascript" src="//maps.google.com/maps/api/js?sensor=false&v=3.exp&signed_in=true&libraries=places"></script>
<%
        }
        else
        {
%>
<script type="text/javascript" src="//maps.google.com/maps/api/js?key=<%=MapKey %>&sensor=false&v=3.exp&signed_in=true&libraries=places"></script>
<%
        }
%>
<script type="text/javascript">
            var map;

<%
    if (MapLat != null && MapLng != null)
    {    
%>
            function initializeGoogleMap() {

                var targetPin = new google.maps.LatLng(<%=MapLat %>, <%=MapLng %>);

                var options = {
                    zoom: 15,
                    center: targetPin,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
                map = new google.maps.Map(document.getElementById('map'), options);

                var marker = new google.maps.Marker({
                    position: targetPin,
                    map: map
                });

                var infowindow = new google.maps.InfoWindow({
                      content: CreateMarkerInfoHtml()
                  });
        
                google.maps.event.addListener(marker, 'click', function() {
                    infowindow.open(map,marker);
                  });
            }
<%
    }
%>
            function initAddressMap(address)
            {
                var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 15,
                center: {lat: -34.397, lng: 150.644},
                mapTypeId: google.maps.MapTypeId.ROADMAP
                });
              var geocoder = new google.maps.Geocoder();
              geocoder.geocode({'address': address}, function(results, status) {
                if (status === google.maps.GeocoderStatus.OK) {
                  map.setCenter(results[0].geometry.location);
                  var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                  });

                  var infowindow = new google.maps.InfoWindow({
                      content: CreateMarkerInfoHtml()
                  });
        
                google.maps.event.addListener(marker, 'click', function() {
                    infowindow.open(map,marker);
                  });

                } else {
                  $("#map").hide();
                }
              });
            }

            function CreateMarkerInfoHtml() {
                var html = "<div>" + "<%=JobAddress %>" + "</div>";
                return html;
            }

            $(document).ready(function () {
                var lat = '<%=MapLat %>';
                var lng = '<%=MapLng %>';
                var jobaddress = '<%=JobAddress %>';

                if ($("#map").length > 0)
                {
                   if (lat != '' && lng != '')
                   {
                      initializeGoogleMap();
                   }
                   else
                   {
                      if (jobaddress != '')
                      {
                        initAddressMap(jobaddress);
                      }
                   }
                }
            });

</script>
<%
    }
%>