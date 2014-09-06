<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="UserPage.aspx.cs" Inherits="Training.Workshop.ASP.Client.UserPage"%>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>


<asp:Content runat="server" ID="head" ContentPlaceHolderId="MainContent">
  
    <div class="accountInfo">
        <fieldset class="login">
           <legend>Account Information</legend>
           
           <asp:Label ID="UserNameLabel" runat="server">Username:</asp:Label>
            <br />
           <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
           <asp:Label ID="UserPasswordLabel" runat="server">Password:</asp:Label>
            <br />
           <asp:TextBox ID="UserPasswordTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
            <br />
           <asp:Label ID="UserRoleLabel" runat="server">User Role:</asp:Label>
           <asp:TextBox ID="UserRoleTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
            <br />
            
           <p class="submitButton">
             <asp:Button ID="AddUserButton" runat="server" Text="Register" 
                   OnClick="AddNewUser" Height="30px" Width="321px" />
           </p>
        </fieldset>
    </div>

</asp:Content>



