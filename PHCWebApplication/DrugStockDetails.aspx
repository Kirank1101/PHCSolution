<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DrugStockDetails.aspx.cs" Inherits="PHCWebApplication.DrugStockDetails" MasterPageFile="~/Site.Master" %>

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

    <h3>Drugs Stock Detail</h3>
    <br />

    <div id="divAddDrugsStock" runat="server">

        <asp:ValidationSummary ID="DrugsStockValidation" runat="server" CssClass="alert alert-danger" />
        <table >
            <tr>
                <td >
                    <asp:Label runat="server" CssClass="control-label" Text="Drug Name"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:DropDownList ID="ddlDrugNames" DataTextField="DrugName" DataValueField="DrugID" CssClass="form-control"
                            runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="DrugsStockSave"
                        ErrorMessage="Please Select Drug" InitialValue="Select Drugs" ControlToValidate="ddlDrugNames">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td >
                    <asp:Label runat="server" CssClass="control-label" Text="Quantity"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtQuantity" runat="server" MaxLength="4" CssClass="form-control"></asp:TextBox>

                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="DrugsStockSave"
                        ErrorMessage="Please enter Quantity" ControlToValidate="txtQuantity">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td >
                    <asp:Label runat="server" CssClass="control-label" Text="Batch Number"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtBatchNo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
            </tr>

            <tr>
                <td  style="padding-right:13px" >
                    <asp:Label runat="server" CssClass="control-label" Text="Manufacture Date"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtManufactureDate" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="DrugsStockSave"
                        ErrorMessage="Please Manufacture Date" ControlToValidate="txtManufactureDate">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td >
                    <asp:Label runat="server" CssClass="control-label" Text="Expiry Date"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="DrugsStockSave"
                        ErrorMessage="Please Expiry Date" ControlToValidate="txtExpiryDate">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td >
                    <asp:Label runat="server" CssClass="control-label" Text="Purchase Date"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtPurchaseDate" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="DrugsStockSave"
                        ErrorMessage="Please Purchase Date" ControlToValidate="txtPurchaseDate">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" ValidationGroup="DrugsStockSave" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" OnClick="btnUpdate_Click" ValidationGroup="DrugsStockSave" />

                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>

        <br />
        <br />
        <table>
            <tr>
                <td>
                    <fieldset>
                        <legend>Drugs Stock Detail</legend>

                        <asp:ListView ID="LVDrugsStockDetails" runat="server" ItemPlaceholderID="itemPlaceHolder1" DataKeyNames="DrugStockID"
                            OnItemDeleting="DeleteRecord" OnItemCommand="LVDrugsStockDetails_ItemCommand" OnPagePropertiesChanging="LVDrugsStockDetails_PagePropertiesChanging">
                            <EmptyDataTemplate>
                                There are no entries found for MDrugs
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th style="color: #428bca">Drug Name
                                            </th>
                                            <th style="color: #428bca">Quantity
                                            </th>
                                            <th style="color: #428bca">Batch Number
                                            </th>
                                            <th style="color: #428bca">Manufacture Date
                                            </th>
                                            <th style="color: #428bca">Expiry Date
                                            </th>
                                            <th style="color: #428bca">Purchase Date
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
                                        <asp:Label runat="server" ID="lblPHCID" Text='<%# Eval("PHCID") %>' Visible="false"></asp:Label>
                                        <asp:Label runat="server" ID="lblDrugStockID" Text='<%# Eval("DrugStockID") %>' Visible="false"></asp:Label>
                                        <asp:Label runat="server" ID="lblDrugID" Text='<%# Eval("DrugID") %>' Visible="false"></asp:Label>
                                        <asp:Label runat="server" ID="lblDrugName" Text='<%# Eval("DrugName") %>' ></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblQuantity" Text='<%# Eval("Quantity") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBatchNo" Text='<%# Eval("BatchNo") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblMfDate" Text='<%# Eval("MfDate") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblExpDate" Text='<%# Eval("ExpDate") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPurchaseDate" Text='<%# Eval("PurchaseDate") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkEditData" runat="server" Text="Edit" CommandName="EditData" />

                                        <span onclick="return confirm('Are you sure to delete?')">
                                            <asp:LinkButton ID="lnkDel" runat="server" Text="Delete" CommandName="Delete" />
                                        </span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>

                        <asp:DataPager ID="DPLV1" PageSize="5" runat="server" PagedControlID="LVDrugsStockDetails">
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
