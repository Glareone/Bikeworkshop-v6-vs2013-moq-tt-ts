<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authentication.aspx.cs" Inherits="Training.Workshop.ASP.Client.Authentication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                    <p>
                        <span class="name"><asp:LoginName ID="LoginName" runat="server" /></span>
                        <br />
                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserNameLoginTextBox">Username:</asp:Label>
                        <asp:TextBox ID="UserNameLoginTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                     <p>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="UserPasswordLoginTextBox">Password:</asp:Label>
                        <asp:TextBox ID="UserPasswordLoginTextBox" runat="server" 
                             CssClass="passwordEntry" TextMode="Password" Width="322px"></asp:TextBox>
                    </p>
                    <p class="submitButton">
                        <asp:Button ID="LoginSubmit" runat="server" OnClick="LogIn" Text="Log In"/>
                    </p>
</asp:Content>
