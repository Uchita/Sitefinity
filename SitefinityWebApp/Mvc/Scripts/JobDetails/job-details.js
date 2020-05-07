(function ($) {
    $(function () {
        document.getElementsByTagName('title')[0].innerHTML = objJobDetail.title + ' | ' + objJobDetail.companyName;
        var isLoggedIn = objJobDetail.loginInStatus;
        var jobId = objJobDetail.id;
        $('.sf-lang-selector').addClass('hidden');

        //ajax call for apply job button
        $.ajax({
            type: 'POST',
            cache: false,
            url: $(location).attr('pathname') + "/IsJobApplied",
            data: { JobId: jobId },
            dataType: 'Json',
            success: function (response) {
                if (response.IsJobExpired === true) {
                    $('.o-jobdetail').addClass('disabled-block');
                    $('.job-expired-btn').html('<div id="job-applied-msg" class="alert alert-danger" >' + objJobDetail.expiredMsg + '</div>');
                }
                if (response.IsJobApplied === true) {
                    $('.job-apply-btn').html('<div id="job-applied-msg" class="alert alert-info" >' + objJobDetail.alreadyAppliedMsg + '</div>');
                }
                else {
                    if (response.IsJobExpired === false) {
                        $('.job-apply-btn').html('<a id="job-application-lnk" class="btn btn-primary btn-block" href="' + objJobDetail.applyBtnUrl + '">' + objJobDetail.applyBtnLabel + '</a>');
                    }
                }
                if ($(".meta-section") && $(".meta-section").height() > 0 && $(".job-application-wrapper") && $(".job-application-wrapper").height() > 0) {

                    var metaHeight = $(".meta-section").height();
                    var applicationButtonsHeight = $(".job-application-wrapper").height();
                    var tallest;
                    if (metaHeight > applicationButtonsHeight) {
                        $(".job-application-wrapper").height(metaHeight);
                        tallest = metaHeight;
                    }
                    else {
                        $(".meta-section").height(applicationButtonsHeight);
                        tallest = applicationButtonsHeight;
                    }
                    if ($(".top-bg-tall")) {
                        $(".top-bg-tall").css('position', 'relative');
                        $(".top-bg-tall").prepend('<div class="bg-color-tall"></div>');
                        $(".bg-color-tall").css('position', 'absolute');
                        $(".bg-color-tall").css('top', '0');
                        $(".bg-color-tall").css('height', tallest);
                        $(".bg-color-tall").css('width', '100%');
                        $(".bg-color-tall").css('background', '#EAEAEA');
                    }
                }

            },
            error: function (response) {
            }
        });

        //checking user logged in is member role
        $('#job-application-lnk').click(function (e) {
            if (isLoggedIn.toLocaleLowerCase() === "true") {
                var isMember = objJobDetail.isMemberUser;

                if (isMember.toLocaleLowerCase() !== "true") {
                    e.preventDefault();
                    alert('Please login as Member to apply for this job.');
                }
            }
        });


        $("#back-to-results").attr("href", '/jobs');

        //removing the timestamp from reference number value
        //initial value: 2X/06146_153447008279184
        //final value: 2X/06146
        if ($("#job-refno").length && $("#job-refno").text() !== "") {
            var jobRef = $("#job-refno");
            if (jobRef.text().indexOf("_") > 0) {
                var temp = jobRef.text().split("_");
                jobRef.text(temp[0]);
            }
        }


        //save job functionality
        function processSavedJobs() {
            var parm = {};
            var urlPath = $(location).attr('pathname') + "/GetAllSavedJobs";
            var self = $(this);
            $.ajax({
                type: 'POST',
                cache: false,
                url: urlPath,
                data: parm,
                dataType: 'Json',
                success: function (response) {

                    if (response.Success === true) { // Getting the all saved jobs
                        $('.save-job').each(function () {
                            var jobid = $(this).data('jobid');
                            var selfJob = $(this);

                            $.each(response.SavedJobs, function (index, saveJobInfo) {

                                if (saveJobInfo.JobId === jobid) {

                                    $(selfJob).addClass("saved");
                                    $(selfJob).find('.save-status-txt').text("Job saved");
                                    $(selfJob).attr('data-savedjobid', saveJobInfo.SavedJobId);
                                }
                            });
                        });
                    }
                    else { // Job failed to save

                    }
                },
                error: function (response) { // Error
                }
            });
        }

        //checking all the jobs on page load changing the save job status
        $.ajax({
            type: 'POST',
            cache: false,
            url: $(location).attr('pathname') + '/IsJobSaved',
            data: { JobId: jobId },
            dataType: 'Json',
            success: function (response) {
                if (response.IsUserLogged === true) {
                    $('.save-job-wrapper').html('<a href="#" class="save-job btn btn-primary btn-bdr" data-jobid="' + objJobDetail.id + '"><span class="save-status-txt">' + objJobDetail.saveJob + '</span></a>');
                    if (response.IsJobSaved === true) {
                        var selfJob = $('.save-job');
                        $(selfJob).addClass("saved");
                        $(selfJob).find('.save-status-txt').text(objJobDetail.saveJob);
                        $(selfJob).attr('data-savedjobid', response.SavedJobId);
                    }
                }
            },
            error: function (response) {

            }
        });

        //save job button click event
        $(document).off('click').on('click', '.save-job', function (e) {
            e.preventDefault();
            var unSaveJob = false;
            var ajaxActionName = "/SaveJob";
            var jobid = $(this).data('jobid');
            if ($(this).hasClass('saved')) {
                unSaveJob = true;
                ajaxActionName = "/RemoveSavedJob";
                jobid = $(this).attr('data-savedjobid');
            }

            var parm = { JobId: jobid };
            var urlPath = $(location).attr('pathname') + ajaxActionName;
            var self = $(this);
            $.ajax({
                type: 'POST',
                cache: false,
                url: urlPath,
                data: parm,
                dataType: 'Json',
                success: function (response) {

                    if (response.Success === true) { // Job Saved or unsaved
                        if (unSaveJob) { // Unsave job
                            self.removeClass("saved");
                            self.find('.save-status-txt').text(objJobDetail.saveJob);
                        }
                        else { // Save job
                            self.addClass("saved");
                            self.find('.save-status-txt').text(objJobDetail.jobSaved);
                            self.attr('data-savedjobid', response.SavedJobId);
                        }
                    }
                    else { // Job failed to save or unsave
                        if ((response.Errors[0].indexOf("(401)") > -1) || (response.Errors[0].indexOf("(403)") > -1))
                            alert("Please login as a member to save a job.");
                        else
                            alert(response.Errors[0]);
                    }
                },
                error: function (response) { // Error
                }
            });
        });



    });


}(jQuery));