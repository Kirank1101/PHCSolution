<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClearTransaction.aspx.cs" Inherits="PHCWebApplication.ClearTransaction" MasterPageFile="~/Site.Master" %>

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

    <h3>Transaction Status</h3>
    <br />

    <div id="divPHCTransactionStatus" runat="server">

        <asp:ValidationSummary ID="PHCTransactionStatusValidation" runat="server" CssClass="alert alert-danger" ValidationGroup="PHCTransactionStatusValidation" />
        <table >
            <tr>
                <td>
                    <asp:Label runat="server" Text="Pateint Name :" CssClass="control-label" />
                </td>
                <td style="width: 280px">
                    <div class="col-sm-offset-0">
                        <asp:TextBox ID="txtPatientName" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="PPSearch"
                        ErrorMessage="Patient Name required" ControlToValidate="txtPatientName" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                <td>
                    <div class="col-sm-offset-0 col-sm-10">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" ValidationGroup="PPSearch"/>
                    </div>

                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <fieldset>
                        <legend>PHC Transaction Status</legend>
                        <asp:ListView ID="LVPHCTransDetails" runat="server" ItemPlaceholderID="itemPlaceHolder1" DataKeyNames="PHCTransactionID"
                            OnItemCommand="LVPHCTransDetails_ItemCommand" 
                            OnPagePropertiesChanging="LVPHCTransDetails_PagePropertiesChanging">
                            <EmptyDataTemplate>
                                There are no entries found for PHC Transaction Details
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th style="color: #428bca; width: 100px">Sl No
                                            </th>
                                            <th style="color: #428bca; width: 300px">Name
                                            </th>
                                            <th style="color: #428bca; width: 250px">Cheque Number
                                            </th>
                                            <th style="color: #428bca; width: 200px">Debit Amount
                                            </th>
                                            <th style="color: #428bca; width: 280px; text-align:center">Issued Date
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
                                    <td>
                                        <asp:Label runat="server" ID="lblPHCTransactionID" Text='<%# Eval("PHCTransactionID") %>' Visible="false"></asp:Label>
                                        <%# Eval("SlNo") %>
                                    </td>
                                    <td>
                                        <%# Eval("Name") %>
                                    </td>
                                    <td>
                                        <%# Eval("TransactionDetails") %>
                                    </td>
                                    <td>
                                        <%# Eval("DebitedAmount") %>
                                    </td>
                                    <td>
                                        <%# Eval("TransactionDate") %>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkClearChequeu" runat="server" Text="Completed" CommandName="TransactionCompleted" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>

                        <asp:DataPager ID="DPLV1" PageSize="5" runat="server" PagedControlID="LVPHCTransDetails">
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
