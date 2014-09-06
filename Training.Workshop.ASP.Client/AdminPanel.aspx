<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Training.Workshop.ASP.Client.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="accountInfo">
        <fieldset class="login">
           <legend>Add\Delete new user panel</legend>
           <br />
           <asp:Label ID="AddedPopUp" runat="server" Visible="false">User added to database</asp:Label>
           <br />
           <asp:Label ID="UserNameLabel" runat="server">Username:</asp:Label>
            <br />
           <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
           <asp:Label ID="UserPasswordLabel" runat="server">Password:</asp:Label>
            <br />
           <asp:TextBox ID="UserPasswordTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
           <asp:Label ID="UserPermissionsLabel" runat="server">Permissions:</asp:Label>
           <br />
           <asp:TextBox ID="UserPermissionsTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           <asp:Label ID="UserRoleLabel" runat="server">User Role:</asp:Label>
           <asp:TextBox ID="UserRoleTextBox" runat="server" CssClass="textEntry"></asp:TextBox>
            
            <br />
            
           <p class="submitButton">
             <asp:Button ID="AddUserButton" runat="server" Text="Add User" 
                   OnClick="AddNewUser" Height="30px" Width="321px" />
             <asp:Button ID="DeleteUserButton" runat="server" Text="Delete User" 
                   OnClick="DeleteUser" Height="30px" Width="321px" />
           </p>
        </fieldset>
    </div>

    <div class="accountInfo">
        <fieldset class="login">
           <legend>Update user panel</legend>
           
           <asp:Label ID="UsernameUpdatelabel" runat="server">Username:</asp:Label>
           <asp:TextBox ID="_UpdateUsername" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           <asp:Label ID="UpdateUserPasswordlabel" runat="server">Password:</asp:Label>
           <asp:TextBox ID="_UpdateUserPassword" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           <asp:Label ID="UpdateNewUserPasswordlabel" runat="server">New Password:</asp:Label>
           <asp:TextBox ID="_UpdateNewUserPassword" runat="server" CssClass="textEntry"></asp:TextBox>
            
           <p class="submitButton">
             <asp:Button ID="UpdateUserButton" runat="server" Text="Update User" 
                   OnClick="UpdateUser" Height="30px" Width="321px" />
           </p>
        </fieldset>
    </div>

      <div class="accountInfo">
        <fieldset class="login">
           <legend>Add new bike panel</legend>
           
           <asp:Label ID="BikeManufacturer" runat="server">Manufacturer:</asp:Label>
           <asp:TextBox ID="_BikeManufacturer" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           <asp:Label ID="BikeMark" runat="server">Mark:</asp:Label>
           <asp:TextBox ID="_BikeMark" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           <asp:Label ID="BikeYear" runat="server">BikeYear:</asp:Label>
           <asp:TextBox ID="_BikeTear" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           
           <asp:Label ID="BikeOwner" runat="server">Owner:</asp:Label>
           <asp:TextBox ID="_BikeOwner" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
           
           <asp:Label ID="BikeCondition" runat="server">Condition:</asp:Label>
           <asp:TextBox ID="_BikeCondition" runat="server" CssClass="textEntry"></asp:TextBox>
           <br />
            
           <p class="submitButton">
             <asp:Button ID="AddBikeButton" runat="server" Text="Add Bike" 
                   OnClick="AddNewBike" Height="30px" Width="321px" />
             <asp:Button ID="UpdateBikeButton" runat="server" Text="Update Bike" 
                   OnClick="UpdateExistingBike" Height="30px" Width="321px" />
           </p>
        </fieldset>
    </div>

    <asp:Repeater ID="Usercatalogrepeater" runat="server" OnItemDataBound="Usercatalogrepeater_OnItemDataBound"> 
        <HeaderTemplate>
                <table border="0" width="100%">
            <tr>
                <th align="left">Username</th>
                <th align="left">Roles</th>
                <th align="left">Permissions</th>
            </tr>
        </HeaderTemplate>
        
        <ItemTemplate>
            <tr>
                <td width="150"><asp:Literal runat="server" ID="UserNameliteral"  ></asp:Literal> 
                </td>
                <td width="150"><asp:Literal runat="server" ID="Rolesliteral" ></asp:Literal>
                </td>
                <td width="150"><asp:Literal runat="server" ID="Permissionsliteral" ></asp:Literal>
                </td>
            </tr>
        </ItemTemplate>

        <SeparatorTemplate>
            <tr>
            <td colspan="6"></td>
            </tr>
        </SeparatorTemplate>
        
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
<br />
<br />
     <asp:Repeater ID="Bikecatalogrepeater" runat="server" OnItemDataBound="Bikecatalogrepeater_OnItemDataBound"> 
        <HeaderTemplate>
           <table border="0" width="100%">
            <tr>
                <th align="left">Manufacturer</th>
                <th align="left">Mark</th>
                <th align="left">OwnerID</th>
                <th align="left">BikeYear</th>
                <th align="left">ConditionState</th>
            </tr>
        </HeaderTemplate>
         
         <ItemTemplate>
            <tr>
             <td width="150"><asp:Literal runat="server" ID="Manufacturerliteral"  ></asp:Literal> 
                </td>
                <td width="150"><asp:Literal runat="server" ID="Markliteral" ></asp:Literal>
                </td>
                <td width="150"><asp:Literal runat="server" ID="OwnerIDliteral" ></asp:Literal>
                </td>
                <td width="150"><asp:Literal runat="server" ID="BikeYearliteral"  ></asp:Literal> 
                </td>
                <td width="150"><asp:Literal runat="server" ID="ConditionStateliteral" ></asp:Literal>
                </td>
                 <td width="150"><asp:Button runat="server" ID="UpdateBikeConditionButton" CommandName="UpdateCondition" ></asp:Button>
                </td>
                </tr>
        </ItemTemplate>

         <SeparatorTemplate>
            <tr>
            <td colspan="6"></td>
            </tr>
        </SeparatorTemplate>
  
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
<br />
<br />
<br />

 <asp:Repeater ID="NewUserRepeater" runat="server" OnItemDataBound="NewUserRepeater_OnItemDataBound"> 
       <HeaderTemplate>
           <table border="0" width="100%">
            <tr>
                <th align="left" id="Usernamefield">Username</th>
                <th align="left" id="Rolesfield">Roles</th>
                <th align="left" id="Permissionsfield">Permissions</th>
           </tr>
        </HeaderTemplate>
   
    <ItemTemplate>
         <td width="150"><asp:Literal runat="server" ID="Usernamefield"  ></asp:Literal> 
         </td>
         <td width="150"><asp:Literal runat="server" ID="Rolesfield" ></asp:Literal>
         </td>

        <asp:Repeater ID="NestedNewUserRepeater" runat="server" onitemdatabound="NestedNewUserRepeater_ItemDataBound">
            <ItemTemplate>
                 <td width="150"><asp:Literal runat="server" ID="Permissionsfield"  ></asp:Literal> 
                 </td>
            </ItemTemplate>
        </asp:Repeater>
    </ItemTemplate>

    <SeparatorTemplate>
       <tr>
       <td colspan="6"></td>
       </tr>
    </SeparatorTemplate>
  
    <FooterTemplate>
       </table>
    </FooterTemplate>

 </asp:Repeater>

</asp:Content>
