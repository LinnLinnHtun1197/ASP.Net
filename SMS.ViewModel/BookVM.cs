using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.ViewModel
{
   public class BookVM
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int OrderId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public int IncomeQty { get; set; }
        public int Qty { get; set; }
        public string Cover { get; set; }
        public int Status { get; set; }
        public bool IsDelete { get; set; }
        public DateTime Version { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<CategoryVM> categoryVMs { get; set; }

    }
}
