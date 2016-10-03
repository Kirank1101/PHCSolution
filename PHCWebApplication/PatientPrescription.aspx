<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientPrescription.aspx.cs" Inherits="PHCWebApplication.PatientPrescription" MasterPageFile="~/Site.Master" %>

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

        .auto-style1 {
            height: 37px;
        }
    </style>

    <asp:Panel ID="pnlstatus" runat="server">
        <asp:Label ID="lblstatus" runat="server"></asp:Label>
    </asp:Panel>
    <br />

    <h3>Patient Prescription</h3>
    <br />
    <div id="divpatientsearch" runat="server">
        <table>
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
                    <div class="col-sm-offset-0 col-sm-10">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" />
                    </div>

                </td>
            </tr>
        </table>
    </div>
    <table>
        <tr>
            <td>
                <div class="form-group">
                    <table>

                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="form-group">
                                                <asp:Label ID="lblECNO" runat="server" Text="ECNumber:" CssClass="control-label"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <asp:Label ID="lblECNumber" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                        </td>

                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td class="auto-style1">
                                            <div class="form-group">
                                                <asp:Label ID="lblplac" runat="server" Text="Place:" CssClass="control-label"></asp:Label>
                                            </div>
                                        </td>
                                        <td class="auto-style1">
                                            <div class="form-group">
                                                <asp:Label ID="lblVillage" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                        </td>

                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="form-group">
                                                <asp:Label ID="Label1" runat="server" Text="Age:" CssClass="control-label">
                                                </asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <asp:Label ID="lblage" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="form-group">
                                                <asp:Label ID="Label2" runat="server" Text="Blood Group:" CssClass="control-label"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <asp:Label ID="lblbloodgroup" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                        </td>

                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Disease" CssClass="col-sm-2 control-label" />
                                </div>
                            </td>

                            <td>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlDisease" runat="server" CssClass="form-control"
                                        DataTextField="DiseaseName" DataValueField="DiseaseID">
                                        <asp:ListItem Text="Select An Option" Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="Description" CssClass="col-sm-2 control-label" />
                                </div>
                            </td>

                            <td style="width: 400px">
                                <div class="form-group">
                                    <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>

        <tr>
            <td>
                <h3>Drugs Details</h3>
                <br />

                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 103px">
                                        <asp:Label runat="server" CssClass="control-label" Text="Drug Name"></asp:Label></td>
                                    <td>
                                        <div style="width: 250px">
                                            <asp:DropDownList ID="ddlDrugNames" DataTextField="DrugName" DataValueField="DrugID" CssClass="form-control"
                                                runat="server">
                                            </asp:DropDownList>

                                        </div>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="PHCSave"
                                            ErrorMessage="Drug required" InitialValue="Select Drug" ControlToValidate="ddlDrugNames" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 103px">
                                        <asp:Label runat="server" CssClass="control-label" Text="Quantity"></asp:Label></td>
                                    <td>
                                        <div style="width: 250px">
                                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="PHCSave"
                                            ErrorMessage="Quantity required" ControlToValidate="txtQuantity" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td style="width: 103px">
                                        <asp:Label runat="server" CssClass="control-label" Text="Dosage"></asp:Label></td>
                                    <td>
                                        <div style="width: 250px">
                                            <asp:TextBox ID="txtDosage" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="PHCSave"
                                            ErrorMessage="Dosage required" ControlToValidate="txtDosage" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSaveDrug_Click" ValidationGroup="PHCSave" />
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" OnClick="btnUpdateDrug_Click" ValidationGroup="PHCSave" />

                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="btnCancelDrug_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListView ID="LVDrugs" runat="server" ItemPlaceholderID="itemPlaceHolder1" DataKeyNames="DrugIssueID"
                                OnItemDeleting="DeleteRecord" OnItemCommand="LVDrugs_ItemCommand"
                                OnPagePropertiesChanging="LVPHCDetails_PagePropertiesChanging">
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
                                                <th style="color: #428bca">Dosage
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

                                            <asp:Label runat="server" ID="lblDrugIssueID" Text='<%# Eval("DrugIssueID") %>' Visible="false"></asp:Label>
                                            <asp:Label runat="server" ID="lblDrugID" Text='<%# Eval("DrugID") %>' Visible="false"></asp:Label>
                                            <%# Eval("DrugName") %>
                                        </td>
                                        <td>
                                            <%# Eval("Quantity") %>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblDosage" Text='<%# Eval("Dosage") %>'></asp:Label>
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

                            <asp:DataPager ID="DPLV1" PageSize="5" runat="server" PagedControlID="LVDrugs">
                                <Fields>
                                    <asp:NextPreviousPagerField ShowLastPageButton="False" ShowNextPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                                    <asp:NumericPagerField ButtonType="Button" NumericButtonCssClass="btn" CurrentPageLabelCssClass="btn disabled" NextPreviousButtonCssClass="btn" />
                                    <asp:NextPreviousPagerField ShowFirstPageButton="False" ShowPreviousPageButton="False" ButtonType="Button" ButtonCssClass="btn" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset>
                                <legend>LabTest Details</legend>

                            </fieldset>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

    </table>

</asp:Content>
