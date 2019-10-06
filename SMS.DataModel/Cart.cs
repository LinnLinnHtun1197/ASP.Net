using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.DataModel
{
     public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BookTitle { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int Count { get; set; }

        public System.DateTime DateCreated { get; set; }
        public virtual BookDM Book { get; set; }
    }
}
