<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCaste.aspx.cs" Inherits="PHCWebApplication.AddCaste" MasterPageFile="~/Site.Master" %>

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

    <h3>Add Caste</h3>
    <br />
</asp:Content>