<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="ConsultantsEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.ConsultantsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Consultants - Add/Edit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release" />
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <asp:HiddenField ID="hfConsultantId" runat="server" />
        <ul class="form-section">
            <li class="form-line" id="admin-consultanttitle">
                <asp:Label ID="lbTitle" runat="server" CssClass="form-label-left" AssociatedControlID="tbTitle">
                    Title:</asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbTitle" runat="server" Width="250px"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="admin-consultantName">
                <asp:Label ID="lbConsultantName" runat="server" CssClass="form-label-left" AssociatedControlID="tbName">
                    First Name:<span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbName" runat="server" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfName" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="tbName" SetFocusOnError="true" />  
                </div>
            </li>
            <li class="form-line" id="admin-consultantLastName">
                <asp:Label ID="lbConsultantLastName" runat="server" CssClass="form-label-left" AssociatedControlID="tbLastName">
                    Last Name:<span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbLastName" runat="server" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfLastName" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="tbLastName" SetFocusOnError="true" />  
                </div>
            </li>
            <li class="form-line" id="admin-status">
                <asp:Label ID="Label4" runat="server" CssClass="form-label-left" AssociatedControlID="ddlStatus">
                    Status:<span class="form-required">*</span> </asp:Label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="250px">
                        <asp:ListItem Value="1" Selected="True">Visible</asp:ListItem>
                        <asp:ListItem Value="2">Not Visible</asp:ListItem>
                        <asp:ListItem Value="3">Archived</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfStatus" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="ddlStatus" InitialValue="0" SetFocusOnError="true" />
                </div>
            </li>
            <li class="form-line" id="admin-friendlyurl">
                <asp:Label ID="lbFriendlyURL" runat="server" CssClass="form-label-left" AssociatedControlID="tbFriendlyURL">
                    Friendly URL:<span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbFriendlyURL" runat="server" Width="250px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfFriendlyURL" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="tbFriendlyURL" SetFocusOnError="true" />
                        <asp:CustomValidator ID="cvName" runat="server" ControlToValidate="tbFriendlyURL"
                            SetFocusOnError="true" Display="Dynamic"  ErrorMessage="Friendly URL already exists"
                        onservervalidate="cvName_ServerValidate"></asp:CustomValidator>
                </div>
            </li>
            <li class="form-line" id="admin-positiontitle">
                <asp:Label ID="lbPositionTitle" runat="server" CssClass="form-label-left" AssociatedControlID="tbPositionTitle">
                    Position Title:</asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbPositionTitle" runat="server" Width="250px"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="admin-consultantphone">
                <asp:Label ID="lbPhone" runat="server" CssClass="form-label-left" AssociatedControlID="tbPhone">
                    Phone:</asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbPhone" runat="server" Width="250px"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="admin-mobile">
                <asp:Label ID="lbMobile" runat="server" CssClass="form-label-left" AssociatedControlID="tbMobile">
                    Mobile:</asp:Label>
                <div class="form-input">
                    <asp:TextBox ID="tbMobile" runat="server" Width="250px"></asp:TextBox>
                </div>
            </li>
            <li class="form-line" id="admin-consultantemail">
                <asp:Label ID="lbEmail" runat="server" CssClass="form-label-left" AssociatedControlID="tbEmail">
                    Email:<span class="form-required">*</span></asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbEmail" runat="server" Width="250px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfEmail" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="tbEmail" SetFocusOnError="true" />
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-imageurl">
                <asp:Label ID="lbImageURL" runat="server" CssClass="form-label-left" AssociatedControlID="fuImage">
                    Image:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:Image ID="imImage" runat="server" Visible="false" />
                        <asp:CheckBox ID="cbRemoveImage" runat="server" Visible="false" Text="Remove Image" />
                        <asp:FileUpload ID="fuImage" runat="server" /><asp:CustomValidator ID="cvalFileName"
                            runat="server" OnServerValidate="cvalFileName_ServerValidate" SetFocusOnError="true"
                            Display="Dynamic"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvalFile" runat="server" OnServerValidate="cvalFile_ServerValidate"
                            SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-videourl">
                <asp:Label ID="lbVideoURL" runat="server" CssClass="form-label-left" AssociatedControlID="tbVideoURL">
                    Video URL:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbVideoURL" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-location">
                <asp:Label ID="lbLocation" runat="server" CssClass="form-label-left" AssociatedControlID="tbLocation">
                    Location:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbLocation" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-officelocation">
                <asp:Label ID="lbOfficeLocation" runat="server" CssClass="form-label-left" AssociatedControlID="tbOfficeLocation">
                    Office Location:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbOfficeLocation" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-categories">
                <asp:Label ID="lbCategories" runat="server" CssClass="form-label-left" AssociatedControlID="tbCategories">
                    Categories:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbCategories" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-sequence">
                <asp:Label ID="lbSequence" runat="server" CssClass="form-label-left" AssociatedControlID="tbSequence">
                    Sequence:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbSequence" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="Li2">
                <asp:Label ID="lbFeaturedTeamMember" runat="server" CssClass="form-label-left" AssociatedControlID="tbFeaturedTeamMember">
                    Featured Team Member:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:CheckBox ID="tbFeaturedTeamMember" runat="server"></asp:CheckBox>
                    </div>
                </div>
            </li>
            
            <li class="form-line" id="admin-shortdescription">
                <asp:Label ID="lbShortDescription" runat="server" CssClass="form-label-left" AssociatedControlID="tbShortDescription">
                    Short Description:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                    <FredCK:CKEditorControl ID="tbShortDescription" runat="server" TextMode="MultiLine"
                            Rows="3" Columns="20" CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false" />
                        
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-fulldescription">
                <label class="form-label-left">
                    Full Description:</label>
                <div class="form-input">
                    <div class="form-input">
                        <FredCK:CKEditorControl ID="tbFullDescription" runat="server" TextMode="MultiLine"
                            Rows="3" Columns="20" CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false" />
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-testimonial">
                <label class="form-label-left">
                    Testimonial:</label>
                <div class="form-input">
                    <div class="form-input">
                        <FredCK:CKEditorControl ID="tbTestimonial" runat="server" TextMode="MultiLine" Rows="3"
                            Columns="20" CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false" /></FredCK:CKEditorControl>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-blogrss">
                <asp:Label ID="lbBlogRSS" runat="server" CssClass="form-label-left" AssociatedControlID="tbBlogRSS">
                    Blog RSS:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbBlogRSS" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-newsrss">
                <asp:Label ID="Label1" runat="server" CssClass="form-label-left" AssociatedControlID="tbNewsRSS">
                    News RSS:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbNewsRSS" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-jobrss">
                <asp:Label ID="Label3" runat="server" CssClass="form-label-left" AssociatedControlID="tbJobRSS">
                    Job RSS:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbJobRSS" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-testimonialsrss">
                <asp:Label ID="lbTestimonialsRSS" runat="server" CssClass="form-label-left" AssociatedControlID="tbTestimonialsRSS">
                    Testimonials RSS:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbTestimonialsRSS" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-LastModifiedDate">
                <label class="form-label-left">
                    <strong>Social Media</strong></label>
                <div class="form-input">
                    <div class="form-input">
                        &nbsp;
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-linkedin">
                <asp:Label ID="lbLinkedIn" runat="server" CssClass="form-label-left" AssociatedControlID="tbLinkedIn">
                    LinkedIn:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbLinkedIn" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-facebook">
                <asp:Label ID="lbFacebook" runat="server" CssClass="form-label-left" AssociatedControlID="tbFacebook">
                    Facebook:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbFacebook" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-twitter">
                <asp:Label ID="lbTiwtter" runat="server" CssClass="form-label-left" AssociatedControlID="tbTwitter">
                    Twitter:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbTwitter" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-google">
                <asp:Label ID="lbGoogle" runat="server" CssClass="form-label-left" AssociatedControlID="tbGoogle">
                    Google:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbGoogle" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-wechat">
                <asp:Label ID="lbWeChat" runat="server" CssClass="form-label-left" AssociatedControlID="tbWeChat">
                    WeChat:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbWeChat" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-link">
                <asp:Label ID="Label2" runat="server" CssClass="form-label-left" AssociatedControlID="tbLink">
                    Link:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbLink" runat="server" Width="250px"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="Li1">
                <label class="form-label-left">
                    <strong>SEO</strong></label>
                <div class="form-input">
                    <div class="form-input">
                        &nbsp;
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-metatitle">
                <asp:Label ID="lbMetaTitle" runat="server" CssClass="form-label-left" AssociatedControlID="tbMetaTitle">
                    Meta Title:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbMetaTitle" runat="server" Width="250px" Rows="3"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-metakeyword">
                <asp:Label ID="lbMetaKeyword" runat="server" CssClass="form-label-left" AssociatedControlID="tbMetaKeyword">
                    Meta Keyword:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbMetaKeyword" runat="server" Width="250px" Rows="3"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-metadescription">
                <asp:Label ID="lbMetaDescription" runat="server" CssClass="form-label-left" AssociatedControlID="tbMetaDescription">
                    Meta Description:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:TextBox ID="tbMetaDescription" runat="server" Width="250px" Rows="3"></asp:TextBox>
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-lastmodified">
                <asp:Label ID="lbLastModified" runat="server" CssClass="form-label-left" AssociatedControlID="ltLastModified">
                    Last Modified:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:Literal ID="ltLastModified" runat="server" />
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-lastmodifiedby">
                <asp:Label ID="lbLastModifiedBy" runat="server" CssClass="form-label-left" AssociatedControlID="ltLastModifiedBy">
                    Last Modified By:</asp:Label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:Literal ID="ltLastModifiedBy" runat="server" />
                    </div>
                </div>
            </li>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                            CssClass="jxtadminbutton" CausesValidation="false" />
                    </div>
                </div>
            </li>
        </ul>

        <asp:PlaceHolder ID="phMultilingual" runat="server" Visible="false">
            <asp:UpdatePanel ID="upMultiLingual" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <h2>
                        Multilingual</h2>
                    <span class="form-message">
                        <asp:Literal ID="ltMultilingualMessage" runat="server" /></span>
                    <asp:Repeater ID="rptMultilingual" runat="server" OnItemDataBound="rptMultilingual_ItemDataBound"
                        OnItemCommand="rptMultilingual_ItemCommand">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbLanguage" runat="server" CommandName="Language" />
                        </ItemTemplate>
                    </asp:Repeater>
                    <ul class="form-section">
                        <li class="form-line" id="Li24">
                            <label class="form-label-left">
                                Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiTitle" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li3">
                            <label class="form-label-left">
                                First Name:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiFirstName" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li4">
                            <label class="form-label-left">
                                Last Name:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiLastName" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li5">
                            <label class="form-label-left">
                                Position Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiPositionTitle" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li6">
                            <label class="form-label-left">
                                Location:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiLocation" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li7">
                            <label class="form-label-left">
                                Office Location:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiOfficeLocation" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li8">
                            <label class="form-label-left">
                                Categories:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiCategories" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li9">
                            <label class="form-label-left">
                                Short Description:
                            </label>
                            <div class="form-input">
                                <FredCK:CKEditorControl ID="txtMultiShortDescription" runat="server" TextMode="MultiLine"
                            Rows="3" Columns="20" CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false" />
                            </div>
                        </li>
                        <li class="form-line" id="Li10">
                            <label class="form-label-left">
                                Full Description:
                            </label>
                            <div class="form-input">
                                <FredCK:CKEditorControl ID="txtMultiFullDescription" runat="server" TextMode="MultiLine"
                            Rows="3" Columns="20" CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false" />
                            </div>
                        </li>
                        <li class="form-line" id="Li11">
                            <label class="form-label-left">
                                Testimonial:
                            </label>
                            <div class="form-input">
                                <FredCK:CKEditorControl ID="txtMultiTestimonial" runat="server" TextMode="MultiLine"
                            Rows="3" Columns="20" CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false" />
                            </div>
                        </li>
                        <li class="form-line" id="Li12">
                            <label class="form-label-left">
                                Meta Title:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiMetaTitle" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li13">
                            <label class="form-label-left">
                                Meta Keyword:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiMetaKeyword" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li14">
                            <label class="form-label-left">
                                Meta Description:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="txtMultiMetaDescription" runat="server" Width="400" />
                            </div>
                        </li>
                        <li class="form-line" id="Li38">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="btnMultilingualSave" runat="server" Text="Save" OnClick="btnMultilingualSave_Click"
                                        CssClass="jxtadminbutton" ValidationGroup="MultiLingual" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:PlaceHolder>
    </div>
</asp:Content>
