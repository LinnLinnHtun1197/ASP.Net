using SMS.Service;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class CategoryController : Controller
    {

        public ActionResult Entry()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Entry(CategoryVM input)
        {
            CategoryService service = new CategoryService();
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
            CategoryService service = new CategoryService();
            List<CategoryVM> list = service.selectList();
            return View(list);
        }
        public ActionResult Edit(int id)
        {
            CategoryService service = new CategoryService();

            CategoryVM updateVM = service.selectById(id);

            return View(updateVM);
        }
        [HttpPost]
        public JsonResult Edit(CategoryVM inputVM)
        {
            CategoryService service = new CategoryService();
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
        public JsonResult Delete(CategoryVM inputVM)
        {
            CategoryService service = new CategoryService();
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