using SMS.Service;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class BookStoreController : Controller
    {
        public ActionResult Index()
        {
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
            return View("Index",model);
        }

        public ActionResult book_detail(int id)
        {
            BookService service = new BookService();
            BookVM book = service.selectListById(id);
            return View(book);
        }


    }
}