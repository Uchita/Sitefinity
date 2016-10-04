<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCVProfileDownload.ascx.cs" Inherits="JXTPortal.Website.usercontrols.member.ucCVProfileDownload" %>

<!doctype html>
<html>
<head>
<meta charset="utf-8">
    <title>Profile PDF</title>
    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,700,600' rel='stylesheet' type='text/css'>
    <link href='https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css' rel='stylesheet' type='text/css'>
    <!-- <link rel="stylesheet" type="text/css" href="css/profile-pdf.css"> -->
    <style>
    /* Minified Grid System  */
    #pdf-wrapper>.container:before{content:'';position:absolute;background:#eee;left:-50%;top:0;z-index:-1;width:100%;height:100%;display:block}.img-thumbnail,body{background-color:#fff}#header,.site-logo{text-align:center}#headline,b,strong{font-weight:700}h1{margin:.67em 0}.h1,h1{font-size:22px}.h2,h2{font-size:20px;text-transform:uppercase}.h3,h3{font-size:16px}.h4,h4{font-size:12px}.h5,h5{font-size:10px}.h6,h6{font-size:9px}p{margin:0 0 10px}.small,small{font-size:85%}ol ol,ol ul,ul ol,ul ul{margin-bottom:0}img{border:0;vertical-align:middle}hr{-moz-box-sizing:content-box;box-sizing:content-box;height:0}table{border-collapse:collapse;border-spacing:0}td,th{padding:0}*,:after,:before{-webkit-box-sizing:border-box;-moz-box-sizing:border-box;box-sizing:border-box}html{font-family:sans-serif;-ms-text-size-adjust:100%;-webkit-text-size-adjust:100%;font-size:10px;-webkit-tap-highlight-color:transparent}body{font-family:"Open Sans","Helvetica Neue",Helvetica,Arial,sans-serif;font-size:14px;line-height:1.38;color:#000;margin:0}.img-responsive{display:block;max-width:100%;height:auto}.img-rounded{border-radius:6px}.img-thumbnail{padding:4px;line-height:1.42857143;border:1px solid #ddd;border-radius:4px;-webkit-transition:all .2s ease-in-out;-o-transition:all .2s ease-in-out;transition:all .2s ease-in-out;display:inline-block;max-width:100%;height:auto}hr{margin-top:20px;margin-bottom:20px;border:0;border-top:1px solid #eee;border-top-width:5px}.container{margin-right:auto;margin-left:auto;padding-left:15px;padding-right:15px}@media (min-width:768px){.container{width:750px}}@media (min-width:992px){.container{width:970px}}@media (min-width:1100px){.container{width:1000px}}.row{margin-left:-15px;margin-right:-15px}.col-md-1,.col-md-10,.col-md-11,.col-md-12,.col-md-2,.col-md-3,.col-md-4,.col-md-5,.col-md-6,.col-md-7,.col-md-8,.col-md-9{position:relative;min-height:1px;padding-left:15px;padding-right:15px}@media (min-width:992px){.col-md-1,.col-md-10,.col-md-11,.col-md-12,.col-md-2,.col-md-3,.col-md-4,.col-md-5,.col-md-6,.col-md-7,.col-md-8,.col-md-9{float:left}.col-md-12{width:100%}.col-md-11{width:91.66666667%}.col-md-10{width:83.33333333%}.col-md-9{width:75%}.col-md-8{width:66.66666667%}.col-md-7{width:58.33333333%}.col-md-6{width:50%}.col-md-5{width:41.66666667%}.col-md-4{width:33.33333333%}.col-md-3{width:25%}.col-md-2{width:16.66666667%}.col-md-1{width:8.33333333%}.col-md-pull-12{right:100%}.col-md-pull-11{right:91.66666667%}.col-md-pull-10{right:83.33333333%}.col-md-pull-9{right:75%}.col-md-pull-8{right:66.66666667%}.col-md-pull-7{right:58.33333333%}.col-md-pull-6{right:50%}.col-md-pull-5{right:41.66666667%}.col-md-pull-4{right:33.33333333%}.col-md-pull-3{right:25%}.col-md-pull-2{right:16.66666667%}.col-md-pull-1{right:8.33333333%}.col-md-pull-0{right:auto}.col-md-push-12{left:100%}.col-md-push-11{left:91.66666667%}.col-md-push-10{left:83.33333333%}.col-md-push-9{left:75%}.col-md-push-8{left:66.66666667%}.col-md-push-7{left:58.33333333%}.col-md-push-6{left:50%}.col-md-push-5{left:41.66666667%}.col-md-push-4{left:33.33333333%}.col-md-push-3{left:25%}.col-md-push-2{left:16.66666667%}.col-md-push-1{left:8.33333333%}.col-md-push-0{left:auto}.col-md-offset-12{margin-left:100%}.col-md-offset-11{margin-left:91.66666667%}.col-md-offset-10{margin-left:83.33333333%}.col-md-offset-9{margin-left:75%}.col-md-offset-8{margin-left:66.66666667%}.col-md-offset-7{margin-left:58.33333333%}.col-md-offset-6{margin-left:50%}.col-md-offset-5{margin-left:41.66666667%}.col-md-offset-4{margin-left:33.33333333%}.col-md-offset-3{margin-left:25%}.col-md-offset-2{margin-left:16.66666667%}.col-md-offset-1{margin-left:8.33333333%}.col-md-offset-0{margin-left:0}}.clearfix:after,.clearfix:before,.container:after,.container:before,.row:after,.row:before{content:" ";display:table}.clearfix:after,.container:after,.row:after{clear:both}#pdf-wrapper>.container{background-color:#eee;position:relative}#aside,#content{padding-top:30px;margin:0}#header{padding:0 20px;margin-bottom:30px}#content{background-color:#fff}ol,ul{margin-top:0;margin-bottom:10px;padding-left:19px}.h1,.h2,.h3,.h4,h1,h2,h3,h4{margin-top:0;margin-bottom:5px;line-height:1.4}.profile-pic{margin:10px 0}.profile-pic img{border-radius:50%;max-width:150px;height:auto}#candidate-name{font-size:20px;margin-top:20px;line-height:1.2}#headline{font-size:14px;line-height:1.3;border-bottom:5px solid #626262;padding-bottom:10px}.aside-section{margin-bottom:20px;padding:0 5px}.aside-section h2{margin-bottom:10px}.section{padding:0 15px}.section-group{margin-bottom:20px}.faGroup .fa{margin-right:5px;width:13px}.personal-details span{line-height:1.7}.sub-heading{margin-bottom:5px}
    </style>
