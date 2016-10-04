<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aicd_scholarship_doc.aspx.cs"
    Inherits="JXTPortal.Website.job.application.doc.aicd_scholarship_doc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="width: 100%">
        <img src="//images.jxt.net.au/AICD-Scholarships/images/logo-app.jpg" alt="AICD" /></div>
    <p align="center" style="font-weight: bold; font-size: 14pt;">
        <asp:Literal ID="ltJobName" runat="server" />
        Application</p>
    <font face="Arial" size="1">
        <table width="100%" border="1">
            <tr>
                <td align="left" valign="top" bgcolor="#FFF" style="padding: 8px 12px" colspan="2">
                    <font face="Arial" size="1">
                        <p style="font-weight: bold; font-size: 16pt;">
                            Personal details</p>
                </td>
            </tr>
            <tr>
                <td width="43%" align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Title</strong>
                </td>
                <td width="57%" style="padding: 8px 12px">
                    <asp:Literal ID="ltTitle" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>First name</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltFirstName" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Middle name</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltMiddleName" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Last name</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltLastName" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Honorifics (e.g. GAICD, AO)</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltHonorifics" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Email address</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltEmail" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Phone number</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltPhoneNumber" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Postcode</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltPostcode" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>State</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltState" runat="server" />
                </td>
            </tr>
        </table>
        <asp:Repeater ID="rptDirectorshipExperience" runat="server" OnItemDataBound="rptDirectorshipExperience_ItemDataBound">
            <ItemTemplate>
                <br />
                <br />
                <table width="100%" border="1">
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFF" style="padding: 8px 12px" colspan="2">
                            <font face="Arial" size="1">
                                <p style="font-weight: bold; font-size: 16pt;">
                                    Directorship Experience
                                    <asp:Literal ID="ltDEIndex" runat="server" /></p>
                        </td>
                    </tr>
                    <tr>
                        <td width="43%" align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Experience Summary</strong>
                        </td>
                        <td width="57%" style="padding: 8px 12px">
                            <asp:Literal ID="ltDEExperienceSummary" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Type of role</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltDETypeOfRole" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Position title</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltDEPositionTitle" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Organisation Name</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltDEOrganisationName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Start Date</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltDEStartDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>End Date</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltDEEndDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Additional roles and responsibilities</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltDEAdditionRoles" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Member of board committee(s)</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltDEBoardCommittee" runat="server" />
                            <%--<ul>
                                <li>Audit</li>
                                <li>Compliance</li>
                                <li>Finance</li>
                                <li>Nominations</li>
                                <li>Remuneration</li>
                                <li>Risk</li>
                                <li>Sustainability</li>
                            </ul>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Type of organisation</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltTypeOfOrganisation" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Organisation industry</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltDEOrganisationIndustry" runat="server" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptProfessionalExperience" runat="server" OnItemDataBound="rptProfessionalExperience_ItemDataBound">
            <ItemTemplate>
                <br />
                <br />
                <table width="100%" border="1">
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFF" style="padding: 8px 12px" colspan="2">
                            <font face="Arial" size="1">
                                <p style="font-weight: bold; font-size: 16pt;">
                                    Professional Experience
                                    <asp:Literal ID="ltPEIndex" runat="server" /></p>
                        </td>
                    </tr>
                    <tr>
                        <td width="43%" align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Experience Summary</strong>
                        </td>
                        <td width="57%" style="padding: 8px 12px">
                            <asp:Literal ID="ltPEExperienceSummary" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Type of role</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltPETypeOfRole" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Position title</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltPEPositionTitle" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Organisation Name</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltPEOrganisationName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Start Date</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltPEStartDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>End Date</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltPEEndDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Additional roles and responsibilities</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltPEAddicationalRoles" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Type of organisation</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltPETypeOfOrganisation" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Organisation industry</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltPEOrganisationIndustry" runat="server" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptEducationAndQualifications" runat="server" OnItemDataBound="rptEducationAndQualifications_ItemDataBound">
            <ItemTemplate>
                <br />
                <br />
                <table width="100%" border="1">
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFF" style="padding: 8px 12px" colspan="2">
                            <font face="Arial" size="1">
                                <p style="font-weight: bold; font-size: 16pt;">
                                    Education and Qualifications
                                    <asp:Literal ID="ltEQIndex" runat="server" /></p>
                        </td>
                    </tr>
                    <tr>
                        <td width="43%" align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Course name</strong>
                        </td>
                        <td width="57%" style="padding: 8px 12px">
                            <asp:Literal ID="ltEQCourseName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Institution</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltEQInstitution" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Start Date</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltEQStartDate" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>End Date</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltEQEndDate" runat="server" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <br />
        <table width="100%" border="1">
            <tr>
                <td align="left" valign="top" bgcolor="#FFF" style="padding: 8px 12px" colspan="2">
                    <font face="Arial" size="1">
                        <p style="font-weight: bold; font-size: 16pt;">
                            Association Membership</p>
                </td>
            </tr>
            <tr>
                <td style="padding: 8px 12px" bgcolor="#CCC">
                    <asp:Literal ID="ltEQAssociationMembership" runat="server" />
                </td>
            </tr>
        </table>
        <asp:Repeater ID="rptReferee" runat="server" OnItemDataBound="rptReferee_ItemDataBound">
            <ItemTemplate>
                <br />
                <br />
                <table width="100%" border="1">
                    <tr>
                        <td align="left" valign="top" bgcolor="#FFF" style="padding: 8px 12px" colspan="2">
                            <font face="Arial" size="1">
                                <p style="font-weight: bold; font-size: 16pt;">
                                    Referee Contacts -
                                    <asp:Literal ID="ltRFContactsIndex" runat="server" /></p>
                        </td>
                    </tr>
                    <tr>
                        <td width="43%" align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Name</strong>
                        </td>
                        <td width="57%" style="padding: 8px 12px">
                            <asp:Literal ID="ltRFName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Relationship to you</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltRFRelationship" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                            <strong>Contact details (phone number or email)</strong>
                        </td>
                        <td style="padding: 8px 12px">
                            <asp:Literal ID="ltRFContact" runat="server" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <br />
        <table width="100%" border="1">
            <tr>
                <td align="left" valign="top" bgcolor="#FFF" style="padding: 8px 12px" colspan="2">
                    <font face="Arial" size="1">
                        <p style="font-weight: bold; font-size: 16pt;">
                            Additional Information</p>
                </td>
            </tr>
            <tr>
                <td width="43%" align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Are you Aboriginal or Torres Strait Islander?</strong>
                </td>
                <td width="57%" style="padding: 8px 12px">
                    <asp:Literal ID="ltAboriginal" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Are you from a culturally or linguistically diverse background?</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltLinguisticallyDiverse" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Do you currently live in a rural or regional location in Australia?</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltRegional" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Do you have a disability?</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltDisability" runat="server" />
                </td>
            </tr>
            <%--<tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>For which course are you applying for a scholarship?</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltCourseApply" runat="server" />
                </td>
            </tr>--%>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Have you attended any of the following courses with the Australian Institute
                        of Company Directors?</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltCourse" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Are you currently a member of the Australian Institute of Company Directors?</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltMember" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Please rate your level of financial literacy</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltFinancialLiteracy" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Your awards, achievements, community or social involvement</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltAwards" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#CCCCCC" style="padding: 8px 12px">
                    <strong>Briefly outline why you have applied for this scholarship and how you hope to
                        benefit from attending?</strong>
                </td>
                <td style="padding: 8px 12px">
                    <asp:Literal ID="ltOutline" runat="server" />
                </td>
            </tr>
        </table>
    </font>
    </form>
</body>
</html>
