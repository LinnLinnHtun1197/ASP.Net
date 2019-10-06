using SMS.Service;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class UserCRUDController : Controller
    {
        public ActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Entry(UserVM inputVM)
        {
            UserService service = new UserService();
            int result = service.Save(inputVM);

            if (result > 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }

        public ActionResult AdminList()
        {
            UserService service = new UserService();
            List<UserVM> list = service.AdminSelectList();
            return View(list);
        }
        public ActionResult CustomerList()
        {
            UserService service = new UserService();
            List<UserVM> list = service.CustomerSelectList();
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            UserService service = new UserService();
            UserVM updateVM = service.SelectById(id);
            return View(updateVM);
        }

        [HttpPost]
        public JsonResult Edit(UserVM inputVM)
        {
            UserService service = new UserService();
            int result = service.Update(inputVM);

            if (result > 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }

        [HttpPost]
        public JsonResult Delete(UserVM inputVM)
        {
            UserService service = new UserService();
            int result = service.Delete(inputVM);
            if (result > 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }

        public ActionResult UserProfile(int id)
        {
            UserService userService = new UserService();
            UserVM updateVM = userService.SelectById(id);
            return View(updateVM);
        }
    }
}