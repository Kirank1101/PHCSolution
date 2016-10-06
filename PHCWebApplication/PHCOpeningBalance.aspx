<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PHCOpeningBalance.aspx.cs" Inherits="PHCWebApplication.PHCOpeningBalance" MasterPageFile="~/Site.Master"%>

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

    <h3>PHC Opening Balance</h3>
    <br />

    <div id="divPHCOpeningBalance" runat="server">

        <asp:ValidationSummary ID="PHCOBValidation" runat="server" CssClass="alert alert-danger" ValidationGroup="PHCOBValidation"/>
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" CssClass="control-label" Text="PHC Opening Balance Amount "></asp:Label></td>
                <td>
                    <div style="width: 250px">
                        <asp:TextBox ID="txtPHCOBName" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Please enter PHC opening balance Amount" ControlToValidate="txtPHCOBName" ValidationGroup="PHCOBValidation" ForeColor="Red">*</asp:RequiredFieldValidator></td>
                <td style="width: 136px">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click"  ValidationGroup="PHCOBValidation"/>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
