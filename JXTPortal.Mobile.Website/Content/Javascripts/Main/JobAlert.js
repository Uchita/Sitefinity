    var isRoleLoaded = 0;
    var isAreaLoaded = 0;

    function PopulateInitRole()
    {
        if (isRoleLoaded == 0)
        {
            @if (Model.SearchRoleIds != null && Model.SearchRoleIds.Trim().Length > 0)
            {
                if (Model.SearchRoleIds.Contains(","))
                {
                    foreach (var role in Model.SearchRoleIds.Split(','))
                    {
                        @: $('#SearchRoleIds').val('@role');
                    }
                }
                else
                {
                    @: $('#SearchRoleIds').val('@Model.SearchRoleIds');
                }
            }

            isRoleLoaded = 1;
        }
    }

    function PopulateInitArea()
    {
        if (isAreaLoaded == 0)
        {
            @if (Model.AreaIds != null && Model.AreaIds.Trim().Length > 0)
            {
                if (Model.AreaIds.Contains(","))
                {
                    foreach (var area in Model.AreaIds.Split(','))
                    {
                        @: $('#AreaIds').val('@area');
                    }
                }
                else
                {
                    @: $('#AreaIds').val('@Model.AreaIds');
                }
            }

            isAreaLoaded = 1;
        }
    }

    $(function () {
        // Location
        
        $('#LocationId').change(function () {
            var selectedlocation = $(this).val();
            $.getJSON('@Url.Action("Areas","Job")', { locationId: selectedlocation }, function (Areas) {
                var areasSelect = $('#AreaIds');
                areasSelect.empty();

                if (selectedlocation == 0)
                {
                    areasSelect.append(
                            $('<option/>')
                                .attr('value', 0)
                                .text("All Areas")
                                .attr("selected", "selected")
                        );
                }

                jQuery.each(Areas, function (index, Area) {
                    areasSelect.append(
                        $('<option/>')
                            .attr('value', Area.Id)
                            .text(Area.Name)
                    );
                });

                PopulateInitArea();
            });
        });

        $('#ProfessionId').change(function () {
            var selectedProfession = $(this).val();
            $.getJSON('@Url.Action("Roles", "Job")', { professionId: selectedProfession }, function (Roles) {
                var rolesSelect = $('#SearchRoleIds');
                rolesSelect.empty();

                rolesSelect.append(
                        $('<option/>')
                            .attr('value', 0)
                            .text("All Roles")
                            .attr("selected", "selected")
                    );
                
                jQuery.each(Roles, function (index, Role) {
                    rolesSelect.append(
                        $('<option/>')
                            .attr('value', Role.Id)
                            .text(Role.Name)
                    );
                });

                PopulateInitRole();
            });
        });

        if (@Model.LocationId > 0)
        {
             $('#LocationId').val('@Model.LocationId').change();
        }
      
        if (@Model.ProfessionId > 0)
        {
              $('#ProfessionId').val('@Model.ProfessionId').change();
        }
     
    });
