using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using Training.Workshop.Service;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.ASP.Controllers;
using System.Web.Script.Serialization;
using Training.Workshop.ASP.Client.PrincipalRealization;

namespace Training.Workshop.ASP.Client
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            log4net.Config.XmlConfigurator.Configure();

            // Code that runs on application startup
            //Register Existing Services
            ServiceLocator.RegisterService<IUserService>(typeof(UserService));

            ServiceLocator.RegisterService<IBikeService>(typeof(BikeService));

            ServiceLocator.RegisterService<ISparepartService>(typeof(SparepartService));

            //Configuration of Database 
            //Work with file database, uncomment if need and comment the SQL factory.
            //Data.Context.Current.RepositoryFactory = new RepositoryFactory();

            //UnitOfWork.Context.Current.UnitOfWorkFactory = new FileSystemDatabaseUnitOfWorkFactory();

            //Configuration of Database
            //Work with SQL Database,if need work with file database need to comment Factory;
            Data.Context.Current.RepositoryFactory = new Training.Workshop.Data.SQL.RepositoryFactory();

            UnitOfWork.Context.Current.UnitOfWorkFactory = new Training.Workshop.Data.SQL.SQLSystemUnitOfWork.SQLSystemDatabaseUnitofWorkFactory();

            //Register Existing PageControllers
            //Use Resolve Methods in Page Creation stage.
            PageControllerLocator.PageControllerLocator.RegisterPageController<IUserPageController>(typeof(UserPageController));
            PageControllerLocator.PageControllerLocator.RegisterPageController<IAuthenticationController>(typeof(AuthenticationController));
            PageControllerLocator.PageControllerLocator.RegisterPageController<IAdminPanelController>(typeof(AdminPanelController));
            PageControllerLocator.PageControllerLocator.RegisterPageController<IPersonalCabinetController>(typeof(PersonalCabinetController));
            PageControllerLocator.PageControllerLocator.RegisterPageController<IDefaultController>(typeof(DefaultController));
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }
        /// <summary>
        /// Authenticate request. Decrypt ticket,deserialize information,then may used by HttpContext.Current.User.IsInRole();
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                CustomPrincipalSerializedModel serializeModel =
                  serializer.Deserialize<CustomPrincipalSerializedModel>(authTicket.UserData);
                var newUser = new CustomPrincipal(authTicket.Name);
                newUser.Id = serializeModel.Id;
                newUser.Username = serializeModel.Username;
                HttpContext.Current.User = newUser;
            }
        }

    }
}
