using SMS.DataModel;
using SMS.Service;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class UserController : Controller
    {
        UserService service = new UserService();
        public ActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entry(UserVM inputVM)
        {
            UserService service = new UserService();
            int result = service.SaveforCustomer(inputVM);
            return View("Login");
        }


        public ActionResult Index()
        {
            int userId = 0;
            var currentUser = (SMS.ViewModel.UserVM)Session["CurrentUser"];
            if (currentUser == null)
            {
                userId = 0;

            }
            else
            {
                userId = currentUser.Id;
            }
            CategoryVM model = new CategoryVM();
            BookService book_service = new BookService();
            CategoryService cat_service = new CategoryService();
            model.categoryVMs = cat_service.SelectList();
            model.BookVMs = book_service.selectList();
            return View(model);
        }

        public ActionResult IndexByCategoryId(int CatId)
        {
            CategoryVM model = new CategoryVM();
            BookService book_service = new BookService();
            CategoryService cat_service = new CategoryService();
            model.categoryVMs = cat_service.SelectList();
            model.BookVMs = book_service.selectListByCategoryId(CatId);
            return View("Index", model);
        }

        public ActionResult AfterOrder()
        {
            CategoryVM model = new CategoryVM();
            BookService book_service = new BookService();
            CategoryService cat_service = new CategoryService();
            model.categoryVMs = cat_service.SelectList();
            model.BookVMs = book_service.selectList();
            return View(model);

        }
        public ActionResult Login()
        {
            new AddToCartController().Clear_Cart_After_Order(0);
            return View();
        }

        [HttpPost]
        public JsonResult LoginByUser(UserVM inputVM)
        {
            UserVM result = service.LoginByUser(inputVM.Name, inputVM.Password);
            if (result == null)
            {
                return Json("fail");
            }
            else
            {
                Session["CurrentUser"] = result;
                ViewBag.cart = 0;
                return Json("success");                
            }
        }

        [HttpPost]
        public JsonResult LoginByAdmin(UserVM inputVM)
        {
            UserVM result = service.LoginByAdmin(inputVM.Name, inputVM.Password);
            if (result == null)
            {
                return Json("fail");
            }
            else
            {
                Session["CurrentUser"] = result;
                ViewBag.cart = 0;
                return Json("success");
            }
        }

        public ActionResult Logout()
        {
            AddToCartService service = new AddToCartService();
            var currentUser = (SMS.ViewModel.UserVM)Session["CurrentUser"];
            int data = service.ClearCartByUserId(currentUser.Id);

            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public JsonResult CheckUser(int Id)
        {
            int result = service.CheckUser(Id);
            if (result == 1)
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