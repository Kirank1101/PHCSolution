<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPatientDetails.aspx.cs" Inherits="WebApplication5.AddPatientDetails" MasterPageFile="~/Site.Master" %>

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

    <h3>Add Patient Detail</h3>
    <br />

    <div id="divAddPatientDetail" runat="server">

        <asp:ValidationSummary ID="PatientDetailValidation" runat="server" CssClass="alert alert-danger" ValidationGroup="PatientDetailSave"    />
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Patient Name"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtPatientName" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="PatientDetailSave"
                        ErrorMessage="Please enter Patient Name" ControlToValidate="txtPatientName">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="E.C. Number"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtECNo" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>

                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Age"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtAge" runat="server" MaxLength="3" CssClass="form-control"></asp:TextBox>

                    </div>
                </td>
            </tr>

            <tr>
                <td style="padding-right: 13px">
                    <asp:Label runat="server" CssClass="control-label" Text="DOB"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control"></asp:TextBox>

                        <ajax:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDOB" runat="server" Format="dd-MMM-yyyy" />

                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="PatientDetailSave"
                        ErrorMessage="Please Manufacture Date" ControlToValidate="txtDOB">*</asp:RequiredFieldValidator></td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Gender"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:RadioButton ID="rbMale" Text="Male" runat="server" GroupName="Gender" />
                        <asp:RadioButton ID="rbFemale" Text="Female" runat="server" GroupName="Gender" />
                    </div>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="BloodGroup"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:DropDownList ID="ddlBloodGroup" DataTextField="BloodGroupName" DataValueField="BloodGroupID" CssClass="form-control"
                            runat="server">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="PatientDetailSave"
                        ErrorMessage="Please Select BloodGroup" InitialValue="Select BloodGroup" ControlToValidate="ddlBloodGroup">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Place"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:DropDownList ID="ddlVillages" DataTextField="VillageName" DataValueField="VillageID" CssClass="form-control"
                            runat="server">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RFV" runat="server" ValidationGroup="PatientDetailSave"
                        ErrorMessage="Please Select Village" InitialValue="Select Village" ControlToValidate="ddlVillages">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Address"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtAddress" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>

                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Contact No"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtContactNo" runat="server" MaxLength="13" CssClass="form-control"></asp:TextBox>

                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="Ref Phone No"></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtPhoneNo" runat="server" MaxLength="13" CssClass="form-control"></asp:TextBox>

                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" ValidationGroup="PatientDetailSave" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-default" OnClick="btnUpdate_Click" ValidationGroup="PatientDetailSave" />

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
                        <legend>Patient Detail</legend>

                        <asp:ListView ID="LVPatientDetailDetails" runat="server" ItemPlaceholderID="itemPlaceHolder1" DataKeyNames="PatientID"
                            OnItemDeleting="DeleteRecord" OnItemCommand="LVPatientDetailDetails_ItemCommand" OnPagePropertiesChanging="LVPatientDetailDetails_PagePropertiesChanging">
                            <EmptyDataTemplate>
                                There are no entries found for MDrugs
                            </EmptyDataTemplate>
                            <LayoutTemplate>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th style="color: #428bca">Patient Name
                                            </th>
                                            <th style="color: #428bca">E.C. Number
                                            </th>
                                            <th style="color: #428bca">BloodGroup
                                            </th>
                                            <th style="color: #428bca">Gender
                                            </th>
                                            <th style="color: #428bca">Age
                                            </th>
                                            <th style="color: #428bca">DOB
                                            </th>
                                            <th style="color: #428bca">Place
                                            </th>
                                            <th style="color: #428bca">Address
                                            </th>
                                            <th style="color: #428bca">Contact No
                                            </th>
                                            <th style="color: #428bca">Alt Contact No
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
                                        <asp:Label runat="server" ID="lblPatientID" Text='<%# Eval("PatientID") %>' Visible="false"></asp:Label>
                                        <asp:Label runat="server" ID="lblVillageID" Text='<%# Eval("VillageID") %>' Visible="false"></asp:Label>
                                        <asp:Label runat="server" ID="lblPatientName" Text='<%# Eval("PatientName") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblECNumber" Text='<%# Eval("ECNumber") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBloodGroup" Text='<%# Eval("BloodGroup") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblGender" Text='<%# Eval("Gender") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblAge" Text='<%# Eval("Age") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblDOB" Text='<%# Eval("DOB", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPlace" Text='<%# Eval("Place") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblAddress" Text='<%# Eval("Address") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblContactNo" Text='<%# Eval("ContactNo") %>'></asp:Label>
                                    </td>
                                    
                                    <td>
                                        <asp:Label runat="server" ID="lblRefPhoneNo" Text='<%# Eval("RefPhoneNo") %>'></asp:Label>
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

                        <asp:DataPager ID="DPLV1" PageSize="10" runat="server" PagedControlID="LVPatientDetailDetails">
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
