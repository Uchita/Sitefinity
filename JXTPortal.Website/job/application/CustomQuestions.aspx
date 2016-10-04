<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="CustomQuestions.aspx.cs" Inherits="JXTPortal.Website.CustomQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Alike|Open+Sans:400italic,700italic,400,700'
        rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css">
    <link rel="stylesheet" href="/styles/lib/bootstrap.min.css">
    <link rel="stylesheet" href="/styles/style.css" />
    <link rel="stylesheet" href="/styles/custom-application.css" />
    <!--[if lt IE 9]>
	<script src="js/lib/html5shiv.js" type="text/javascript"></script>
	<script src="js/lib/respond.min.js" type="text/javascript"></script>
<![endif]-->
    <script src='/scripts/lib/bootstrap.min.js'></script>
    <script src='/scripts/lib/bootstrap-maxlength.min.js'></script>
    <script src='/scripts/lib/jquery-sortable-min.js'></script>
    <script src='/scripts/custom-questions.js'></script>
    <script type="text/javascript">
        var index = 1;

        function AddCustomQuestion() {
            $('#divQuestions').css("display", "");
            var type = $('input[name=blnCustomQuestionType]:checked').val();
            var question = $('#txtCustomQuestionLabel').val();
            $('#tblQuestions tbody').append("<tr id=\"rowquestion" + index +"\">"+
                                            "    <td>" + index + "</td>" +
                                            "    <td id=\"lbquestion" + index + "\">" + question +
                                            "    </td>"+
                                            "    <td id=\"lbtype" + index + "\">" + type + "</td>" +
                                            "    <td class=\"text-right\">"+
                                            "        <button type=\"submit\" class=\"btn btn-success btn-xs\" onclick=\"EditCustomQuestion(" + index + ");\">" +
                                            "            <i class=\"fa fa-pencil\">"+
                                            "                <!--ICON-->"+
                                            "            </i>Edit</button>"+
                                            "        <button type=\"submit\" class=\"btn btn-danger btn-xs\" onclick=\"DeleteCustomQuestion(" + index + ");\">" +
                                            "            <i class=\"fa fa-times\">"+
                                            "                <!--ICON-->"+
                                            "            </i>Delete</button>"+
                                            "    </td>"+
                                            "</tr>");

            $('#txtCustomQuestionLabel').val('');
            $('input[name="blnCustomQuestionType"]:first').prop("checked", true);

            index++;                                                
            event.preventDefault();
        }

        function EditCustomQuestion(index) {
            var question = $('#lbquestion' + index).html();
            var type = $('#lbtype' + index).html();

            $('#txtCustomQuestionLabel').val(question);
            $('input[name="blnCustomQuestionType"][value="'+ type +'"]').prop("checked", true);

            event.preventDefault();
        }

        function DeleteCustomQuestion(index) {
            $("#rowquestion" + index).remove();
            

            event.preventDefault();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="customApplicationContainer" class="container">
        <div id="customApplicationContent" class="row">
            <div id="customApplicationHolder" class="col-md-12">
                <div id="customQuestions">
                    <h3>
                        Custom Questions</h3>
                    <hr />
                    <div class="form-group">
                        <label class="control-label" for="txtCustomQuestionLabel">
                            Question (Max 200 words)</label>
                        <textarea id="txtCustomQuestionLabel" cols="5" rows="3" maxlength="200"></textarea>
                    </div>
                    <hr>
                    <div class="form-group">
                        <label class="control-label" for="blnCustomQuestionType">
                            Type of Question</label>
                        <div class="radio">
                            <label>
                                <input type="radio" name="blnCustomQuestionType" id="blnCustomQuestionType1" value="Free Text Area"
                                    checked>
                                Free Text Area (Max 200 words)
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="blnCustomQuestionType" id="blnCustomQuestionType2" value="Yes / No">
                                Yes / No
                            </label>
                        </div>
                    </div>
                    <br>
                    <button id="addCustomQuestion" class="btn btn-default add-another" onclick="AddCustomQuestion();">
                        <i class="fa fa-plus">
                            <!--ICON-->
                        </i>Add another question</button>
                    <hr>
                    <br>
                    <div id="listCustomQuestion" class="custom-question-list">
                        <div class="table-responsive" id="divQuestions" runat="server" style="display: none;" clientidmode="Static">
                            <table class="table table-striped sorted_table" id="tblQuestions">
                                <thead>
                                    <tr>
                                        <th class="col-sm-1">
                                            #
                                        </th>
                                        <th class="col-sm-7">
                                            Question
                                        </th>
                                        <th class="col-sm-2">
                                            Type of Question
                                        </th>
                                        <th class="col-sm-2 text-right">
                                            Actions
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptQuestions" runat="server">
                                        <ItemTemplate>
                                            
                                        </ItemTemplate>
                                    <%--<tr>
                                        <td>
                                            1
                                        </td>
                                        <td>
                                            Do you agree to the Australian Institute of Company Directors contacting you regarding
                                            our business and services. You will be provided with the opportunity to decline
                                            any further contact in this respect at any time.
                                        </td>
                                        <td>
                                            Yes / No
                                        </td>
                                        <td class="text-right">
                                            <button type="submit" class="btn btn-success btn-xs">
                                                <i class="fa fa-pencil">
                                                    <!--ICON-->
                                                </i>Edit</button>
                                            <button type="submit" class="btn btn-danger btn-xs">
                                                <i class="fa fa-times">
                                                    <!--ICON-->
                                                </i>Delete</button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            2
                                        </td>
                                        <td>
                                            Briefly outline why you have applied for this scholarship and how you hope to benefit
                                            from attending the program (which may include your career and board aspirations
                                            and the financial necessity of a scholarship)?
                                        </td>
                                        <td>
                                            Free Text Area
                                        </td>
                                        <td class="text-right">
                                            <button type="submit" class="btn btn-success btn-xs">
                                                <i class="fa fa-pencil">
                                                    <!--ICON-->
                                                </i>Edit</button>
                                            <button type="submit" class="btn btn-danger btn-xs">
                                                <i class="fa fa-times">
                                                    <!--ICON-->
                                                </i>Delete</button>
                                        </td>
                                    </tr>--%>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <!-- listCustomQuestion -->
                </div>
                <!-- customQuestions -->
            </div>
        </div>
    </div>
</asp:Content>
