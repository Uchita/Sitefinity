<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCVProfileDownload1.ascx.cs" Inherits="JXTPortal.Website.usercontrols.member.ucCVProfileDownload1" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
<title>Test PDF</title>

<style>
/* Minified Grid System  */
html{font-family:sans-serif;-ms-text-size-adjust:100%;-webkit-text-size-adjust:100%}body{margin:0}b,strong{font-weight:700}h1{font-size:2em;margin:.67em 0}.h1,h1{font-size:36px}.h2,h2{font-size:30px}.h3,h3{font-size:24px}.h4,h4{font-size:18px}.h5,h5{font-size:14px}.h6,h6{font-size:12px}p{margin:0 0 10px}.small,small{font-size:85%}ol,ul{margin-top:0;margin-bottom:10px}ol ol,ol ul,ul ol,ul ul{margin-bottom:0}img{border:0}hr{-moz-box-sizing:content-box;box-sizing:content-box;height:0}table{border-collapse:collapse;border-spacing:0}td,th{padding:0}*,:after,:before{-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box}html{font-size:10px;-webkit-tap-highlight-color:transparent}body{font-family:"Helvetica Neue",Helvetica,Arial,sans-serif;font-size:14px;line-height:1.42857143;color:#000;background-color:#fff}img{vertical-align:middle}.img-responsive{display:block;max-width:100%;height:auto}.img-rounded{border-radius:6px}.img-thumbnail{padding:4px;line-height:1.42857143;background-color:#fff;border:1px solid #ddd;border-radius:4px;-webkit-transition:all .2s ease-in-out;-o-transition:all .2s ease-in-out;transition:all .2s ease-in-out;display:inline-block;max-width:100%;height:auto}hr{margin-top:20px;margin-bottom:20px;border:0;border-top:1px solid #eee}.container{margin-right:auto;margin-left:auto;padding-left:15px;padding-right:15px}@media (min-width:768px){.container{width:750px}}@media (min-width:992px){.container{width:970px}}@media (min-width:1200px){.container{width:1170px}}.row{margin-left:-15px;margin-right:-15px}.col-md-1,.col-md-10,.col-md-11,.col-md-12,.col-md-2,.col-md-3,.col-md-4,.col-md-5,.col-md-6,.col-md-7,.col-md-8,.col-md-9{position:relative;min-height:1px;padding-left:15px;padding-right:15px}@media (min-width:992px){.col-md-1,.col-md-10,.col-md-11,.col-md-12,.col-md-2,.col-md-3,.col-md-4,.col-md-5,.col-md-6,.col-md-7,.col-md-8,.col-md-9{float:left}.col-md-12{width:100%}.col-md-11{width:91.66666667%}.col-md-10{width:83.33333333%}.col-md-9{width:75%}.col-md-8{width:66.66666667%}.col-md-7{width:58.33333333%}.col-md-6{width:50%}.col-md-5{width:41.66666667%}.col-md-4{width:33.33333333%}.col-md-3{width:25%}.col-md-2{width:16.66666667%}.col-md-1{width:8.33333333%}.col-md-pull-12{right:100%}.col-md-pull-11{right:91.66666667%}.col-md-pull-10{right:83.33333333%}.col-md-pull-9{right:75%}.col-md-pull-8{right:66.66666667%}.col-md-pull-7{right:58.33333333%}.col-md-pull-6{right:50%}.col-md-pull-5{right:41.66666667%}.col-md-pull-4{right:33.33333333%}.col-md-pull-3{right:25%}.col-md-pull-2{right:16.66666667%}.col-md-pull-1{right:8.33333333%}.col-md-pull-0{right:auto}.col-md-push-12{left:100%}.col-md-push-11{left:91.66666667%}.col-md-push-10{left:83.33333333%}.col-md-push-9{left:75%}.col-md-push-8{left:66.66666667%}.col-md-push-7{left:58.33333333%}.col-md-push-6{left:50%}.col-md-push-5{left:41.66666667%}.col-md-push-4{left:33.33333333%}.col-md-push-3{left:25%}.col-md-push-2{left:16.66666667%}.col-md-push-1{left:8.33333333%}.col-md-push-0{left:auto}.col-md-offset-12{margin-left:100%}.col-md-offset-11{margin-left:91.66666667%}.col-md-offset-10{margin-left:83.33333333%}.col-md-offset-9{margin-left:75%}.col-md-offset-8{margin-left:66.66666667%}.col-md-offset-7{margin-left:58.33333333%}.col-md-offset-6{margin-left:50%}.col-md-offset-5{margin-left:41.66666667%}.col-md-offset-4{margin-left:33.33333333%}.col-md-offset-3{margin-left:25%}.col-md-offset-2{margin-left:16.66666667%}.col-md-offset-1{margin-left:8.33333333%}.col-md-offset-0{margin-left:0}}.clearfix:after,.clearfix:before,.container:after,.container:before,.row:after,.row:before{content:" ";display:table}.clearfix:after,.container:after,.row:after{clear:both}

/* PDF Style  */
#header, #footer {background:#efefef;}
#header {min-height:80px; padding-top: 10px;padding-bottom: 10px;}
#content {margin-top:1em; margin-bottom:2em;}
ul, ol {padding-left:19px;}
h1, .h1, h2, .h2, h3, .h3, h4, .h4 {margin-top:5px; margin-bottom:10px;}
.profile-pic {position: relative;margin-top: -5em;margin-bottom: 2em;}
.site-logo {text-align:right; background-color:#fff;}
hr {border-top-width:5px;}
.qualification, .experience, .directorship {padding:1em 0;}
.candidate-info {border-right: 3px solid #DBDBDB;margin-top: 13px;text-align: right;padding-right: 10px;}
</style>

</head>

<body>


<div id="pdf-wrapper">
	<div id="header">
		<div class="container">
			<div class="row">
				<div class="col-md-2 col-md-offset-10"><div class="site-logo">
                <asp:Image ID="imgHeaderLogo" runat="server" CssClass="img-responsive" /></div></div>
			</div>
		</div>
	</div>
    <div id="content" class="container">
        <div class="row">
			<div class="col-md-3">
				<div class="profile-pic">
                    <asp:Image ImageUrl="//images.jxt.net.au/placeholder.png" runat="server" CssClass="thumbnail img-responsive" ID="imgMemberProfile" />
                </div>
			</div>
			<div class="col-md-5">
				<h2 id="candidate-name"><asp:Literal ID="ltlName" runat="server"></asp:Literal></h2>
				<p id="headline"><asp:Literal ID="ltlHeadline" runat="server"></asp:Literal></p>
                <asp:Literal ID="ltlCurrentStatus" runat="server"></asp:Literal>				
			</div>
			<div class="col-md-4">
                <asp:Literal ID="ltlMemberContacts" runat="server"></asp:Literal>				
			</div>			
		</div>
		<div class="row">
		    <div class="col-md-12">
                <p id="summary"> 
                <asp:Literal ID="ltlShortBio" runat="server"></asp:Literal>
                </p>
            </div>
		</div>
		<hr/>
    
        <div class="row">
			<div class="col-md-12">
				<h3 class="role-preferences-title"><asp:Literal ID="ltlRolePreferences" runat="server" /></h3>
				<div class="row role-location">
					<div class="col-md-6">
						<p class="location-title"><strong><JXTControl:ucLanguageLiteral ID="ucLabelLocation" runat="server" SetLanguageCode="LabelLocation" /></strong></p>
						<asp:Literal ID="ltlLocations" runat="server"></asp:Literal>
					</div>
					<div class="col-md-6">
						<p class="classification-title"><strong><JXTControl:ucLanguageLiteral ID="ucLabelClassification" runat="server" SetLanguageCode="LabelClassification" /> / 
                                                    <JXTControl:ucLanguageLiteral ID="ucLabelSubClassification" runat="server" SetLanguageCode="LabelSubClassification" /></strong></p>
						<asp:Literal ID="ltlClassifications" runat="server"></asp:Literal>
					</div>
				</div>
				<div class="row role-work-type">
					<div class="col-md-6">
						<p class="work-type-title"><strong><JXTControl:ucLanguageLiteral ID="ucLabelWorkType" runat="server" SetLanguageCode="LabelWorkType" /></strong></p>
						<asp:Literal ID="ltlWorktypes" runat="server"></asp:Literal>
					</div>
					<div class="col-md-6">&nbsp;</div>
				</div>
			</div>
		</div>    
    
		<hr/>

        <div class="row">
			<div class="col-md-12">
				<h3 class="qualification-title"><asp:Literal ID="ltlQualifications" runat="server" /></h3>
                <asp:Literal ID="ltlQualificationList" runat="server"></asp:Literal>
			</div>
		</div>
		<hr/>        
        
		<div class="row">
			<div class="col-md-12">
				<h3 class="dynamic-content-title"><asp:Literal ID="ltlMemberships" runat="server" /></h3>
				<asp:Literal ID="ltlMembershipsValues" runat="server" />
			</div>
		</div>            
        <hr/>
        <asp:PlaceHolder ID="phDirectorship" runat="server">
		    <div class="row">
			    <div class="col-md-12">
				    <h3 class="experience-title"><asp:Literal ID="ltlDirectorship" runat="server" /></h3>
                    <asp:Literal ID="ltlDirectorshipList" runat="server"></asp:Literal>				
			    </div>
		    </div>    
            <hr/>
        </asp:PlaceHolder>
		<div class="row">
			<div class="col-md-12">
				<h3 class="experience-title"><asp:Literal ID="ltlExperience" runat="server" /></h3>
                <asp:Literal ID="ltlExperienceList" runat="server"></asp:Literal>
			</div>
		</div>
		<hr/>
		<div class="row">
			<div class="col-md-12">
				<h3 class="skills-title"><asp:Literal ID="ltlSkills" runat="server" /></h3>
			    <div id="skill-tags">
				    <asp:Literal ID="ltlSkillsTags" runat="server"></asp:Literal>
			    </div>
			</div>
		</div>
		<hr/>
    </div>
    <div id="footer">
		<div class="container">
			<div class="row">
				<div class="col-md-2 col-md-offset-10"><asp:Image ID="imgFooterLogo" runat="server" CssClass="img-responsive" /></div>
			</div>
		</div>
	</div>
</div>
</body>
</html>