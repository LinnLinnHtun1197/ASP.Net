using SMS.Service;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class PositionController : Controller
    {
        public ActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Entry(PositionVM input)
        {
            var currentUser = (SMS.ViewModel.UserVM)Session["CurrentUser"];
            input.CreatedUserId = currentUser.Id;
            input.UpdatedUserId = currentUser.Id;
            PositionService service = new PositionService();
            int result = service.Save(input);
            if (result == 100)
            {
                return Json("duplicate");
            }
            else if (result != 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }
        public ActionResult List()
        {
            PositionService service = new PositionService();
            List<PositionVM> list = service.SelectList();
            return View(list);
        }
        public ActionResult Edit(int id)
        {
            PositionService service = new PositionService();

            PositionVM updateVM = service.SelectById(id);

            return View(updateVM);
        }
        [HttpPost]
        public JsonResult Edit(PositionVM inputVM)
        {
            PositionService service = new PositionService();
            int result = service.Update(inputVM);

            if (result == 100)
            {
                return Json("duplicate");
            }
            else if (result != 0)
            {
                return Json("success");
            }
            else
            {
                return Json("fail");
            }
        }
        [HttpPost]
        public JsonResult Delete(PositionVM inputVM)
        {
            PositionService service = new PositionService();
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
    }
}