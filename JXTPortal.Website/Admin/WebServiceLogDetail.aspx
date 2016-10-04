<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="WebServiceLogDetail.aspx.cs" Inherits="JXTPortal.Website.Admin.WebServiceLogDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width initial-scale=1.0">
    <!-- Font Awesome -->
    <link href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/webservices/normalize.css" />
    <link rel="stylesheet" href="css/webservices/style.css" />
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
	<script src="js/respond.min.js"></script>
	<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
    <![endif]-->
    <script src="js/webservices/jquery-ui.sortable.min.js"></script>
    <script src="js/webservices/jquery.ui.touch-punch.min.js"></script>
    <script src='js/webservices/jquery.mixitup.min.js'></script>
    <script src='js/webservices/scripts.js'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <!-- BEGIN HEADER -->
    <div class="row header">
        <div class="container">
            <div class="global-buttons">
                <ul class="anim150">
                    <li>&nbsp;</li>
                    <li>
                        Site:<br />
                        <span id="Span1">
                            <asp:Literal ID="ltSiteName" runat="server" /></span></li>
                    <li>
                        Advertiser:<br />
                        <span id="user">
                            <asp:Literal ID="ltAdvertiserName" runat="server" /></span></li>
                    <li>Time Entered:
                        <br />
                        <span id="dateStart">
                            <asp:Literal ID="ltDateStart" runat="server" /></span></li>
                    <li>Time Finished:
                        <br />
                        <span id="dateEnd">
                            <asp:Literal ID="ltDateEnd" runat="server" /></span></li>
                    <li>View<br />
                        <asp:HyperLink ID="hlViewRequest" runat="server" Text="Request" Target="_blank" />
                        |
                        <asp:HyperLink ID="hlViewResponse" runat="server" Text="Response" Target="_blank" />
                    </li>
                    <li>Download XML<br />
                        <asp:LinkButton ID="lbDownloadRequest" runat="server" Text="Request" OnClick="lbDownloadRequest_Click" />
                        |
                        <asp:LinkButton ID="lbDownloadResponse" runat="server" Text="Response" OnClick="lbDownloadResponse_Click" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!-- END HEADER -->
    <div class="row">
        <div class="container">
            <div id="box-container">
                <!-- BEGIN CONTROLS -->
                <nav class="controls just">
				<div class="group" id="filters">

		            <a class="button filter active" data-filter="all" data-dimension="posting">All (<asp:Literal ID="ltAllCount" runat="server" Text="0" />)</a> 
		            <a class="button filter" data-filter="insert" data-dimension="posting">Added (<asp:Literal ID="ltAddedCount" runat="server" Text="0" />)</a> 
		            <a class="button filter" data-filter="update" data-dimension="posting">Updated (<asp:Literal ID="ltUpdatedCount" runat="server" Text="0" />)</a> 
		            <a class="button filter" data-filter="archive" data-dimension="posting">Archived (<asp:Literal ID="ltArchivedCount" runat="server" Text="0" />)</a> 
		            <a class="button filter" data-filter="error" data-dimension="posting">Failed (<asp:Literal ID="ltFailedCount" runat="server" Text="0" />)</a> 

				</div>
			</nav>
                <!-- END CONTROLS -->
                <asp:Literal ID="ltErrorMessage" runat="server" />
                <!-- BEGIN POSTINGS -->
                <asp:Repeater ID="rptJobs" runat="server" OnItemDataBound="rptJobs_ItemDataBound">
                    <HeaderTemplate>
                        <ul id="all-postings" class="just">
                            <!-- "TABLE" HEADER CONTAINING SORT BUTTONS -->
                            <div class="list_header">
                                <div class="meta id" id="SortByID">
                                    Job Ref &nbsp; <span class="sort anim150 asc" data-sort="data-ref" data-order="asc">
                                    </span><span class="sort anim150 desc" data-sort="data-ref" data-order="desc"></span>
                                </div>
                                <div class="meta name" id="SortByName">
                                    Job Title &nbsp; <span class="sort anim150 asc" data-sort="data-name" data-order="asc">
                                    </span><span class="sort anim150 desc" data-sort="data-name" data-order="desc"></span>
                                </div>
                                <div class="meta posting active desc" id="SortByStatus">
                                    Status &nbsp; <span class="sort anim150 asc active" data-sort="data-posting" data-order="desc">
                                    </span><span class="sort anim150 desc" data-sort="data-posting" data-order="asc">
                                    </span>
                                </div>
                            </div>
                            <!-- DATA ELEMENT 

					Attribute [data-posting]
					[1] = Error		[Filter FAILED]
					[2] = Archived	[Filter ARCHIVED]
					[3] = Live		[Filter ADDED]
					[4] = Updated	[Filter UPDATED]

				 -->
                            <!-- BEGIN LIST OF POSTINGS -->
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Literal ID="ltListHeader" runat="server" />
                        <div class="meta id" id="SortByID">
                            <p>
                                <asp:Literal ID="ltRefNo" runat="server" /></p>
                        </div>
                        <div class="meta name" id="SortByName">
                            <div class="titles">
                                <asp:Literal ID="ltUrl" runat="server" />
                                <b>
                                    <asp:Literal ID="ltTitle" runat="server" /></b>
                                </a>
                            </div>
                        </div>
                        <div class="meta posting">
                            <p>
                                <asp:Literal ID="ltAction" runat="server" /></p>
                        </div>
                        <div class="meta details"></div>

                        <div class="additional-info"><asp:Literal ID="ltAdditionalInfo" runat="server" /></div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul></FooterTemplate>
                </asp:Repeater>
                <!-- END LIST OF POSTINGS -->
                </ul><!-- #all-postings -->
            </div>
            <!-- #box-container -->
        </div>
    </div>
</asp:Content>
