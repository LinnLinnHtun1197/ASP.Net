using SMS.Service;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class AdminController : Controller
    {
        UserService service = new UserService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(UserVM inputVM)
        {
            UserVM result = service.LoginByUser(inputVM.Name, inputVM.Password);
            if (result == null)
            {
                return Json("fail");
            }
            else
            {
                Session["CurrentUser"] = result;
                return Json("success");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}