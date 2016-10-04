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
    </style>

    <asp:Panel ID="pnlstatus" runat="server">
        <asp:Label ID="lblstatus" runat="server"></asp:Label>
    </asp:Panel>

    <h4>Patient Prescription</h4>
    <div id="divpatientsearch" runat="server">
        <asp:ValidationSummary ID="DiseaseValidation" runat="server" CssClass="alert alert-danger" ValidationGroup="PPSave" />
    </div>
    <table style="width: 100%">
        <tr>
            <td style="width: 50%">
                <div class="form-group">
                    <table style="width: 100%">
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="PPSave"
                                    ErrorMessage="Patient Name required" ControlToValidate="txtPatientName" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                            <td>
                                <div class="col-sm-offset-0 col-sm-10">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" />
                                </div>

                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
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
                                                <asp:Label ID="lblplac" runat="server" Text="Place:" CssClass="control-label"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="form-group">
                                                <asp:Label ID="lblVillage" runat="server" CssClass="control-label"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
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
                </div>
            </td>
            <td style="width: 50%">

                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Disease" CssClass="control-label" />
                        </td>

                        <td>
                            <div class="col-sm-offset-0">
                                <asp:DropDownList ID="ddlDisease" runat="server" CssClass="form-control"
                                    DataTextField="DiseaseName" DataValueField="DiseaseID">
                                </asp:DropDownList>

                            </div>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="PPSave"
                                ErrorMessage="Disease Name required" InitialValue="Select Disease" ControlToValidate="ddlDisease" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Description" CssClass="control-label" />
                        </td>

                        <td style="width: 400px">
                            <div class="col-sm-offset-0">
                                <asp:TextBox ID="txtdescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </td>
                        <td></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 50%; vertical-align: top">
                <h4>Add Drugs</h4>
                <table style="width: 100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" CssClass="control-label" Text="Drug Name"></asp:Label></td>
                                    <td>
                                        <div class="col-sm-offset-0">
                                            <asp:DropDownList ID="ddlDrugNames" DataTextField="DrugName" DataValueField="DrugID" CssClass="form-control"
                                                runat="server">
                                            </asp:DropDownList>

                                        </div>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="DrugAdd"
                                            ErrorMessage="Drug required" InitialValue="Select Drug" ControlToValidate="ddlDrugNames" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" CssClass="control-label" Text="Quantity"></asp:Label></td>
                                    <td>
                                        <div class="col-sm-offset-0">
                                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="DrugAdd"
                                            ErrorMessage="Quantity required" ControlToValidate="txtQuantity" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" CssClass="control-label" Text="Dosage"></asp:Label></td>
                                    <td>
                                        <div class="col-sm-offset-0">
                                            <asp:TextBox ID="txtDosage" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="DrugAdd"
                                            ErrorMessage="Dosage required" ControlToValidate="txtDosage" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Button ID="btnSave" runat="server" Text="Add" CssClass="btn btn-default" OnClick="btnSaveDrug_Click" ValidationGroup="DrugAdd" />
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" OnClick="btnUpdateDrug_Click" ValidationGroup="DrugAdd" />

                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="btnCancelDrug_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ListView ID="LVDrugs" runat="server" ItemPlaceholderID="itemPlaceHolder1" DataKeyNames="DrugIssueID"
                                OnItemDeleting="DeleteRecord" OnItemCommand="LVDrugs_ItemCommand">
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
                                            <asp:LinkButton ID="lnkEditData" runat="server" Text="Edit" CommandName="EditData" />|
                                            <span onclick="return confirm('Are you sure to delete?')">
                                                <asp:LinkButton ID="lnkDel" runat="server" Text="Delete" CommandName="Delete" />
                                            </span>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 50%; vertical-align: top">
                <h4>Add LabTest</h4>

                <div id="divAddLabTest" runat="server">

                    <table>
                        <tr>
                            <td>
                                <asp:Label runat="server" CssClass="control-label" Text="LabTest Name"></asp:Label></td>
                            <td>
                                <div class="col-sm-offset-0">
                                    <asp:DropDownList ID="ddlLabTestNames" DataTextField="LabTestName" DataValueField="LabTestID" CssClass="form-control"
                                        runat="server">
                                    </asp:DropDownList>

                                </div>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="LabTestSave"
                                    ErrorMessage="LabTest required" InitialValue="Select LabTest" ControlToValidate="ddlLabTestNames" ForeColor="Red">*</asp:RequiredFieldValidator></td>

                            <td>
                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-default" OnClick="btnSave_Click" ValidationGroup="LabTestSave" />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:ListView ID="LVLabTest" runat="server" ItemPlaceholderID="itemPlaceHolder1" OnItemDataBound="OnItemDataBound"
                                    OnItemEditing="EditRecord" OnItemCanceling="CancelEditRecord" DataKeyNames="LabTestID"
                                    OnItemUpdating="UpdateRecord"
                                    OnItemDeleting="DeleteLabTest">
                                    <EmptyDataTemplate>
                                        There are no entries found for MDrugs
                                    </EmptyDataTemplate>
                                    <LayoutTemplate>
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th style="color: #428bca">
                                                        <asp:LinkButton Text="LabTest Name" CommandName="Sort" CommandArgument="LabTestName" runat="Server" />
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
                                                <%# Eval("LabTestName") %>
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
                                                <asp:DropDownList ID="ddlLabTest" runat="server" DataTextField="LabTestName" DataValueField="LabTestID" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblLabTestName" runat="server" Text='<%# Eval("LabTestName") %>' Visible="false"></asp:Label>

                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" CommandName="Update" ValidationGroup="Add2" />
                                                <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                            </td>
                                        </tr>
                                    </EditItemTemplate>
                                </asp:ListView>
                                <br />
                                <br />
                            </td>

                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 100%">
        <tr>
            <td>
                <div align="center">
                    <asp:Button ID="btnsaveclose" runat="server" Text="Save and Close" CssClass="btn btn-default" OnClick="btnSaveClose_Click" ValidationGroup="PPSave" />
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
