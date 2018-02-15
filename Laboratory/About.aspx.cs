using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratory
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute(
     name: "DefaultApi",
     routeTemplate: "api/{controller}/{id}",
     defaults: new { id = System.Web.Http.RouteParameter.Optional }
                              );
        }
    }
}