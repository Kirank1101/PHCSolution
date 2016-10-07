<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PHCTransaction.aspx.cs" Inherits="PHCWebApplication.PHCTransaction" MasterPageFile="~/Site.Master" %>

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

    <h3>PHC Transaction&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;             
        <asp:Label ID="lblbalmount" runat="server" Text="BalanceAmount= "></asp:Label><asp:Label ID="lblbalanceamount" runat="server" ForeColor="#3a8f35"></asp:Label></h3>
    <br />

    <div id="divPHCTransaction" runat="server">

        <asp:ValidationSummary ID="PHCTransactionValidation" runat="server" CssClass="alert alert-danger" ValidationGroup="PHCTransactionValidation" />
        <table>

            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Transaction Type"></asp:Label></td>
                <td style="vertical-align: bottom">
                    <div>
                        <asp:RadioButtonList ID="rblTransaction" RepeatColumns="2"
                            RepeatDirection="Horizontal" RepeatLayout="Table" runat="server"
                            ValidationGroup="PHCTransactionValidation" AutoPostBack="true" OnSelectedIndexChanged="rblTransaction_SelectedIndexChanged">
                            <asp:ListItem>Debit</asp:ListItem>
                            <asp:ListItem>Credit</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2"
                        ControlToValidate="rblTransaction" ErrorMessage="Please select Transaction type."
                        ValidationGroup="PHCTransactionValidation" ForeColor="Red">*
                    </asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblReceivedorGiven" runat="server" CssClass="control-label" Text="From"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtReceivedorGiven" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFVReceivedOrGiven" runat="server"
                        ControlToValidate="txtReceivedorGiven"
                        ValidationGroup="PHCTransactionValidation" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Cheque No"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtChequeNo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="Please enter Cheque Number" ControlToValidate="txtChequeNo"
                        ValidationGroup="PHCTransactionValidation" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Amount"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Please enter Amount" ControlToValidate="txtAmount"
                        ValidationGroup="PHCTransactionValidation" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Description"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="width: 136px">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" ValidationGroup="PHCTransactionValidation" />
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <fieldset>
                        <legend>PHC Transaction Details</legend>
                        <asp:ListView ID="LVPHCTransDetails" runat="server" ItemPlaceholderID="itemPlaceHolder1" DataKeyNames="PHCTransactionID"
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
                                            <th style="color: #428bca; width: 350px">Transaction Details
                                            </th>
                                            <th style="color: #428bca; width: 200px">Debit Amount
                                            </th>
                                            <th style="color: #428bca; width: 200px">Credit Amount
                                            </th>

                                            <th style="color: #428bca; width: 250px">Transaction Date
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
                                        <%# Eval("TransactionDetails") %>
                                    </td>
                                    <td>
                                        <%# Eval("DebitedAmount") %>
                                    </td>
                                    <td>
                                        <%# Eval("CreditedAmount") %>
                                    </td>
                                    <td>
                                        <%# Eval("TransactionDate") %>
                                    </td>
                                    <%--<td>
                                        <asp:LinkButton ID="lnkEditData" runat="server" Text="Edit" CommandName="EditData" />

                                        <span onclick="return confirm('Are you sure to delete?')">
                                            <asp:LinkButton ID="lnkDel" runat="server" Text="Delete" CommandName="Delete" />
                                        </span>
                                    </td>--%>
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
