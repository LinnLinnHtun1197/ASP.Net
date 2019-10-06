using SMS.Service;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class AdminCRUDController : Controller
    {
        public ActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Entry(UserVM inputVM)
        {
            AdminService service = new AdminService();
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
            AdminService service = new AdminService();
            List<UserVM> list = service.AdminSelectList();
            return View(list);
        }
        public ActionResult Edit(int id)
        {
            AdminService service = new AdminService();
            UserVM updateVM = service.SelectById(id);
            return View(updateVM);
        }

        [HttpPost]
        public JsonResult Edit(UserVM inputVM)
        {
            AdminService service = new AdminService();
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
            AdminService service = new AdminService();
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


        public ActionResult AdminProfile(int id)
        {
            AdminService service = new AdminService();
            UserVM updateVM = service.SelectById(id);
            return View(updateVM);
        }
    }
}