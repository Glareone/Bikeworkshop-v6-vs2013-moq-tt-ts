using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Workshop.ASP.Controllers;
using Training.Workshop.ASP.Views;
using Training.Workshop.ASP.Controllers.Interfaces;

namespace Training.Workshop.ASP.Client
{
    public partial class UserPage : PageView<IUserPageController>,IUserPageView
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override IUserPageController GetController()
        {
            return PageControllerLocator.PageControllerLocator.Resolve<IUserPageController>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(System.EventArgs e /*mb without anything*/)
        {

            base.OnLoad(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddNewUser(object sender, EventArgs e)
        {
                string[] roles = UserRoleTextBox.Text.Split(' ');
                
                GetController().AddUser(UserNameTextBox.Text, UserPasswordTextBox.Text,roles);
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    }
}