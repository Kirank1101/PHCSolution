<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDrugs.aspx.cs" Inherits="WebApplication5.AddDrugs" MasterPageFile="~/Site.Master" %>

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
                            control.className = "";
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

    <h3>Add Drugs</h3>
    <br />

    <div id="divAddDrugs" runat="server">

        <asp:ValidationSummary ID="DrugValidation" runat="server" CssClass="alert alert-danger" />
        <table>
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="Drug Name"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtDrugName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="DrugName required" ControlToValidate="txtDrugName">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="Quantity"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtquantity" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="quantity required" ControlToValidate="txtquantity">*</asp:RequiredFieldValidator></td>
            </tr>
                
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="Batch No"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtBatchNo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="txtBatchNo required" ControlToValidate="txtBatchNo">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="Mfd"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtMfd" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ErrorMessage="Manufacture Date required" ControlToValidate="txtMfd">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="Expdt"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtExpdt" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                        ErrorMessage="Expire Date required" ControlToValidate="txtExpdt">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="Purchase Date"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtPurchasedate" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                        ErrorMessage="txtPurchase Date required" ControlToValidate="txtPurchasedate">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 136px">
                    <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>

        <br />
        <br />
        <table>
            <tr>
                <td>
                    <fieldset>
                        <legend>Drug Details</legend>

                        <asp:ListView ID="ListView1" runat="server" ItemPlaceholderID="itemPlaceHolder1"
                            OnItemEditing="EditRecord" OnItemCanceling="CancelEditRecord" DataKeyNames="DrugID"
                            OnItemUpdating="UpdateRecord"
                            OnItemDeleting="DeleteRecord" OnPagePropertiesChanging="ListView1_PagePropertiesChanging">
                            <EmptyDataTemplate>
                                There are no entries found for MDrugs
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th style="color: #428bca">
                                                <asp:LinkButton Text="Drug Name" CommandName="Sort" CommandArgument="DrugName" runat="Server" />
                                            </th>
                                            <th style="color: #428bca">
                                                <asp:LinkButton Text="Quantity" CommandName="Sort" CommandArgument="Quantity" runat="Server" />
                                            </th>
                                            <th style="color: #428bca">
                                                <asp:LinkButton Text="BatchNo" CommandName="Sort" CommandArgument="BatchNo" runat="Server" />
                                            </th>
                                            <th style="color: #428bca">
                                                <asp:LinkButton Text="Mfdt" CommandName="Sort" CommandArgument="Mfdt" runat="Server" />
                                            </th>
                                            <th style="color: #428bca">
                                                <asp:LinkButton Text="Expdt" CommandName="Sort" CommandArgument="Expdt" runat="Server" />
                                            </th>
                                            <th style="color: #428bca">
                                                <asp:LinkButton Text="Purchase dt" CommandName="Sort" CommandArgument="Purchasedt" runat="Server" />
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
                                        <%# Eval("DrugName") %>
                                    </td>
                                    
                                    <td>
                                        <%# Eval("Quantity") %>
                                    </td>
                                    <td>
                                        <%# Eval("BatchNo") %>
                                    </td>
                                    <td>
                                        <%# Eval("MfDate") %>
                                    </td>
                                    <td>
                                        <%# Eval("ExpDate") %>
                                    </td>
                                    <td>
                                        <%# Eval("PurchaseDate") %>
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
                                        <asp:TextBox ID="txteDrugName" runat="server" Text='<%# Eval("DrugName") %>' CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txteQuantity" runat="server" Text='<%# Eval("Quantity") %>' CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txteBatchNo" runat="server" Text='<%# Eval("BatchNo") %>' CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txteMfDate" runat="server" Text='<%# Eval("MfDate") %>' CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txteExpDate" runat="server" Text='<%# Eval("ExpDate") %>' CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtePurchaseDate" runat="server" Text='<%# Eval("PurchaseDate") %>' CssClass="form-control" />
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
