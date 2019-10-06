using SMS.DataModel;
using System.ComponentModel.DataAnnotations;

namespace SMS.ViewModel
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int BookId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual BookDM Book { get; set; }
    }
}