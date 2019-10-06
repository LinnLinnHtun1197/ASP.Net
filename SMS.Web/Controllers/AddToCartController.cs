using SMS.Service;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class AddToCartController : Controller
    {

       public ActionResult add_to_cart(int id)
        {
            BookService book_service = new BookService();
            AddToCartService service = new AddToCartService();
            int userId = 0;
            var currentUser = (SMS.ViewModel.UserVM)Session["CurrentUser"];
            if (currentUser == null )
            {
                userId = 0;

            }
            else
            {
                userId = currentUser.Id;
            }
            BookVM book = book_service.SelectById_for_cart(id);
            int data = service.SaveToCartByUser(book.Title , book.Price, userId , book.Id);
            return RedirectToAction("Index", "User");
        }

        public ActionResult add_to_cartByOther(int id)
        {
            BookService book_service = new BookService();
            AddToCartService service = new AddToCartService();
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
            BookVM book = book_service.SelectById_for_cart(id);
          //  int data = service.SaveToCart(book.Title, book.Price, userId ,, book.Id);
            int data = service.SaveToCartByUser(book.Title, book.Price, userId, book.Id);

            return RedirectToAction("Index", "Bookstore");
        }

        public ActionResult ViewCart()
        {
            AddToCartService service = new AddToCartService();
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
            List<CartVM> data = service.selectCartListByUserId(userId);
            return View(data);
        }

        public ActionResult ViewCartByOther()
        {
            AddToCartService service = new AddToCartService();
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
            List<CartVM> data = service.selectCartListByUserId(userId);
            return View("ViewCartWithOrder", data);
        }

        public ActionResult Clear_Cart()
        {
            AddToCartService service = new AddToCartService();
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
            int data = service.ClearCartByUserId(userId);
            return RedirectToAction("ViewCart");

        }

        public ActionResult Clear_CartByOther()
        {
            AddToCartService service = new AddToCartService();
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
            int data = service.ClearCartByUserId(userId);
            return RedirectToAction("ViewCartByOther");

        }

        public void Clear_Cart_After_Order(int userId)
        {
            AddToCartService service = new AddToCartService();
            int data = service.ClearCartByUserId(userId);
        }


    }
}