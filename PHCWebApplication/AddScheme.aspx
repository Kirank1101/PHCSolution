<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddScheme.aspx.cs" Inherits="PHCWebApplication.AddScheme" MasterPageFile="~/Site.Master" %>

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

    <h3>Add Scheme Account</h3>
    <br />
    <div id="divAddScheme" runat="server">

        <asp:ValidationSummary ID="SchemeValidation" runat="server" CssClass="alert alert-danger" ValidationGroup="SchemeSave"/>
        <table>
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="Scheme Name"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtSchemeName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="SchemeSave"
                        ErrorMessage="Scheme is required" ControlToValidate="txtSchemeName" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                <td style="width: 136px">
                    <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" ValidationGroup="SchemeSave" />
                </td>
            </tr>
        </table>

        <br />
        <br />
        <table>
            <tr>
                <td>
                    <fieldset>
                        <legend>Scheme Account Details</legend>

                        <asp:ListView ID="ListView1" runat="server" ItemPlaceholderID="itemPlaceHolder1"
                            OnItemEditing="EditRecord" OnItemCanceling="CancelEditRecord" DataKeyNames="SchemeID"
                            OnItemUpdating="UpdateRecord"
                            OnItemDeleting="DeleteRecord" OnPagePropertiesChanging="ListView1_PagePropertiesChanging">
                            <EmptyDataTemplate>
                                There are no entries found for Scheme
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th style="color: #428bca" >
                                                <asp:LinkButton Text="Scheme Name" CommandName="Sort" CommandArgument="SchemeName" runat="Server" />
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
                                        <%# Eval("SchemeName") %>
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
                                        <asp:TextBox ID="txteSchemeName" runat="server" Text='<%# Eval("SchemeName") %>' CssClass="form-control" />
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