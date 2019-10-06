using EntityFramework.Extensions;
using SMS.DataModel;
using SMS.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service
{
    public class BookService
    {
        OBS_DBContext context = new OBS_DBContext();
        public List<BookVM> selectBalanceList()
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.BookDMs
                     .GroupJoin(context.CategoryDMs,
                    b => b.CategoryId,
                    c => c.Id,
                    (b, c) => new { b, c })
                    .Where(w => w.b.IsDelete == false).Select(s => new BookVM
                    {
                        Id = s.b.Id,
                        Version = s.b.Version,
                        CategoryName = s.c.FirstOrDefault().Name,
                        Title = s.b.Title,
                        Author = s.b.Author,
                        Summary = s.b.Summary,
                        IncomeQty = s.b.IncomeQty,
                        Qty = s.b.Qty,
                        Price = s.b.Price,
                        Cover = s.b.Cover
                    }).ToList();
            }
        }

        public List<BookVM> selectList()
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.BookDMs
                     .GroupJoin(context.CategoryDMs,
                    b => b.CategoryId,
                    c => c.Id,
                    (b, c) => new { b, c })
                    .Where(w => w.b.IsDelete == false && w.b.Qty != 0).Select(s => new BookVM
                {
                    Id = s.b.Id,
                    Version = s.b.Version,
                    CategoryName = s.c.FirstOrDefault().Name,
                    Title = s.b.Title,
                    Author = s.b.Author,
                    Summary = s.b.Summary,
                    IncomeQty = s.b.IncomeQty,
                    Qty = s.b.Qty,
                    Price = s.b.Price,
                    Cover = s.b.Cover
                }).ToList();
            }
        }

        public BookVM selectListById(int Id)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.BookDMs.Where(w => w.IsDelete == false && w.Id == Id).Select(s => new BookVM
                {
                    Id = s.Id,
                    Version = s.Version,
                    CategoryId = s.CategoryId,
                    Title = s.Title,
                    Author = s.Author,
                    Summary = s.Summary,
                    Qty = s.Qty,
                    Price = s.Price,
                    Cover = s.Cover
                }).FirstOrDefault();
            }
        }

        public List<BookVM> selectListByCategoryId(int CategoryId)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.BookDMs.Where(w => w.IsDelete == false && w.CategoryId == CategoryId).Select(s => new BookVM
                {
                    Id = s.Id,
                    Title = s.Title,
                    Price = s.Price,
                    Cover = s.Cover
                }).ToList();
            }
        }

        public int Delete(BookVM inputVM)
        {
            DateTime time = DateTime.Today;
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.BookDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(u => new BookDM
                    {
                        IsDelete = true,
                        Version = time,
                        UpdatedUserId = inputVM.UpdatedUserId,
                        UpdatedDate = time
                    });
            }
        }


        public BookVM SelectById_for_cart(int id)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.BookDMs.Where(w => w.IsDelete == false && w.Id == id).Select(s => new BookVM
                {
                    Id = s.Id,
                    Title = s.Title,
                    Price = s.Price,
                    Qty = s.Qty
                })
                .FirstOrDefault();
            }
            //Book_In_cart.Add(lst);
            
        }

        public int DecreseBookAfterOrder(List<CartVM> SaleBook)
        {
            List<BookVM> StockofBook = new List<BookVM>();
            using (OBS_DBContext context = new OBS_DBContext())
            {
                StockofBook = context.BookDMs.Where(w => w.IsDelete == false)
                    .Select(s => new BookVM
                    {
                        Id = s.Id,
                        Qty = s.Qty,
                    }).ToList();
            }
            int result = 0;
            foreach ( var books in StockofBook)
            {
                foreach (var item in SaleBook)
                {
                    if (books.Id == item.BookId)
                    {
                        using (OBS_DBContext context = new OBS_DBContext())
                        {
                            result = context.BookDMs.Where(w => w.IsDelete == false && w.Id == item.BookId)
                               .Update(u => new BookDM
                               {
                                   Qty = books.Qty - item.Quantity,
                               });
                        }
                    }
                }        
            }
            return result;
        }

    }
}
