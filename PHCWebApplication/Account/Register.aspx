<%@ Page Title="Register" Language="C#" MasterPageFile="~/Account/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PHCWebApplication.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <div class="form-group">
            <asp:Label AssociatedControlID="txtDisplayName" runat="server" CssClass="col-md-2 control-label" Text="Display Name"></asp:Label><div class="col-md-10">

                <asp:TextBox ID="txtDisplayName" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ErrorMessage="DisplayName is required" ControlToValidate="txtDisplayName">*</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="ddlDistrictNames" runat="server" CssClass="col-md-2 control-label">District Name</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlDistrictNames" DataTextField="DistrictName" DataValueField="DistrictID" CssClass="form-control"
                    runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrictNames_SelectedIndexChanged">
                </asp:DropDownList>


                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ErrorMessage="DrugName required" InitialValue="Select District" ControlToValidate="ddlDistrictNames">*</asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="ddlTaluk" runat="server" CssClass="col-md-2 control-label" Text="Taluk Name"></asp:Label><div class="col-md-10">

                <asp:DropDownList ID="ddlTaluk" DataTextField="DistrictName" DataValueField="DistrictID" CssClass="form-control"
                    runat="server">
                </asp:DropDownList>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ErrorMessage="Taluk Selection is  required" InitialValue="Select Taluk" ControlToValidate="ddlTaluk">*</asp:RequiredFieldValidator>
            </div>
        </div>



        <div class="form-group">
            <asp:Label AssociatedControlID="ddlVillage" runat="server" CssClass="col-md-2 control-label" Text="Village"></asp:Label><div class="col-md-10">

                <asp:DropDownList ID="ddlVillage" DataTextField="DistrictName" DataValueField="DistrictID" CssClass="form-control"
                    runat="server">
                </asp:DropDownList>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ErrorMessage="Village Selection is  required" InitialValue="Select Vilage" ControlToValidate="ddlVillage">*</asp:RequiredFieldValidator>
            </div>
        </div>


        <div class="form-group">
            <asp:Label AssociatedControlID="txtPHCID" runat="server" CssClass="col-md-2 control-label" Text="PHC ID"></asp:Label><div class="col-md-10">

                <asp:TextBox ID="txtPHCID" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ErrorMessage="PHCID is required" ControlToValidate="txtPHCID">*</asp:RequiredFieldValidator>
            </div>
        </div>




        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
