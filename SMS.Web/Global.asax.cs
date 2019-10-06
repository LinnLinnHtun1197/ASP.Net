using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace SMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //try
            //{
            //    HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            //    if (authCookie != null)
            //    {
            //        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            //        var identity = new GenericIdentity(authTicket.Name, "Forms");
            //        UserVM serializeModel = JsonConvert.DeserializeObject<UserVM>(authTicket.UserData);
            //        serializeModel.Identity = new GenericIdentity(authTicket.Name);
            //        HttpContext.Current.User = serializeModel;
            //    }
            //}
            //catch (Exception exp)
            //{
            //    this.logger.Error(exp);
            //}            
        }
    }
}
