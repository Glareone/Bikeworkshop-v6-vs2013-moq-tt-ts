<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalCabinet.aspx.cs" Inherits="Training.Workshop.ASP.Client.PersonalCabinet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" Height="367px" 
        style="margin-top: 71px" Width="666px" AutoGenerateColumns="true">
    </asp:GridView>
</asp:Content>
