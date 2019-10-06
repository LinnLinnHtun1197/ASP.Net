using SMS.DataModel;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service
{
    public class ReportService
    {
        public List<BookVM> IncomeReport(string FromDate, string ToDate)
        {
            List<BookVM> list = new List<BookVM>();
            DateTime fromDate = Convert.ToDateTime(FromDate);
            DateTime toDate = Convert.ToDateTime(ToDate);
            using (OBS_DBContext context = new OBS_DBContext())
            {
                list = context.BookDMs
                    .GroupJoin(context.CategoryDMs,
                    b => b.CategoryId,
                    c => c.Id,
                    (b, c) => new { b, c })
                    .Where(w => w.b.IsDelete == false &&
                w.b.CreatedDate >= fromDate && w.b.CreatedDate <= toDate)
                .Select(s => new BookVM
                {
                    Id = s.b.Id,
                    CategoryName = s.c.FirstOrDefault().Name,
                    Title = s.b.Title,
                    Author = s.b.Author,
                    Summary = s.b.Summary,
                    Price = s.b.Price,
                    Qty = s.b.IncomeQty,
                    Cover = s.b.Cover
                })
                .ToList();
            }

            return list;
        }

        public List<BookVM> BookBalanceReport(string opr, string qty)
        {
            List<BookVM> list = new List<BookVM>();
            int quantity = Convert.ToInt32(qty);
                using (OBS_DBContext context = new OBS_DBContext())
                {
                var query = context.BookDMs
                    .GroupJoin(context.CategoryDMs,
                    b => b.CategoryId,
                    c => c.Id,
                    (b, c) => new { b, c })
                    .Where(w => w.b.IsDelete == false);

                if(opr == "<")
                {
                    query = query.Where(w => w.b.Qty < quantity);
                }
                if (opr == ">")
                {
                    query = query.Where(w => w.b.Qty > quantity);
                }
                if (opr == "==")
                {
                    query = query.Where(w => w.b.Qty == quantity);
                }
                if (opr == "<=")
                {
                    query = query.Where(w => w.b.Qty <= quantity);
                }
                if (opr == ">=")
                {
                    query = query.Where(w => w.b.Qty >= quantity);
                }
                return    query.Select(s => new BookVM
                    {
                        Id = s.b.Id,
                        CategoryName = s.c.FirstOrDefault().Name,
                        Title = s.b.Title,
                        Author = s.b.Author,
                        Summary = s.b.Summary,
                        Price = s.b.Price,
                        Qty = s.b.Qty,
                        Cover = s.b.Cover
                    })
                    .ToList();
                }
        }

    }
}
