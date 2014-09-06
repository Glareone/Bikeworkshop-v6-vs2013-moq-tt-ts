using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using log4net;
using System.Security.Principal;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.ASP.Views;

namespace Training.Workshop.ASP.Client
{
    public partial class _Default : PageView<IDefaultController>, IDefaultView
    {
        protected override IDefaultController GetController()
        {
            return PageControllerLocator.PageControllerLocator.Resolve<IDefaultController>();
        }

        protected override void OnLoad(EventArgs e)
        {
            // Clear Current User
            HttpContext.Current.User =new GenericPrincipal(new GenericIdentity(string.Empty), null);
            
            log4net.ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
            //example
            //need to delete
            try
            {
                logger.Info("Open Connection ");

                var connection = new SqlConnection("Data Source=KOLESNIKOV7;Initial Catalog=Training.Workshop.SQLDatabase;Integrated Security=True;");

                logger.Info("We opened and closed the connection to the database");
                connection.Close();
            }
            catch
            {
                throw new Exception("Sql connection cant reached");
            }
            
        }
    }
}
