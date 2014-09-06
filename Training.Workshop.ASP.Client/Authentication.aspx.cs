using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Workshop.ASP.Controllers;
using Training.Workshop.ASP.Views;
using Training.Workshop.ASP.Controllers.Interfaces;
using System.Web.Security;
using System.Security.Principal;
using Training.Workshop.Domain.Entities;
using System.Web.Script.Serialization;
using System.Security.Policy;
using Training.Workshop.ASP.Client.PrincipalRealization;

namespace Training.Workshop.ASP.Client
{
   public partial class Authentication : PageView<IAuthenticationController>, IUserPageView
        {
            protected override IAuthenticationController GetController()
            {
                return PageControllerLocator.PageControllerLocator.Resolve<IAuthenticationController>();
            }

            protected override void OnLoad(System.EventArgs e )
            {
                //Control me
                //TODO
                //need to rework
                // onLoad(blabla.Init(this));
                
                base.OnLoad(e);
            }
            /// <summary>
            /// Basic Login function
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            protected void LogIn(object sender, EventArgs e)
            {
                var user = GetController().LogIn(UserNameLoginTextBox.Text, UserPasswordLoginTextBox.Text);
                 
                 //if user found set cookie to registered user,
                if (user.Username != null)
                {
                    CreateAuthenticationTicket(user);
                }
                //if user not found
                else
                {
                    LoginName.Visible = true;
                }
                
            }
            /// <summary>
            /// External Login function
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            protected void ExternalLogInCallback(object sender, EventArgs e)
            {
                //TODO
                //Need realization
            }

            /// <summary>
            /// work with autentication tickets
            /// </summary>
            /// <param name="username"></param>
            public void CreateAuthenticationTicket(User user)
            {
                var serializemodel = new CustomPrincipalSerializedModel();

                serializemodel.Username = user.Username;
                //serializing our user
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string userData = serializer.Serialize(serializemodel);
                //create new ticket and encrypted it
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddHours(2), false, userData);
                
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                //create http cookie which exist ticket and added it
                HttpCookie ourCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                
                Response.Cookies.Add(ourCookie);

            }



        }

}