using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.ViewModel
{
   public class OrderVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Order_Date { get; set; }
        public string Name { get; set; }
        public string Receiver_Name { get; set; }
        public string Delivery_Address { get; set; }
        public int count { get; set; }
        public int Status { get; set; }
        public bool IsDelete { get; set; }
        public long Version { get; set; }
        public int CreatedUserId { get; set; }
        public long CreatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public long UpdatedDate { get; set; }

        public OrderVM OrderVMs { get; set; }
        public List<UserVM> UserVM { get; set; }
        public List<OrderVM> OrderVMList { get; set; }
        public List<BookVM> BookVM { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string FullAddress { get; set; }
        public string Title { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }

    }
}
