using EntityFramework.Extensions;
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
    public class BookController : Controller
    {
        public ActionResult Entry()
        {
            CategoryService service = new CategoryService();
            List<CategoryVM> list = service.SelectList();
            return View(list);
        }

        public ActionResult Edit(int id)
        {
            BookService Book_Service = new BookService();
            BookVM book =  Book_Service.selectListById(id);
            CategoryService service = new CategoryService();
            book.categoryVMs = service.SelectList();
            return View(book);
        }

        public ActionResult Save(HttpPostedFileBase file)
        {

            if (file != null)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);

                //save new record in database
                BookDM model = new BookDM();
               
                model.CreatedUserId = int.Parse(Request.Form["CreatedUserId"]);
                model.CategoryId = int.Parse(Request.Form["selCategory"]);
                model.Title = Request.Form["txtBook_Title"];
                model.Author = Request.Form["txtAuthor"];
                model.Summary = Request.Form["txtSummary"];
                model.Price = int.Parse(Request.Form["txtPrice"]);
                model.Qty = int.Parse(Request.Form["txtQty"]);
                model.IncomeQty = int.Parse(Request.Form["txtQty"]);
                model.Cover = ImageName;
                DateTime time = DateTime.Today;
                model.Version = time;
                model.CreatedDate = time;
                model.UpdatedDate = time;
                model.OrderId = 0;
                model.Status = 0;
                using (OBS_DBContext context = new OBS_DBContext())
                {
                    context.BookDMs.Add(model);
                    context.SaveChanges();
                }
                    
                

            }
            //Display records
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file)
        {

            BookDM model = new BookDM();
            if (file != null)
            {
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/images/" + ImageName);

                // save image in folder
                file.SaveAs(physicalPath);
                model.Cover = ImageName;

            }
            else
            {
                model.Cover = Request.Form["Cover"];
            }
            int id = int.Parse(Request.Form["Id"]);
            DateTime version = Convert.ToDateTime(Request.Form["Version"]);
            model.UpdatedUserId = int.Parse(Request.Form["UpdatedUserId"]);
            model.CategoryId = int.Parse(Request.Form["selCategory"]);
            model.Title = Request.Form["txtBook_Title"];
            model.Author = Request.Form["txtAuthor"];
            model.Summary = Request.Form["txtSummary"];
            model.Price = int.Parse(Request.Form["txtPrice"]);
            model.IncomeQty = int.Parse(Request.Form["txtQty"]);
            model.Qty = int.Parse(Request.Form["txtQty"]);
            DateTime time = DateTime.Today;
            model.Version = time;
            model.UpdatedDate = time;

            using (OBS_DBContext context = new OBS_DBContext())
            {
                context.BookDMs.Where(w => w.Id == id && w.Version == version)
                   .Update(u => new BookDM
                   {
                       Title = model.Title,
                       CategoryId = model.CategoryId,
                       Author = model.Author,
                       Summary = model.Summary,
                       Price = model.Price,
                       Qty = model.Qty,
                       Cover = model.Cover,
                       Version = time,
                       UpdatedUserId = model.UpdatedUserId,
                       UpdatedDate = time
                   });
            }  
            //Display records
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            BookService service = new BookService();
            List<BookVM> list = service.selectList();
            return View(list);
        }

        public ActionResult book_detail(int id)
        {
            BookService service = new BookService();
            BookVM book = service.selectListById(id);
            return View(book);
        }

        [HttpPost]
        public JsonResult Delete(BookVM inputVM)
        {
            BookService service = new BookService();
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

        public ActionResult StockBalance()
        {
            BookService service = new BookService();
            List<BookVM> list = service.selectBalanceList();
            return View(list);
        }


    }
}