</head>

<body>


<div id="pdf-wrapper">
  <div class="container">
    <div class="row">
      <!-- Aside -->
      <div class="col-md-3" id="aside">
        <div id="header">
          <div class="site-logo">
            <asp:Image ID="imgHeaderLogo" runat="server" CssClass="img-responsive" />
          </div>
          <h1 id="candidate-name"><asp:Literal ID="ltlName" runat="server"></asp:Literal></h1>
          <div class="profile-pic">
              <asp:Image ImageUrl="https://images.jxt.net.au/profile-placeholder.png" runat="server" CssClass="thumbnail" ID="imgMemberProfile" />              
          </div>
          <p id="headline"><asp:Literal ID="ltlHeadline" runat="server"></asp:Literal></p>
        </div>

        <div class="aside-section personal-details faGroup">
            <h2><asp:Literal ID="ltTitleMyPersonalDetails" runat="server" /></h2>
              <asp:Literal ID="ltlMemberContacts" runat="server"></asp:Literal>		
<%--
            <span class="fa fa-envelope"></span>nfo@ecareer.com<br>
            <span class="fa fa-map-marker"></span>Sydney, New South Wales<br>
            <span class="fa fa-phone"></span>0452426098<br>
            <span class="fa fa-mobile"></span>0452426098--%>
          
        </div>

        <asp:Literal ID="ltlCurrentStatus" runat="server"></asp:Literal>

        <asp:Literal ID="ltAvailableDayFrom" runat="server" />
        
        <asp:Literal ID="ltTitleLanguage" runat="server" Visible="false" />
        <asp:Literal ID="ltlLanguages" runat="server" />
        
        <div class="aside-section">
          <asp:Literal ID="ltlSkills" runat="server" />
          
          <asp:Literal ID="ltlSkillsTags" runat="server"></asp:Literal>
          
        </div>

      </div>
      
      <!-- Main content -->
      <div class="col-md-9" id="content">
        <!-- Summary section -->
        <div class="section">
          <h2><asp:Literal ID="ltTitleSummary" runat="server" /></h2>
          <p><asp:Literal ID="ltlShortBio" runat="server"></asp:Literal></p>
          <hr>
        </div>
               

        <asp:PlaceHolder ID="phDirectorship" runat="server">
        <!-- Directorship section -->
        <div class="section">
          <asp:Literal ID="ltlDirectorship" runat="server" />

          <asp:Literal ID="ltlDirectorshipList" runat="server"></asp:Literal>			
          <%--<div class="section-group">
            <p class='sub-heading'><strong>JXT, Sydney, Australia</strong></p>
            <h3 class='title'>DIGITAL DESIGNER & DEVELOPER</h3>
            <p class='date'><span class='start-date'><b class='month'>Dec</b> <b class='year'>2015</b></span> - <span class='end-date'>Present</span></p>

            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim.</p>

            <p><strong>Responceibilties and Achivements:</strong></p>
            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus.</p>

            <p><strong>Directorship Types:</strong> Audit Commitee, Rick Commitee</p>
          </div>--%>
          
          <hr>
        </div>
        </asp:PlaceHolder>

        <!-- Work Experience section -->
        <div class="section">
          <asp:Literal ID="ltlExperience" runat="server" />
          <asp:Literal ID="ltlExperienceList" runat="server"></asp:Literal>
          <%--<div class="section-group">
            <p class='sub-heading'><strong>JXT, Sydney, Australia</strong></p>
            <h3 class='title'>Digital Designer & Developer</h3>
            <p class='date'><span class='start-date'><b class='month'>Dec</b> <b class='year'>2015</b></span> - <span class='end-date'>Present</span></p>

            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim.</p>
          </div>
          <div class="section-group">
            <p class='sub-heading'><strong>JXT, Sydney, Australia</strong></p>
            <h3 class='title'>Digital Designer & Developer</h3>
            <p class='date'><span class='start-date'><b class='month'>Dec</b> <b class='year'>2015</b></span> - <span class='end-date'>Present</span></p>

            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim.</p>
          </div>--%>
          <hr>
        </div>
        
        <!-- Education section -->
        <div class="section">
          <asp:Literal ID="ltlQualifications" runat="server" />
          <asp:Literal ID="ltlQualificationList" runat="server"></asp:Literal>
          <%--<div class="section-group">
            <p class='sub-heading'><strong>University of Sydney</strong></p>
            <h3 class='title'>BACHELOR OF DESIGN IN ARCHITECTURE</h3>
            <p class='date'><span class='start-date'><b class='month'>Jan</b> <b class='year'>2015</b></span> - <span class='end-date'>Nov 2015</span></p>

            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim.</p>
          </div>

          <div class="section-group">
            <p class='sub-heading'><strong>Sydney TAFE NSW</strong></p>
            <h3 class='title'>DIPLOMA OF WEB DEVELOPMENT</h3>
            <p class='date'><span class='start-date'><b class='month'>Jan</b> <b class='year'>2014</b></span> - <span class='end-date'>Jan 2015</span></p>

            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim.</p>
          </div>--%>
          <hr>
        </div>
        
        <!-- Certificatin & Memberships -->
        <asp:Literal ID="ltTitleCertification" runat="server" Visible="false" />
          <asp:Literal ID="ltlCertification" runat="server"></asp:Literal>
        <%--<div class="section">
          

        
          <div class="section-group">
            <p class='sub-heading'><strong>Sydney TAFE</strong></p>
            <h3 class='title'>CERTIFICATE IV IN TRAINING AND ASSESSMENT</h3>
            <p class='date'><span class='start-date'><b class='month'>Jan</b> <b class='year'>2015</b></span> - <span class='end-date'>Nov 2015</span></p>

            <p>sydneytafe.edu.au |Certifcate : TAE40110</p>
          </div>
          <hr>
        </div>--%>
        
        <!-- Licenses -->
        <asp:Literal ID="ltTitleLicenses" runat="server" Visible="false" />
          <asp:Literal ID="ltlLicenses" runat="server"></asp:Literal>

        <%--<div class="section">
          <h2>LICENSES</h2>
          <div class="section-group">
            <p class='sub-heading'><strong>WorkCover</strong></p>
            <h3 class='title'>WHITE CARD (CIC)</h3>
            <p class='date'><span class='start-date'><b class='month'>Jan</b> <b class='year'>2015</b></span> - <span class='end-date'>Nov 2015</span></p>

            <p>License : AA1254COV</p>
          </div>

          <div class="section-group">
            <p class='sub-heading'><strong>WorkCover</strong></p>
            <h3 class='title'>WHITE CARD (CIC)</h3>
            <p class='date'><span class='start-date'><b class='month'>Jan</b> <b class='year'>2015</b></span> - <span class='end-date'>Nov 2015</span></p>

            <p>License : AA1254COV</p>
          </div>
          <hr>
        </div>--%>

        <!-- Role Preferences -->
        <div class="section">
          <h2><asp:Literal ID="ltlRolePreferences" runat="server" /></h2>
          <div class="section-group">          

            <asp:Literal ID="ltlSalary" runat="server"></asp:Literal>
            <%--<p class='sub-heading'><strong>Full Time Wage - 80k to 100k</strong></p>--%>
            <p class="sub-heading"><asp:Literal ID="ltlLocations" runat="server"></asp:Literal></p>

            <asp:Literal ID="ltlClassifications" runat="server"></asp:Literal>
            <%--<h3 class='title'>INFORMATION & COMMUNICATION TECHNOLOGY</h3>
            <p>Developer/Programmers</p>--%>

            <asp:Literal ID="ltlWorktypes" runat="server"></asp:Literal>
            
            <asp:Literal ID="ltlEligibleToWork" runat="server"></asp:Literal>
            
          </div>

          <hr>
        </div>

        <!-- References -->
        <asp:Literal ID="ltTitleReferences" runat="server" Visible="false" />
        <asp:Literal ID="ltlReferences" runat="server"></asp:Literal>
        <%--<div class="section">
          <h2>References</h2>
          <div class="section-group">
            <p class='sub-heading'><strong>HSBC Bank Australia</strong></p>
            <h3 class='title'>SUE JOHNSON</h3>
            <p class="sub-heading">Account Manager</p>
            <div class="row">
              <div class="col-md-3">PH: 029561 220 000</div> 
              <div class="col-md-5">RELATIONSHIP: Manager</div>
            </div>
          </div>

          <div class="section-group">
            <p class='sub-heading'><strong>Company Number Two</strong></p>
            <h3 class='title'>JOHN SMITH</h3>
            <p class="sub-heading">General Manager</p>
            <div class="row">
              <div class="col-md-3">PH: 029561 220 000</div> 
              <div class="col-md-5">RELATIONSHIP: Manager</div>
            </div>
          </div>

         
          <hr>
        </div>--%>

      </div>
  </div>
</div>
</div>
</body>
</html>