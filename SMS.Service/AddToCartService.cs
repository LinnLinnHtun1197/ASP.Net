using EntityFramework.Extensions;
using SMS.DataModel;
using SMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service
{
    public class AddToCartService
    {
        public List<CartVM> selectCartListByUserId(int id)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.CartDMs.Where(w => w.IsDelete == false && w.UserId == id).Select(s => new CartVM
                {
                    Id = s.Id,
                    BookTitle = s.BookTitle,
                    Quantity = s.Quantity,
                    UnitPrice = s.UnitPrice
                }).ToList();
            }
        }

        public List<CartVM> selectBookIdByUserId(int id)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.CartDMs.Where(w => w.IsDelete == false && w.UserId == id).Select(s => new CartVM
                {
                    BookId = s.BookId,
                    Quantity = s.Quantity,
                }).ToList();
            }
        }

        public int SaveToCartByUser(string title , int price , int userId ,int bookId )
        {
           CartVM previousBook = new CartVM();
            using (OBS_DBContext context = new OBS_DBContext())
            {
                previousBook = context.CartDMs.Where(w => w.IsDelete == false && w.UserId == userId && w.BookId == bookId).
                    Select(s => new CartVM
                {
                    Quantity = s.Quantity,
                }).FirstOrDefault();
            }
            
            if(previousBook != null)
            {
                int result = 0;
                using (OBS_DBContext context = new OBS_DBContext())
                {
                    result = context.CartDMs.Where( w => w.IsDelete == false && w.UserId == userId && w.BookId == bookId)
                       .Update(u => new CartDM
                       {
                           Quantity = previousBook.Quantity + 1,
                       });
                }
                return result;
            }
            else
            {
                CartDM inputDM = new CartDM();
                inputDM.Id = 0;
                inputDM.UserId = userId;
                inputDM.BookId = bookId;
                inputDM.BookTitle = title;
                inputDM.Quantity = 1;
                inputDM.UnitPrice = price;
                int result = 0;
                using (OBS_DBContext context = new OBS_DBContext())
                {
                    context.CartDMs.Add(inputDM);
                    result = context.SaveChanges();
                }
                return result;
            }
  
        }

        public int SaveToCart(string title, int qty, int price, int userId)
        {
            CartDM inputDM = new CartDM();
            inputDM.Id = 0;
            inputDM.UserId = userId;
            inputDM.BookTitle = title;
            inputDM.Quantity = qty;
            inputDM.UnitPrice = price;
            int result = 0;
            using (OBS_DBContext context = new OBS_DBContext())
            {
                context.CartDMs.Add(inputDM);
                result = context.SaveChanges();
            }
            return result;

        }

        public int ClearCartByUserId(int UserId)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.CartDMs.Where(w => w.UserId == UserId)
                    .Update(u => new CartDM
                    {
                        IsDelete = true,
                    });
            }
        }

    }
}
