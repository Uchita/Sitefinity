<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs"
    Inherits="JXTPortal.Website.Admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta http-equiv="content-language" content="en" />
    <meta name="robots" content="noindex,nofollow" />
    <title>Login</title>
    
    
		<meta charset="utf-8">
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		
		<!-- Latest compiled and minified CSS -->
		<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">
		<link rel="stylesheet" type="text/css" href="//images.jxt.net.au/jxt-admin/css/style-admin.css">
		<link rel="stylesheet" type="text/css" href="//images.jxt.net.au/jxt-admin/css/style.css">
		<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js"></script>

		<!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
		<!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
		<!--[if lt IE 9]>
			<script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
			<script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
		<![endif]-->
        <%--<style>#login-secure-error {
    margin: 0 auto;
    position: relative;
    width: 430px;
    background: none repeat scroll 0 0 #FFDFDF;
    border: 1px solid #F3AFB5;
    -webkit-border-radius: 4px;
    -moz-border-radius: 4px;
    border-radius: 4px;
    padding: 10px;
    font-size:12px;
    text-align:center;
    font-family:Arial;
    display:block;

}</style>--%>
</head>
<body id="login-bg">
    <form id="form1" runat="server">
    
    <div class="bg-image hidden-xs hidden-sm"></div>
	
	<div class="container">
		
		<div class="row">
			<!-- Admin Col -->
			<div class="col-xs-12 col-sm-12 col-md-12 col-lg-6 col-vert-position">

			<div class="v-align">
				<!-- Logo -->
				<div class="row">
					<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
						<a href="https://www.jxt.com.au" target="_blank"><img class="logo" src="//images.jxt.net.au/jxt-admin/img/JXT-logo.png" height="66" width="140" alt="JXT"></a>
					</div> <!--/ Logo -->
				</div>

				<!-- Admin Box -->
				<div class="row">
					<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                        
                        <asp:Literal ID="ltErrorMessage" runat="server" />

						<div class="form-area">
							
							<!-- Form Title -->
							<div class="row">
								<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center" id="form-title">
								Login	
								</div>
							</div><!--/ Form Title -->
                            
						    <!-- Site -->
						    <div class="row">
							    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center site-url">
							    Site URL: <asp:Literal ID="ltlSiteUrl" runat="server" />
							    </div>
						    </div>
							<!-- Form USERNAME -->
							
										<!-- Username [Label] -->
										<div class="row">
											<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-left">
											<label for="username">Username</label>
											</div>
										</div>
										<!-- Username [Input] -->
										<div class="row">
											<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
                                                <asp:TextBox ID="txtUserName" runat="server" placeholder="Enter Username" />
											</div>
										</div>
										<!-- Password [Label] -->
										<div class="row">
											<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-left">
												<label for="pswd" id="pass-margin">Password</label>
											</div>
										</div>
										<!-- Password [Input] -->
										<div class="row">
											<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="login-inp" placeholder="Enter Password" AutoCompleteType="None" autocomplete="off" />												
											</div>
										</div>
										<!-- Submit [Button] -->
										<div class="row">
											<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
												<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
											</div>
										</div>
										<%--
										<div class="row">
											<!-- Remember [Check box] -->
											<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6 text-right" id="check1">
												<input type="checkbox" name="remember-pswd" value=""><span style="font-size: 14px;"> Remember Password</span><br>
											</div>
											<!-- Admin [Check box] -->
											<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6 text-center" id="check2">
												<input type="checkbox" name="admin-pswd" value=""><span style="font-size: 14px;"> Login as Admin</span><br>
											</div>
										</div>--%>
							

						</div>
					</div>
				</div><!--/ Admin Box -->
				
				<!-- Forgot Password -->
				<div class="row">
					<div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
						<a href="http://www.jxt.com.au/support" title="Recover details" target="_blank">
							<strong><p style="color:#000;">Forgot Password?</p></strong>
						</a>
					</div>
				</div><!--/ Forgot Password -->


				<!-- Request A Demo -->
				<div class="row vertical-align">
					<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6 text-right hidden-xs">
					<strong><p style="color:#000; margin:0px;">Not a Customer?</p></strong>
					</div>
					<!-- Button -->
					<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6 hidden-xs">
						<a href="https://www.jxt.com.au/demo" target="_blank">
						<div class="req-demo">REQUEST A DEMO</div>
						</a>
					</div>
				</div>
			</div>
			</div><!--/ Admin Col -->


			<!-- Adverb Col -->
			<div class="col-xs-6 col-sm-6 col-md-6 col-lg-6 adverb-position hidden-xs hidden-sm hidden-md">
				<%--<!-- Text Content -->
				<p id="title">PLACE CANDIDATES FASTER</p>
				<h1>BY RECEIVING ONLINE APPLICATIONS FROM <br>MOBILE DEVICES</h1>
				<!-- Read More Button -->
				<div class="hidden-xs hidden-sm hidden-md">
					<a href="https://www.jxt.com.au/core-features-benefits">
						<button class="read-more">Read More</button>
					</a>
				</div>--%>
                <asp:Literal ID="ltlContent" runat="server"></asp:Literal>


			</div>
		</div>
	</div>

    </form>
</body>
</html>
