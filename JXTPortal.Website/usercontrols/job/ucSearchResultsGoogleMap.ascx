<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSearchResultsGoogleMap.ascx.cs"
    Inherits="JXTPortal.Website.usercontrols.job.ucSearchResultsGoogleMap" %>
<div id="mapLoadingIconWrapper" class="text-center">
    <span id="mapLoadingIcon" class="fa fa-spinner fa-spin" style="font-size: 150%">
    </span>
</div>
<div id="mapDisplayWrapper" style="opacity: 0">
    <h3 id="mapResultsCount">
        Displaying <span id="searchResultsMapCount">0</span> results with addresses</h3>
    <div id="googlemap" style="height: 500px;">
    </div>
</div>
<%--<small>* Listing not showing on map? Find out why - <a href="#" target="_blank">click
    here</a></small>
--%>

<%
        if (string.IsNullOrEmpty(MapKey))
        {
%>
<script type="text/javascript" src="//maps.google.com/maps/api/js?sensor=false&v=3.exp&signed_in=true&libraries=places,geometry"></script>
<%
        }
        else
        {
%>
<script type="text/javascript" src="//maps.google.com/maps/api/js?key=<%=MapKey %>&sensor=false&v=3.exp&signed_in=true&libraries=places,geometry"></script>
<%
        }
%>

