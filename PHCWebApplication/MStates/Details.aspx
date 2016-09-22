<%@ Page Title="MState Details" Language="C#" MasterPageFile="~/Site.Master" CodeBehind="Details.aspx.cs" Inherits="PHCWebApplication.MStates.Details" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
		<p>&nbsp;</p>
      
        <asp:FormView runat="server"
            ItemType="PHC.DataAccess.MState" DataKeyNames="StateID"
            SelectMethod="GetItem"
            OnItemCommand="ItemCommand" RenderOuterTable="false">
            <EmptyDataTemplate>
                Cannot find the MState with StateID <%: Request.QueryString["StateID"] %>
            </EmptyDataTemplate>
            <ItemTemplate>
                <fieldset class="form-horizontal">
                    <legend>MState Details</legend>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>StateID</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="StateID" ID="StateID" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>Name</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="Name" ID="Name" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>LastModifiedBy</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="LastModifiedBy" ID="LastModifiedBy" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>LastModifiedDate</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="LastModifiedDate" ID="LastModifiedDate" Mode="ReadOnly" />
								</div>
							</div>
							<div class="row">
								<div class="col-sm-2 text-right">
									<strong>ObsInd</strong>
								</div>
								<div class="col-sm-4">
									<asp:DynamicControl runat="server" DataField="ObsInd" ID="ObsInd" Mode="ReadOnly" />
								</div>
							</div>
                 	<div class="row">
					  &nbsp;
					</div>
					<div class="form-group">
						<div class="col-sm-offset-2 col-sm-10">
							<asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Back" CssClass="btn btn-default" />
						</div>
					</div>
                </fieldset>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>

