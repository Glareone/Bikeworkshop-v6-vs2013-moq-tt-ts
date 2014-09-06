using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Workshop.ASP.Controllers.Interfaces;
using Training.Workshop.ASP.Views;

namespace Training.Workshop.ASP.Client
{
    public partial class PersonalCabinet : PageView<IPersonalCabinetController>, IPersonalCabinetView
    {
        protected override IPersonalCabinetController GetController()
        {
            return PageControllerLocator.PageControllerLocator.Resolve<IPersonalCabinetController>();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (HttpContext.Current.User == null)
            {
                Response.Redirect("~\\Authentication.aspx");
            }
            else
            {
                GridView1.DataSource=GetController().SearchBikesbyOwnername(HttpContext.Current.User.Identity.Name);
                
                GridView1.DataBind();
                
                base.OnLoad(e);
            }


        }
    }

    
}