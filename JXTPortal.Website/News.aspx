<%@ Page Title="News" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="JXTPortal.Website.News" %>

<%@ Register Src="usercontrols/navigation/ucNewsCategoryList.ascx" TagName="ucNewsCategoryList"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/scripts/news-script.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function RefineNews() {

            $('.jxt-news-filter-category a').each(
                    function () {
                        if ($(this).attr('class') == 'active') {
                            $('#hfCategories').val($('#hfCategories').val() + $(this).prev().val() + ',');
                        }
                    }
                )

            $('.jxt-news-filter-industry a').each(
                    function () {
                        if ($(this).attr('class') == 'active') {
                            $('#hfNewsIndustry').val($('#hfNewsIndustry').val() + $(this).prev().val() + ',');
                        }
                    }
                )

            $('.jxt-news-filter-type a').each(
                    function () {
                        if ($(this).attr('class') == 'active') {
                            $('#hfNewsType').val($('#hfNewsType').val() + $(this).prev().val() + ',');
                        }
                    }
                )

            $('.jxt-news-filter-sort-by a').each(
                    function () {
                        if ($(this).attr('class') == 'active') {
                            $('#hfSortBy').val($(this).attr('data-item'));
                        }
                    }
                )

            $('#aspnetForm').submit();
        }

        function runRefine(e) {
            if (e.keyCode == 13) {
                RefineNews();
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_tbKeywords').keydown(function (event) {
                if (event.keyCode == 13) {
                    RefineNews();

                    event.preventDefault();
                    return false;
                }
            });
        });
    </script>
    <div id="content-container">
        <div id="side-left">
            <div class="jxt-news-filter-container">
                <h2>
                    <JXTControl:ucLanguageLiteral ID="ltRefineResults" runat="server" SetLanguageCode="LabelRefineResult" /></h2>
                <div class="jxt-news-filter-refinements">
                    <asp:HiddenField ID="hfCategories" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hfNewsType" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hfNewsIndustry" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hfSortBy" runat="server" ClientIDMode="Static" />
                    <div class="jxt-news-filter jxt-news-filter-keywords">
                        <h3 id="jxt-news-filter-keywords-heading">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelKeywords" /></h3>
                        <div class="jxt-news-filter-options">
                            <div class="jxt-news-filter-input">
                                <asp:TextBox ID="tbKeywords" runat="server" aria-describedby="jxt-news-filter-keywords-heading"
                                    CssClass="form-control" onkeypress="return runRefine(event)" />
                            </div>
                        </div>
                    </div>
                    <asp:PlaceHolder ID="phRefineCategory" runat="server">
                        <div class="jxt-news-filter jxt-news-filter-category">
                            <h3 id="jxt-news-filter-category-heading">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelCategories" /></h3>
                            <div class="jxt-news-filter-options">
                                <div class="jxt-news-filter-dropdown active">
                                    <ul class="jxt-news-filter-multiple" aria-describedby="jxt-news-filter-category-heading">
                                        <asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="rptCategories_ItemDataBound">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:HiddenField ID="hfNewsCategoryID" runat="server" />
                                                    <a id="lbCategory" runat="server" onclick="return false;" /></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phRefineIndustry" runat="server">
                        <div class="jxt-news-filter jxt-news-filter-industry">
                            <h3 id="jxt-news-filter-industry-heading">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelIndustries" /></h3>
                            <div class="jxt-news-filter-options">
                                <div class="jxt-news-filter-dropdown active">
                                    <ul class="jxt-news-filter-multiple" aria-describedby="jxt-news-filter-industry-heading">
                                        <asp:Repeater ID="rptIndustries" runat="server" OnItemDataBound="rptIndustries_ItemDataBound">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:HiddenField ID="hfNewsIndustryID" runat="server" />
                                                    <a id="lbIndustry" runat="server" onclick="return false;" /></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phRefineType" runat="server">
                        <div class="jxt-news-filter jxt-news-filter-type">
                            <h3 id="jxt-news-filter-type-heading">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelType" /></h3>
                            <div class="jxt-news-filter-options">
                                <div class="jxt-news-filter-dropdown active">
                                    <ul class="jxt-news-filter-multiple" aria-describedby="jxt-news-filter-type-heading">
                                        <asp:Repeater ID="rptType" runat="server" OnItemDataBound="rptType_ItemDataBound">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:HiddenField ID="hfNewsTypeID" runat="server" />
                                                    <a id="lbType" runat="server" onclick="return false;" /></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                    <div class="jxt-news-filter jxt-news-filter-sort-by">
                        <h3 id="jxt-news-filter-sort-by-heading">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelSortsby" /></h3>
                        <div class="jxt-news-filter-options">
                            <div class="jxt-news-filter-summary" aria-expanded="false" aria-controls="jxt-collapsible-0"
                                data-default-summary="Latest">
                                <asp:Literal ID="ltSortBy" runat="server" /></div>
                            <div id="jxt-collapsible-0" class="jxt-news-filter-dropdown" aria-hidden="true">
                                <ul class="jxt-news-filter-single" aria-describedby="jxt-news-filter-sort-by-heading">
                                    <li><a id="aSortLatest" runat="server" data-item="latest"></a></li>
                                    <li><a id="aSortOldest" runat="server" data-item="oldest"></a></li>
                                    <li><a id="aSortAZ" runat="server" data-item="az"></a></li>
                                    <li><a id="aSortZA" runat="server" data-item="za"></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="jxt-news-search">
                        <div class="button">
                            <asp:LinkButton ID="lbRefine" runat="server" CssClass="btn btn-default" OnClientClick="RefineNews()">
                                        <i class="fa fa-search"></i> <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelRefine" />
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:MultiView ID="mvNews" runat="server" ActiveViewIndex="0">
            <asp:View ID="vNews" runat="server">
                <div id="content" class="col-sm-8 col-md-9">
                    <div class="content-holder">
                        <section class="jxt-news-container">
				<div class="jxt-news-rss">
					<div class="button">
                        <asp:HyperLink ID="hlNewsRss" runat="server" CssClass="btn btn-default"><i class="fa fa-rss"></i> <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelRSSFeed" /></asp:HyperLink>
					</div>
				</div>
				
				<h1>News</h1> <!-- should be configurable in the back end page -->

				<!-- The following can be used for search result links -->
				<!-- <p><strong>Showing results for&hellip;</strong></p> --> 
                <asp:Literal id="ltRefineResult" runat="server" />
			    <asp:Repeater id="rptNews" runat="server" OnItemDataBound="rptNews_ItemDataBound">
                <ItemTemplate>
				    <asp:Literal id="ltArticleStartTag" runat="server" /> <!-- <article class="jxt-news-item jxt-has-image" itemscope="" itemtype="http://schema.org/NewsArticle"> -->
					<h2 class="jxt-news-item-title" itemprop="name headline">
                    <asp:HyperLink ID="hlNewsTitle" runat="server" itemprop="mainEntityOfPage" rel="bookmark" />
                    </h2> <!-- automatically insert non-breaking space -->
                    <asp:PlaceHolder id="plImage" runat="server" Visible="false">
					    <figure class="jxt-news-item-image" itemprop="image" itemscope="" itemtype="http://schema.org/ImageObject">
                            <asp:Literal id="ltMeta" runat="server" />
						    <!-- <img src="https://images.jxt.net.au/responsive-17/images/placeholder1.jpg" alt="Why Temp Works – Find Temporary Jobs Quickly with Temp Agencies">
						    <meta itemprop="url" content="https://images.jxt.net.au/responsive-17/images/placeholder1.jpg">
						    -->
					    </figure>
                    </asp:PlaceHolder>
					<p class="jxt-news-item-excerpt" itemprop="description">
                        <asp:Literal ID="ltDescription" runat="server" />
                    </p>
					<footer class="jxt-news-item-meta-data">
                        <asp:PlaceHolder id="phNewsType" runat="server">
						<dl class="jxt-news-item-post-type">
							<dt><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelPostType" /></dt>
							<dd>
                            <asp:Literal ID="ltPostType" runat="server" />
                            <!-- <a href=""><img src="media/icon-article.png" alt="Article">Article</a> -->
                            </dd>
						</dl>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder id="phNewsCategory" runat="server">
						<dl class="jxt-news-item-category">
							<dt><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelFiledUnder" /></dt> 
                            <dd itemprop="keywords">
                            <asp:Literal ID="ltNewsCategory" runat="server" />
                            </dd>                                
						</dl>
                        </asp:PlaceHolder>
						<dl class="jxt-news-item-date-published">
							<dt><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelDatePublished" /></dt>
							<dd><time itemprop="datePublished"><asp:Literal id="ltDatePublished" runat="server" /></time></dd>
						</dl>
						<dl class="jxt-news-item-date-modified">
							<dt><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral15" runat="server" SetLanguageCode="LabelDateModified" /></dt>
							<dd><time itemprop="dateModified"><asp:Literal id="ltDateModified" runat="server" /></time></dd>
						</dl>
                        <asp:PlaceHolder id="phAuthor" runat="server">
						<dl class="jxt-news-item-author">
							<dt><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral16" runat="server" SetLanguageCode="LabelAuthor" /></dt>
							<dd itemprop="author">
								<asp:Literal ID="ltAuthor" runat="server" />
							</dd>
							<dd itemprop="publisher" itemscope="" itemtype="https://schema.org/Organization">
								<div itemprop="name"><asp:Literal ID="ltSiteName" runat="server" /></div>
                                <asp:Literal ID="ltSiteImage" runat="server" />
								<%--<figure itemprop="logo" itemscope="" itemtype="https://schema.org/ImageObject">
									<img src="http://r17.jxt.com.au/GetAdminLogo.aspx?SiteID=404" alt="Chandler Macleod">
									<meta itemprop="url" content="http://r17.jxt.com.au/GetAdminLogo.aspx?SiteID=404">
								</figure>--%>
							</dd>
						</dl>
			            </asp:PlaceHolder>
					</footer>
				</article>
                </ItemTemplate>
                </asp:Repeater>
				<!-- repeat articles here -->

				<footer class="jxt-news-pagination">
                    <asp:Repeater id="rptNewsPages" runat="server" OnItemDataBound="rptPage_ItemDataBound" OnItemCommand="rptPage_ItemCommand">
                        <HeaderTemplate><nav>
                        <asp:LinkButton id="lbPrevious" runat="server" CommandName="Page" CssClass="jxt-news-previous" title="Previous Page">
                            <i class="fa fa-chevron-left"></i>
                        </asp:LinkButton>
                        <asp:LinkButton id="lbNext" runat="server" CommandName="Page" CssClass="jxt-news-next" title="Next Page">
                            <i class="fa fa-chevron-right"></i>
                        </asp:LinkButton>
                        <asp:LinkButton id="lbFirst" runat="server" CssClass="jxt-news-first-page" title="First Page" CommandName="Page">
                            1
                        </asp:LinkButton><!-- will not appear if we are on page 1 - 3 -->

						<asp:PlaceHolder id="phDots" runat="server"><span class="jxt-news-ellipsis">…</span></asp:PlaceHolder> <!-- will not appear if we are on page 1 to 3 -->
						<ul></HeaderTemplate>
                        <ItemTemplate>
                            <asp:Literal ID="ltPage" runat="server" />
                                <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" />
                            </li> <!-- active page - always in the middle unless we are on pages 1 to 3 or pages n-2 to n (n being the last page number) -->
                        </ItemTemplate>
                        <FooterTemplate></ul>
						<asp:PlaceHolder id="phDots" runat="server">
                            <span class="jxt-news-ellipsis">…</span>
                        </asp:PlaceHolder> <!-- will not appear if we are on page n-2 to n (n being the last page number) -->

                        <asp:LinkButton id="lbLastPage" runat="server" CssClass="jxt-news-last-page" title="Last Page" CommandName="Page" /><!-- will not appear if we are on page n-2 to n (n being the last page number) -->
					</nav></FooterTemplate>
                    </asp:Repeater>

				</footer>
				
			</section>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="vArticle" runat="server">
                <div id="content">
                    <div class="content-holder">
                        <nav class="jxt-news-breadcrumbs breadcrumbs" role="navigation" aria-label="Breadcrumbs">
                            <ol itemscope itemtype="http://schema.org/BreadcrumbList">
                                <li itemprop="itemListElement" itemscope itemtype="http://schema.org/ListItem">
                                    <a itemprop="item" href="/news/">
                                        <span itemprop="name">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral17" runat="server" SetLanguageCode="LabelNewsHome" /></span></a>
                                    <meta itemprop="position" content="1" />
                                </li>
                                <li itemprop="itemListElement" itemscope itemtype="http://schema.org/ListItem">
                                    <asp:Literal ID="ltDetailBreadcrumb" runat="server" />
                                    <meta itemprop="position" content="2" />
                                </li>
                            </ol>
			             </nav>
                        <section class="jxt-news-container jxt-single-item">
                        <asp:Literal id="ltDetailArticleStartTag" runat="server" /><!-- <article class="jxt-news-item jxt-has-image" itemscope="" itemtype="http://schema.org/NewsArticle"> -->
                        <asp:Literal id="ltDetailMeta" runat="server" />
					<h1 class="jxt-news-item-title" itemprop="name headline">
                        <asp:Literal ID="ltDetailSubject" runat="server" /></h1> <!-- automatically insert non-breaking space -->
					<%--<asp:PlaceHolder id="phDetailImage" runat="server">
                        <figure class="jxt-news-item-image" itemprop="image" itemscope="" itemtype="http://schema.org/ImageObject">
                        <asp:Image id="imgDetailNews" runat="server" />
                        
                    
					</figure>
                    </asp:PlaceHolder>--%>
					<asp:Literal ID="ltDetailDescription" runat="server" />
                    <footer class="jxt-news-item-meta-data">
                        <asp:PlaceHolder id="phDetailNewsType" runat="server">
						<dl class="jxt-news-item-post-type">
							<dt><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral18" runat="server" SetLanguageCode="LabelPostType" /></dt>
							<dd>
                                <asp:Literal ID="ltDetailNewsType" runat="server" />
                            <!--<a href="">
                                <img src="media/icon-article.png" alt="Article">Article</a>--></dd>
						</dl>
                        </asp:PlaceHolder>
						<dl class="jxt-news-item-category">
							<dt><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral19" runat="server" SetLanguageCode="LabelFiledUnder" /></dt> 
							<dd itemprop="keywords"><asp:Literal ID="ltDetailCategory" runat="server" /></dd>
						</dl>
						<dl class="jxt-news-item-date-published">
							<dt><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral20" runat="server" SetLanguageCode="LabelDatePublished" /></dt>
							<dd><time itemprop="datePublished">
                                <asp:Literal id="ltDetailDatePublished" runat="server" /></time></dd>
						</dl>
						<dl class="jxt-news-item-date-modified">
							<dt><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral21" runat="server" SetLanguageCode="LabelDateModified" /></dt>
							<dd><time itemprop="dateModified">
                                <asp:Literal id="ltDetailDateModified" runat="server" /></time></dd>
						</dl>
                        <asp:PlaceHolder id="phDetailAuthor" runat="server">
						<dl class="jxt-news-item-author">
							<dt><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral22" runat="server" SetLanguageCode="LabelAuthor" /></dt>
							<dd itemprop="author">
								<asp:Literal ID="ltDetailAuthor" runat="server" />
							</dd>
							<dd itemprop="publisher" itemscope="" itemtype="https://schema.org/Organization">
								<div itemprop="name"><asp:Literal id="ltDetailSiteName" runat="server" /></div>
                                <asp:Literal id="ltDetailSiteImage" runat="server" />
								<%--<figure itemprop="logo" itemscope="" itemtype="https://schema.org/ImageObject">
									<img src="http://r17.jxt.com.au/GetAdminLogo.aspx?SiteID=404" alt="Chandler Macleod">
									<meta itemprop="url" content="http://r17.jxt.com.au/GetAdminLogo.aspx?SiteID=404">
									<meta itemprop="width" content="300">
									<meta itemprop="height" content="100">
								</figure>--%>
							</dd>
						</dl>
						</asp:PlaceHolder>
					</footer>
                    <asp:Literal id="ltShare" runat="server" />


				</article>
				
			</section>
                        <hr class="jxt-news-separator">
                        <asp:PlaceHolder ID="phRelatedArticles" runat="server">
                            <section class="jxt-related-articles-container">
				        <h2><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral23" runat="server" SetLanguageCode="LabelRelatedArticles" /></h2>
                        <div class="jxt-recent-articles-holder">
                        <asp:Repeater id="rptRelatedArticles" runat="server" OnItemDataBound="rptRelatedArticles_ItemDataBound">
                        <ItemTemplate>
				            <article class="jxt-related-article" itemscope="" itemtype="http://schema.org/NewsArticle">
					            <h3 class="jxt-related-item-title" itemprop="name headline"><asp:Literal ID="ltSubject" runat="server" /></a></h3>
					            <p class="jxt-related-item-excerpt" itemprop="description"><asp:Literal ID="ltDescription" runat="server" /></p>
					            <p class="jxt-related-item-link"><asp:HyperLink id="hlReadMore" runat="server"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelReadMore" /> <i class="fa fa-chevron-right"></i></asp:HyperLink></p>
				            </article>
                            </ItemTemplate>
                        </asp:Repeater>
                        </div>
			            </section>
                        </asp:PlaceHolder>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
