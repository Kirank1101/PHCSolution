<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEducation.aspx.cs" Inherits="PHCWebApplication.AddEducation"  MasterPageFile="~/Site.Master" %>

<%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

    <script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "form-control ErrorControl";
                        } else {
                            control.className = "form-control";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
    <style type="text/css">
        .ErrorControl {
            border-color: #b94a48;
        }
    </style>

    <asp:Panel ID="pnlstatus" runat="server">
        <asp:Label ID="lblstatus" runat="server"></asp:Label>
    </asp:Panel>
    <br />

    <h3>Add Education</h3>
    <br />
    <div id="divAddEducation" runat="server">

        <asp:ValidationSummary ID="EducationValidation" runat="server" CssClass="alert alert-danger" ValidationGroup="EducationSave"/>
        <table>
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="Education Name"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtEducationName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="EducationSave"
                        ErrorMessage="Education is required" ControlToValidate="txtEducationName" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                <td style="width: 136px">
                    <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" ValidationGroup="EducationSave" />
                </td>
            </tr>
        </table>

        <br />
        <br />
        <table>
            <tr>
                <td>
                    <fieldset>
                        <legend>Education Details</legend>

                        <asp:ListView ID="ListView1" runat="server" ItemPlaceholderID="itemPlaceHolder1"
                            OnItemEditing="EditRecord" OnItemCanceling="CancelEditRecord" DataKeyNames="EducationID"
                            OnItemUpdating="UpdateRecord"
                            OnItemDeleting="DeleteRecord" OnPagePropertiesChanging="ListView1_PagePropertiesChanging">
                            <EmptyDataTemplate>
                                There are no entries found for Education
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th style="color: #428bca" >
                                                <asp:LinkButton Text="Education Name" CommandName="Sort" CommandArgument="EducationName" runat="Server" />
                                            </th>
                                            <th style="color: #428bca">Action
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceHolder1" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td >
                                        <%# Eval("EducationName") %>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="Edit" />

                                        <span onclick="return confirm('Are you sure to delete?')">
                                            <asp:LinkButton ID="lnkDel" runat="server" Text="Delete" CommandName="Delete" />
                                        </span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <tr style="background-color: #efefef;">
                                    <td>
                                        <asp:TextBox ID="txteEducationName" runat="server" Text='<%# Eval("EducationName") %>' CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" ValidationGroup="Add2" />
                                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                    </td>
                                </tr>
                            </EditItemTemplate>
                        </asp:ListView>

                        <asp:DataPager ID="DPLV1" PageSize="5" runat="server" PagedControlID="ListView1">
                            <Fields>
                                <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                                <asp:NumericPagerField ButtonType="Button" NumericButtonCssClass="btn" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                                <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                            </Fields>
                        </asp:DataPager>
                    </fieldset>
                    <br />
                    <br />
                </td>

            </tr>
        </table>
    </div>
</asp:Content>