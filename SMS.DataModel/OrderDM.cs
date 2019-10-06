using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.DataModel
{
  public class OrderDM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Qty { get; set; }
        public string Order_Date { get; set; }
        public string Name { get; set; }
        public string Delivery_Address { get; set; }
        public int Status { get; set; }
        public bool IsDelete { get; set; }
        public long Version { get; set; }
        public int CreatedUserId { get; set; }
        public long CreatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public long UpdatedDate { get; set; }

    }
}
