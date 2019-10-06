using SMS.Service;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult IncomeReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProduceIncomeReport(string fromDate , string toDate)
        {
            ReportService service = new ReportService();
            List<BookVM> reports = service.IncomeReport(fromDate, toDate);
            return View("ProduceIncomeReport", reports);
        }

        public ActionResult BookBalanceReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProduceBookBalanceReport(string opr, string qty)
        {
            ReportService service = new ReportService();
            List<BookVM> reports = service.BookBalanceReport(opr, qty);
            return View("ProduceBookBalanceReport", reports);
        }

    }
}