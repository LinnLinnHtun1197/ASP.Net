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
   public class OrderService
    {
        public List<OrderVM> SelectList()
        {
            List<OrderVM> list = new List<OrderVM>();

            using (OBS_DBContext context = new OBS_DBContext())
            {
                list = context.OrderDMs
                    .GroupJoin(context.UserDMs,
                    b => b.UserId,
                    c => c.Id,
                    (b, c) => new { b, c })
                    .GroupJoin(context.BookDMs,
                    bc => bc.b.BookId,
                    t => t.Id,
                    (bc, t) => new { bc, t })
                    .Where(w => w.bc.b.IsDelete == false).Select(s => new OrderVM
                    {
                        Id = s.bc.b.Id,
                        Version = s.bc.b.Version,
                        Order_Date = s.bc.b.Order_Date,

                        Name = s.bc.c.FirstOrDefault().Name,
                        Email = s.bc.c.FirstOrDefault().Email,
                        PhoneNo = s.bc.c.FirstOrDefault().PhoneNo,
                        FullAddress = s.bc.c.FirstOrDefault().FullAddress,
                        Delivery_Address = s.bc.b.Delivery_Address,
                        Title = s.t.FirstOrDefault().Title,
                       Qty = s.bc.b.Qty,
                        Price = s.t.FirstOrDefault().Price,
                    })
                        .ToList();

                return list;
            }
        }

        public OrderVM ViewInvoice(int userId , string orderDate)
        {
            OrderVM data = new OrderVM();

            using (OBS_DBContext context = new OBS_DBContext())
            {
                data.OrderVMs = context.OrderDMs
                    .GroupJoin(context.UserDMs,
                    b => b.UserId,
                    c => c.Id,
                    (b, c) => new { b, c })
                    .Where(w => w.b.IsDelete == false  && w.b.UserId == userId && w.b.Order_Date == orderDate)
                    .Select(s => new OrderVM
                    {
                        Id = s.b.Id,
                        Version = s.b.Version,
                        Order_Date = s.b.Order_Date,
                        Status = s.b.Status,

                        UserId = s.b.UserId,
                        Name = s.c.FirstOrDefault().Name,
                        Email = s.c.FirstOrDefault().Email,
                        PhoneNo = s.c.FirstOrDefault().PhoneNo,
                        FullAddress = s.c.FirstOrDefault().FullAddress,
                        Receiver_Name = s.b.Name,
                        Delivery_Address = s.b.Delivery_Address,

                    })
                        .FirstOrDefault();
               
            }

            using (OBS_DBContext context1 = new OBS_DBContext())
                {
                    data.BookVM = context1.OrderDMs
                        .GroupJoin(context1.BookDMs,
                        b => b.BookId,
                        c => c.Id,
                        (b, c) => new { b, c })
                        .Where(w => w.b.IsDelete == false && w.b.UserId == userId && w.b.Order_Date == orderDate)
                        .Select(s => new BookVM
                        {
                            Id = s.c.FirstOrDefault().Id,
                            Title = s.c.FirstOrDefault().Title,
                            Qty = s.b.Qty,
                            Price = s.c.FirstOrDefault().Price,
                            Status = s.b.Status,
                            OrderId = s.b.Id,

                        })
                            .ToList();    
                          
                }
            return data;
        }

        public List<UserVM> SelectOrderedUser()
        {
            List<UserVM> data = new List<UserVM>();

            using (OBS_DBContext context = new OBS_DBContext())
            {
                data = context.OrderDMs
                    .GroupJoin(context.UserDMs,
                    b => b.UserId,
                    c => c.Id,
                    (b, c) => new { b, c })
                    .Where(w => w.b.IsDelete == false).Select(s => new UserVM
                    {
                        Id = s.c.FirstOrDefault().Id,
                        Name = s.c.FirstOrDefault().Name,
                        FullAddress = s.c.FirstOrDefault().FullAddress,
                        PhoneNo = s.c.FirstOrDefault().PhoneNo,
                        Email = s.c.FirstOrDefault().Email,
                    }).Distinct().ToList();
            }

            return data;
        }

        public int Delete(OrderVM inputVM)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                long time = DateTime.Now.Ticks;

                return context.OrderDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                        .Update(u => new OrderDM
                        {
                            IsDelete = true,
                            Version = time,
                            UpdatedUserId = inputVM.UpdatedUserId,
                            UpdatedDate = time
                        });
            }
        }
        public int Update(OrderVM inputVM)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                int count = context.OrderDMs.Where(w => w.IsDelete == false && w.Id != inputVM.Id && w.Name == inputVM.Name).Count();
                if (count > 0)
                {

                    return 100;
                }
            }

            using (OBS_DBContext context = new OBS_DBContext())
            {
                long time = DateTime.Now.Ticks;

                return context.OrderDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                        .Update(u => new OrderDM
                        {
                            BookId = inputVM.BookId,
                            UserId = inputVM.UserId,
                            Order_Date = inputVM.Order_Date,
                            Name = inputVM.Name,

                            Delivery_Address = inputVM.Delivery_Address,
                            Status = inputVM.Status,
                            Version = time,
                            UpdatedUserId = inputVM.UpdatedUserId,
                            UpdatedDate = time
                        });
            }
        }

        public int MakeAsDelivered(int OrderId , int UpdatedUserId)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                long time = DateTime.Now.Ticks;

                return context.OrderDMs.Where(w => w.Id == OrderId)
                        .Update(u => new OrderDM
                        {
                            Status = 1,
                            Version = time,
                            UpdatedUserId = UpdatedUserId,
                            UpdatedDate = time
                        });
            }
        }


        public OrderVM SelectOrderDateByUserId(int UserId)
        {
            OrderVM data = new OrderVM();

            using (OBS_DBContext context = new OBS_DBContext())
            {
                data.OrderVMList= context.OrderDMs
                    .Where(w => w.IsDelete == false && w.UserId == UserId)
                .Select(s => new OrderVM
                {
                    Order_Date = s.Order_Date,
                    UserId = s.UserId,

                })
                .Distinct().ToList();
                //Show viewInvoice or not
                data.count = context.OrderDMs
                    .GroupJoin(context.UserDMs,
                    b => b.UserId,
                    c => c.Id,
                    (b, c) => new { b, c })
                    .Where(w => w.b.IsDelete == false && w.b.UserId == UserId).Select(s => new OrderVM
                    {
                        Id = s.c.FirstOrDefault().Id,

                    }).Count();
            }
            return data;
        }

        public List<OrderVM> SelectList(int userId)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                var query = context.OrderDMs
                    .GroupJoin(context.UserDMs,
                    b => b.UserId,
                    c => c.Id,
                    (b, c) => new { b, c })
                    .GroupJoin(context.BookDMs,
                    bc => bc.b.BookId,
                    t => t.Id,
                    (bc, t) => new { bc, t })
                    .Where(w => w.bc.b.IsDelete == false);
                return query.Select(s => new OrderVM
                {
                    Id = s.bc.b.Id,
                    Version = s.bc.b.Version,
                    Order_Date = s.bc.b.Order_Date,

                })
                .ToList();
            }
        }


        public int Save(OrderVM inputVM , List<CartVM> bookIds)
        {
            string todayDate = DateTime.Now.ToString("dd/MM/yyyy");
            int result = 0;
            foreach(var item in bookIds)
            {
                OrderDM inputDM = new OrderDM();
                inputDM.Id = inputVM.Id;
                inputDM.UserId = inputVM.UserId;
                inputDM.BookId = item.BookId;
                inputDM.Qty = item.Quantity;
                inputDM.Order_Date = todayDate;
                inputDM.Name = inputVM.Name;
                inputDM.Delivery_Address = inputVM.Delivery_Address;
                inputDM.Status = 0;
                inputDM.CreatedUserId = inputVM.UserId;

                long time = DateTime.Now.Ticks;
                inputDM.Version = time;
                inputDM.CreatedDate = time;
                inputDM.UpdatedDate = time;

               
                using (OBS_DBContext context = new OBS_DBContext())
                {
                    context.OrderDMs.Add(inputDM);
                    result = context.SaveChanges();
                }

            }

            return result;
        }


    }
}
