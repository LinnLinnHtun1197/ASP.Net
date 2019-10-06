using SMS.Service;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult List()
        {
            OrderService service = new OrderService();
            List<OrderVM> list = service.SelectList();
            return View(list);
        }

        public ActionResult SaveOrder(OrderVM inputVM)
        {
            OrderService OrderService = new OrderService();
            AddToCartService service = new AddToCartService();
            BookService BookService = new BookService();
            List<CartVM> bookIds = service.selectBookIdByUserId(inputVM.UserId);
          //  int i = bookIds.Count();
            int result = OrderService.Save(inputVM, bookIds);
            int result1 = BookService.DecreseBookAfterOrder(bookIds);
            new AddToCartController().Clear_Cart_After_Order(inputVM.UserId);
            return View("submit-order");
        }

       
        public JsonResult Delete(OrderVM inputVM)
        {
            OrderService service = new OrderService();
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

        public ActionResult ViewinvoiceByUserIdWithOrderDate(int userId , string orderDate)
        {
            OrderService service = new OrderService();
            OrderVM result = service.ViewInvoice(userId , orderDate);
            return View(result);
        }

        public ActionResult ViewinvoiceByUserId(int userId)
        {
            OrderService service = new OrderService();
            OrderVM result = service.SelectOrderDateByUserId(userId);
            if (result.count != 0)
            {
                return View(result);
            }
            else
            {
                return View("NoInvoice");
            }
            
        }

        public ActionResult ViewinvoiceByAdmin(int userId)
        {
            OrderService service = new OrderService();
            OrderVM result = service.SelectOrderDateByUserId(userId);
            return View(result);
        }

        public ActionResult ViewinvoiceByAdminWithOrderDate(int userId, string orderDate)
        {
            OrderService service = new OrderService();
            OrderVM result = service.ViewInvoice(userId, orderDate);
            return View(result);
        }

        public ActionResult MakeAsDelivered(int id , int updatedUserId , int userId , string orderDate)
        {
            OrderService service = new OrderService();
            int result = service.MakeAsDelivered(id ,updatedUserId);
            return RedirectToAction("ViewinvoiceByAdminWithOrderDate", new { userId = userId , orderDate = orderDate });
        }

        public ActionResult ViewInvoiceByUserName()
        {
            OrderService service = new OrderService();
            List<UserVM> list = service.SelectOrderedUser();
            return View(list);
        }


    }
}