<script src="/scripts/googlemaps_markerclusterer.js" type="text/javascript"></script>
<script type="text/javascript">
    var map;
    var mapCircleRef;

    //marker clusterer
    var mc;
    var mcOptions = { gridSize: 20, maxZoom: 17 };

    //global infowindow
    var infowindow = new google.maps.InfoWindow();

    var addresses = [];
    var lastSearchedAddress = "";

    function MarkerClustererSet() {
        //marker cluster
        var gmarkers = [];
        mc = new MarkerClusterer(map, [], mcOptions);
        for (i = 0; i < addresses.length; i++) {
            gmarkers.push(createMarker(addresses[i]));
        }
    }

    function CreateMarkerInfoHtml(address) {
        var html = "<div style='overflow: auto;'>" +
                   "<div class='mapPopupContentContainer'></div>" +
                   "<h2 class='mapPopupJobTitle'> <a href='" + address.jobLink + "' target='_blank'>" + address.jobName + "</a> </h2>" +
                   ( address.hasAdvertiserLogo == true ? ("<img src='" + address.advertiserLogo + "' alt='advertiser logo' class='mapPopupAdvertiserLogo' />") : "") +
                   "<span class='mapPopupAdvertiser'>" + address.advertiserName + "</span>" +
                   "<span class='mapPopupProfessionRole'>" + address.position + "</span>" +
                   (address.salaryShow && address.salaryFrom != 0 && address.salaryTo != 0 ? ("<span class='mapPopupSalary'>" + address.currencySymbol + address.salaryFrom + " to " + address.currencySymbol + address.salaryTo + " " + address.salaryDisplayName + "</span>") : "") +
                   "</div>";
        return html;
    }

    function createMarker(address) {

        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(parseFloat(address.lat), parseFloat(address.lng)),
            map: map,
            icon: 'http://maps.google.com/mapfiles/ms/icons/red-dot.png'
        });

        var infoTextForAddress = "";

        //check for the same lat lng items
        for (var i = 0; i < addresses.length; i++) {

            var loopAddress = addresses[i];

            if (loopAddress.lat == address.lat && loopAddress.lng == address.lng) {
                infoTextForAddress += CreateMarkerInfoHtml(loopAddress);
            }
        }

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.close();
            infowindow.setContent("<div class='markerInfoWrapper'>" + infoTextForAddress + "</div>");
            infowindow.open(map, marker);
        });
        mc.addMarker(marker);
        return marker;
    }

    function RemoveOutOfRangeMarkers() {

        var centerpoint = map.getCenter();
        var radiusInMetres = $("#mapSearchRadius").val() * 1000;

        if (centerpoint != null && radiusInMetres > 0) {
            var newAddress = new Array();
            for (var i = 0; i < addresses.length; i++) {

                var thisAddress = addresses[i];

                var thisAddressPosition = new google.maps.LatLng(parseFloat(thisAddress.lat), parseFloat(thisAddress.lng));

                //in Metres
                var distFromCenterPoint = google.maps.geometry.spherical.computeDistanceBetween(thisAddressPosition, centerpoint);

                if (distFromCenterPoint < radiusInMetres) {
                    newAddress.push(thisAddress);
                }
            }
            addresses = newAddress;
        }
    }

    function RemoveAllMarkersAndShapes() {
        //clear markers
        mc.clearMarkers();

        //clear circle
        if (mapCircleRef != null)
            mapCircleRef.setMap(null);

        //clear addresses
        addresses = [];
    }

    function RadiusSearchClear() {
        $("#mapSearchAddress").val("").keyup();

        $("#mapSearchRadius option").attr("selected", false);
        $("#mapSearchRadius option:first").attr("selected", true);

        $("#mapRadiusSearchClearBtn").attr("disabled", "disabled");

        RemoveAllMarkersAndShapes();

        JobsInCanvasGet(null, null, null, null, false);

    }

    function MapSearch() {

        if (lastSearchedAddress != $("#mapSearchAddress").val() + "||" + $("#mapSearchRadius").val()) {

            lastSearchedAddress = $("#mapSearchAddress").val() + "||" + $("#mapSearchRadius").val();

            RemoveAllMarkersAndShapes();

            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({ "address": $("#mapSearchAddress").val() }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {

                    var centerPoint_lat = results[0].geometry.location.lat(),
                    centerPoint_lng = results[0].geometry.location.lng();

                    if ($("#mapSearchRadius").val() > 0) {
                        var fullBounds = new google.maps.LatLngBounds();
                        DrawRadiusCircle(parseFloat(centerPoint_lat), parseFloat(centerPoint_lng), $("#mapSearchRadius").val()); //google.maps.Circle type

                        //put the circle's bounds into fitBounds function to fit the circle into the map view
                        fullBounds.extend(mapCircleRef.getBounds().getNorthEast());
                        fullBounds.extend(mapCircleRef.getBounds().getSouthWest());
                        map.fitBounds(fullBounds);
                    }
                    map.setCenter(new google.maps.LatLng(parseFloat(centerPoint_lat), parseFloat(centerPoint_lng)));

                    //get map canvas corners to request for jobs
                    var bounds = map.getBounds();
                    var southWest = bounds.getSouthWest();
                    var northEast = bounds.getNorthEast();

                    JobsInCanvasGet(northEast.lat(), northEast.lng(), southWest.lat(), southWest.lng(), false);

                }
            });
        }

    }

    function JobsInCanvasGet(NELat, NELng, SWLat, SWLng, isInit) {
        $.ajax({
            type: "POST",
            cache: false,
            url: "/job/ajaxcalls/ajaxmethods.asmx/JobsForGoogleMapGet",
            data: "{ CampaignName: '', northEastLat: " + NELat + ", northEastLng: " + NELng + ", southWestLat: " + SWLat + ", southWestLng: " + SWLng + "}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {

                var isRadiusSearch = NELat != null && NELng != null && SWLat != null && SWLng != null;

                // Replace the div's content with the page method's return.
                for (var i = 0; i < msg.d.Data.length; i++)
                    addresses.push(msg.d.Data[i]);

                //update results count text
                $("#searchResultsMapCount").html(addresses.length);

                if (addresses.length > 0) {
                    //if all Lat/Lng is null, it means a search all and show all
                    if (!isRadiusSearch) {

                        var fullBounds = new google.maps.LatLngBounds();

                        for (var i = 0; i < addresses.length; i++) {
                            var latlng = new google.maps.LatLng(parseFloat(addresses[i].lat), parseFloat(addresses[i].lng));
                            fullBounds.extend(latlng);
                        }

                        //fit all markers onto map canvas
                        map.fitBounds(fullBounds);
                    }
                    else {
                        //else this is an "center pointed" search with a radius specified
                        RemoveOutOfRangeMarkers();
                    }

                    //Set markers with marker clusterer
                    MarkerClustererSet();

                    $(".map-address").show();
                }
                else {
                    if (!isRadiusSearch) {
                        map.setCenter(new google.maps.LatLng(0, 0));
                        map.setZoom(1);
                        $(".map-address").hide();
                    }
                }

                if (isInit == true) {

                    $("#mapLoadingIconWrapper").animate({ opacity: 0 }, 500, function () {

                        $("#mapLoadingIconWrapper").remove();

                        $("#mapDisplayWrapper").animate({ opacity: 1 }, 500, function () { });

                    });
                }
                else {
                    $("#mapDisplayWrapper").show();
                }

            },
            fail: function () {
                // Replace the div's content with the page method's return.
            }
        });
    }

    function DrawRadiusCircle(centerPointLat, centerPointLng, radiusInMeters) {

        var circleOptions = {
            strokeColor: '#ffffff',
            strokeOpacity: 0,
            strokeWeight: 2,
            fillColor: '#FF0000',
            fillOpacity: 0.35,
            map: map,
            center: new google.maps.LatLng(centerPointLat, centerPointLng),
            radius: radiusInMeters * 1000
        };

        // Add the circle for this city to the map.
        mapCircleRef = new google.maps.Circle(circleOptions);
    }


    function initializeGoogleMap() {

        var options = {
            zoom: 18,
            center: new google.maps.LatLng(-33.812643, 151.003969),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(document.getElementById('googlemap'), options);

        //init jobs data
        JobsInCanvasGet(null, null, null, null, true);

        // Create the autocomplete object, restricting the search to geographical location types.
        var placeSearch, autocomplete;
        autocomplete = new google.maps.places.Autocomplete(
        /** @type {HTMLInputElement} */(document.getElementById('mapSearchAddress')),
                { types: ['geocode'] });
        // When the user selects an address from the dropdown,
        // populate the address fields in the form.
        google.maps.event.addListener(autocomplete, 'place_changed', function () {
            var place = autocomplete.getPlace();

            for (var component in componentForm) {
                document.getElementById(component).value = '';
                document.getElementById(component).disabled = false;
            }

            // Get each component of the address from the place details
            // and fill the corresponding field on the form.
            var componentForm = {
                street_number: 'short_name',
                route: 'long_name',
                locality: 'long_name',
                administrative_area_level_1: 'short_name',
                country: 'long_name',
                postal_code: 'short_name'
            };

            for (var i = 0; i < place.address_components.length; i++) {
                var thisAddressObj = place.address_components[i];

                //available keys for thisAddressObj is "long_name", "short_name", "types"
                //thisAddressObj.long_name
            }
        });

        $("#mapSearchAddress").on("keydown", function (e) {
            if (e.keyCode == 13) {
                selectFirstResult();
                $("#mapSearchAddress").focusout().blur();
            }
        });
    }

    function selectFirstResult() {
        infowindow.close();
        var firstResult = $(".pac-container .pac-item:first").text();

        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ "address": firstResult }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {

                var lat = results[0].geometry.location.lat(),
                lng = results[0].geometry.location.lng(),
                placeName = results[0].address_components[0].long_name,
                latlng = new google.maps.LatLng(lat, lng);

                $("#mapSearchAddress").val(results[0].formatted_address);
            }
        });
    }
</script>
