using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.ASP.Views;
using System.Web.Security;
using Training.Workshop.Domain.Entities;
using System.Web.Script.Serialization;
using Training.Workshop.ASP.Client.PrincipalRealization;
using System.Data;
using System.Collections;

namespace Training.Workshop.ASP.Client
{
    public partial class AdminPanel : PageView<IAdminPanelController>,IAdminPanelView
    {
        /// <summary>
        /// Get needed controller for this page
        /// </summary>
        /// <returns></returns>
        protected override IAdminPanelController GetController()
        {
            return PageControllerLocator.PageControllerLocator.Resolve<IAdminPanelController>();
        }
        /// <summary>
        /// Page Loading
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(System.EventArgs e)
        {
            //retrieve information about all users
            if (HttpContext.Current.User.IsInRole("administrator"))
            {
                Usercatalogrepeater.ItemDataBound += new RepeaterItemEventHandler(Usercatalogrepeater_OnItemDataBound);

                NewUserRepeater.ItemDataBound += new RepeaterItemEventHandler(NewUserRepeater_OnItemDataBound);
                
                //command event initialized
                Bikecatalogrepeater.ItemCommand += new RepeaterCommandEventHandler(RepeaterListOfUsers_OnItemCommand);    
                
                if (!IsPostBack)
                {
                    //Manually register the event-handling
                    //Adding user information to repeater
                    var data=GetController().GetAllUsers();
                    Usercatalogrepeater.DataSource = data;
                    Usercatalogrepeater.DataBind();

                    Bikecatalogrepeater.DataSource = GetController().GetAllBikes();
                    Bikecatalogrepeater.DataBind();

                    NewUserRepeater.DataSource = data;
                    NewUserRepeater.DataBind();
                }
                base.OnLoad(e);
            }
            else Response.Redirect("~\\Authentication.aspx");
            
        }
        /// <summary>
        /// Method that boundeed data to Repeater
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Usercatalogrepeater_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) ||
                     (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Literal Permissionsliteral = (Literal)e.Item.FindControl("Permissionsliteral");
                
                Literal Rolesliteral = (Literal)e.Item.FindControl("Rolesliteral");
                
                Literal UserNameliteral = (Literal)e.Item.FindControl("UserNameliteral");
                
                User user = (User)e.Item.DataItem;

                if (UserNameliteral.Text=="")
                {
                    UserNameliteral.Text = user.Username;
                    
                    string roles = "";
                    
                    string permissions = "";

                    foreach (var role in user.Roles)
                    {
                        roles += role.Name + " ";
                        foreach (var permission in role.Permissions)
                        {
                            if (!permissions.Contains(permission))
                            {
                                permissions += permission + " ";
                            }
                        }
                    }

                    Rolesliteral.Text = roles;
                    Permissionsliteral.Text = permissions;
                }
                
                //check data type in permission column and rewrite it into string=", , ,"
               
            }
        }
        /// <summary>
        /// External repeater data bound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NewUserRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) ||
                         (e.Item.ItemType == ListItemType.AlternatingItem))
            {

                
                //Construct the fields of external repeater
                Literal Usernamefield = (Literal)e.Item.FindControl("Usernamefield");

                Literal Rolesfield = (Literal)e.Item.FindControl("Rolesfield");

                User user = (User)e.Item.DataItem;

                //Bind the data to nested repeater
                Repeater NestedNewUserRepeater = (Repeater)e.Item.FindControl("NestednewUserRepeater");
                
                NestedNewUserRepeater.DataSource = user.Roles;

                if (Usernamefield.Text == "")
                {
                    Usernamefield.Text = user.Username;

                    foreach (var role in user.Roles)
                    {
                        Rolesfield.Text += " " + role.Name;
                    }

                }
                NestedNewUserRepeater.DataBind();
            }
        }
        /// <summary>
        /// Internal repeater data bound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void NestedNewUserRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) ||
                         (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Literal Permissionsfield = (Literal)e.Item.FindControl("Permissionsfield");

                var role = (Role)e.Item.DataItem;

                foreach (var permission in role.Permissions)
                {
                    if(!Permissionsfield.Text.Contains(permission))
                    {
                     Permissionsfield.Text+=" "+permission;
                    }
                }

            }
        }
        /// <summary>
        /// Bike repeater data bound
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected void Bikecatalogrepeater_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) ||
                   (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Bike bike = (Bike)e.Item.DataItem;

                Literal Manufacturerliteral = (Literal)e.Item.FindControl("Manufacturerliteral");
                
                Literal Markliteral = (Literal)e.Item.FindControl("Markliteral");
                
                Literal OwnerIDliteral = (Literal)e.Item.FindControl("OwnerIDliteral");
                
                Literal BikeYearliteral = (Literal)e.Item.FindControl("BikeYearliteral");
                
                Literal ConditionStateliteral = (Literal)e.Item.FindControl("ConditionStateliteral");
                
                Button UpdateBikeConditionButton = (Button)e.Item.FindControl("UpdateBikeConditionButton");
                
                UpdateBikeConditionButton.CommandArgument = ConditionStateliteral.Text;
                
                
                if (Manufacturerliteral.Text == "")
                {
                    Manufacturerliteral.Text = bike.Manufacturer;
                    Markliteral.Text = bike.Mark;
                    OwnerIDliteral.Text = Convert.ToString(bike.OwnerID);
                    BikeYearliteral.Text = Convert.ToString(bike.BikeYear);
                    ConditionStateliteral.Text = bike.ConditionState;
                }

                UpdateBikeConditionButton.Text = "Update Condition";
                UpdateBikeConditionButton.CommandArgument = Manufacturerliteral.Text + " " + Markliteral.Text + " " + OwnerIDliteral.Text + " " + ConditionStateliteral.Text;
            }
        }
        /// <summary>
        /// Repeater button event executer
        /// </summary>D:\Myproject_git\Bikeworkshop\Training.Workshop.ASP.Client\PrincipalRealization\CustomPrincipal.cs
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RepeaterListOfUsers_OnItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "UpdateCondition")
            {
                var clickedbutton = (Button)Bikecatalogrepeater.Items[e.Item.ItemIndex].FindControl("UpdateBikeConditionButton");
                
                string[] commands = clickedbutton.CommandArgument.Split(' ');

                GetController().UpdateExistingBike(commands[0], commands[1], int.Parse(commands[2]),commands[3], "Good");
            }
        }


        /// <summary>
        /// Add new user method from admin panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddNewUser(object sender, EventArgs e)
        {
            string[] roles = { UserRoleTextBox.Text };
            var user=GetController().AddNewUser(UserNameTextBox.Text, UserPasswordTextBox.Text,roles);
             //user correctly added to database
            Response.Redirect("~\\Default.aspx");

        }
        /// <summary>
        /// Delete existing user method from admin panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteUser(object sender, EventArgs e)
        {
            try
            {
                GetController().DeleteUser(UserNameTextBox.Text);
            }
            catch
            {
                //TODO
                //need rework
                Response.Redirect("Default.aspx");
            }
        }
        /// <summary>
        /// Update existing user from admin panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateUser(object sender, EventArgs e)
        { 
            //TODO
            //need realization
        }
        /// <summary>
        /// Add new bike method from admin panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddNewBike(object sender,EventArgs e)
        {
            Bike.Create(_BikeManufacturer.Text, _BikeMark.Text, _BikeOwner.Text, int.Parse(_BikeTear.Text), _BikeCondition.Text);                
        }
        /// <summary>
        /// Update existing bike from admin panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateExistingBike(object sender, EventArgs e)
        {
            //TODO
            //need rework
        }
        /// <summary>
        /// Create ticket for user
        /// </summary>
        /// <param name="user"></param>
    }
}