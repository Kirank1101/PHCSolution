<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPHC.aspx.cs" Inherits="WebApplication5.AddPHC" MasterPageFile="~/Site.Master" %>

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

    <h3>Add PHC</h3>
    <br />

    <div id="divAddPHC" runat="server">

        <asp:ValidationSummary ID="PHCValidation" runat="server" CssClass="alert alert-danger" ValidationGroup="PHCSave" />
        <table>
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="District Name"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:DropDownList ID="ddlDistrictNames" DataTextField="DistrictName" DataValueField="DistrictID" CssClass="form-control"
                            runat="server" OnSelectedIndexChanged="ddlDistrictNames_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>

                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="PHCSave"
                        ErrorMessage="District required" InitialValue="Select District" ControlToValidate="ddlDistrictNames" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="Taluk Name"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:DropDownList ID="ddlTalukNames" DataTextField="TalukName" DataValueField="TalukID" CssClass="form-control"
                            runat="server">
                        </asp:DropDownList>

                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="PHCSave"
                        ErrorMessage="Taluk required" InitialValue="Select Taluk" ControlToValidate="ddlTalukNames" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 103px">
                    <asp:Label runat="server" CssClass="control-label" Text="PHC Name"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtPHCName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="PHCSave"
                        ErrorMessage="PHC Name required" ControlToValidate="txtPHCName" ForeColor="Red">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" ValidationGroup="PHCSave" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" OnClick="btnUpdate_Click" ValidationGroup="PHCSave" />

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
                        <legend>PHC Details</legend>

                        <asp:ListView ID="LVPHCDetails" runat="server" ItemPlaceholderID="itemPlaceHolder1" DataKeyNames="PHCID"
                            OnItemDeleting="DeleteRecord" OnItemCommand="LVPHCDetails_ItemCommand"
                            OnPagePropertiesChanging="LVPHCDetails_PagePropertiesChanging">
                            <EmptyDataTemplate>
                                There are no entries found for PHC Add
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th style="color: #428bca">District Name
                                            </th>
                                            <th style="color: #428bca">Taluk Name
                                            </th>
                                            <th style="color: #428bca">PHC Name
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
                                        <asp:Label runat="server" ID="lblDistrictID" Text='<%# Eval("DistrictID") %>' Visible="false"></asp:Label>
                                        <asp:Label runat="server" ID="lblTalukID" Text='<%# Eval("TalukID") %>' Visible="false"></asp:Label>
                                        <%# Eval("DistrictName") %>
                                    </td>
                                    <td>
                                        <%# Eval("TalukName") %>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPHCName" Text='<%# Eval("PHCName") %>'></asp:Label>
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

                        <asp:DataPager ID="DPLV1" PageSize="5" runat="server" PagedControlID="LVPHCDetails">
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
