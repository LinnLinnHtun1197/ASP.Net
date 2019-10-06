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
    public class UserService
    {
        public UserVM LoginByUser(string name, string password)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.UserDMs.Where(w => w.IsDelete == false &&
                                        w.Name == name && w.Password == password && w.PositionId == 1).Select(s => new UserVM
                                        {
                                            Id = s.Id,
                                            Name = s.Name,
                                            PositionId = s.PositionId
                                        })
                                        .FirstOrDefault();
            }

        }

        public UserVM LoginByAdmin(string name, string password)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.UserDMs.Where(w => w.IsDelete == false &&
                                        w.Name == name && w.Password == password && w.PositionId == 2).Select(s => new UserVM
                                        {
                                            Id = s.Id,
                                            Name = s.Name,
                                            PositionId = s.PositionId
                                        })
                                        .FirstOrDefault();
            }

        }

        public int Save(UserVM inputVM)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                int count = context.UserDMs.Where(w => w.IsDelete == false && w.NRC == inputVM.NRC).Count();
                if (count > 0)
                {
                    // duplicate code
                    return 100;
                }
            }
            UserDM inputDM = new UserDM();
            inputDM.PositionId = 1;
            inputDM.Name = inputVM.Name;
            inputDM.Password = inputVM.Password;
            inputDM.Gender = inputVM.Gender;
            inputDM.DOB = inputVM.DOB;
            inputDM.NRC = inputVM.NRC;
            inputDM.FatherName = inputVM.FatherName;
            inputDM.FullAddress = inputVM.FullAddress;
            inputDM.PhoneNo = inputVM.PhoneNo;
            inputDM.Email = inputVM.Email;
            inputDM.CreatedUserId = inputVM.CreatedUserId;

            long time = DateTime.Now.Ticks;
            inputDM.Version = time;
            inputDM.CreatedDate = time;
            inputDM.UpdatedDate = time;

            int result = 0;
            using (OBS_DBContext context = new OBS_DBContext())
            {
                context.UserDMs.Add(inputDM);
                result = context.SaveChanges();
            }

            return result;
        }

        public int SaveforCustomer(UserVM inputVM)
        {
            //using (OBS_DBContext context = new OBS_DBContext())
            //{
            //    int count = context.UserDMs.Where(w => w.IsDelete == false && w.NRC == inputVM.NRC).Count();
            //    if (count > 0)
            //    {
            //        // duplicate code
            //        return 100;
            //    }
            //}
            UserDM inputDM = new UserDM();
            inputDM.PositionId = 1;
            inputDM.Name = inputVM.Name;
            inputDM.Password = inputVM.Password;
            inputDM.Gender = inputVM.Gender;
            inputDM.DOBStr = inputVM.DOBStr;
            inputDM.NRC = inputVM.NRC;
            inputDM.FatherName = inputVM.FatherName;
            inputDM.FullAddress = inputVM.FullAddress;
            inputDM.PhoneNo = inputVM.PhoneNo;
            inputDM.Email = inputVM.Email;

            long time = DateTime.Now.Ticks;
            inputDM.Version = time;
            inputDM.CreatedDate = time;
            inputDM.UpdatedDate = time;

            int result = 0;
            using (OBS_DBContext context = new OBS_DBContext())
            {
                context.UserDMs.Add(inputDM);
                result = context.SaveChanges();
            }

            return result;
        }

        public int Update(UserVM inputVM)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                long time = DateTime.Now.Ticks;

                return context.UserDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                        .Update(u => new UserDM
                        {
                            PositionId = 1,
                            Name = inputVM.Name,
                            Password = inputVM.Password,
                            Gender = inputVM.Gender,
                            DOBStr = inputVM.DOBStr,
                            NRC = inputVM.NRC,
                            FatherName = inputVM.FatherName,
                            FullAddress = inputVM.FullAddress,
                            PhoneNo = inputVM.PhoneNo,
                            Email = inputVM.Email,
                            Version = time,
                            UpdatedUserId = inputVM.UpdatedUserId,
                            UpdatedDate = time
                        });
            }
        }

        public int Delete(UserVM inputVM)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                long time = DateTime.Now.Ticks;

                return context.UserDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                        .Update(u => new UserDM
                        {
                            IsDelete = true,
                            Version = time,
                            UpdatedUserId = inputVM.UpdatedUserId,
                            UpdatedDate = time
                        });
            }
        }

        public List<UserVM> AdminSelectList()
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.UserDMs.Where(w => w.IsDelete == false && w.PositionId == 2).Select(s => new UserVM
                {
                    Id = s.Id,
                    Version = s.Version,
                    Name = s.Name,
                    Gender = s.Gender,
                    DOB = s.DOB,
                    NRC = s.NRC,
                    FatherName = s.FatherName,
                    FullAddress = s.FullAddress,
                    PhoneNo = s.PhoneNo,
                    Email = s.Email,

                }).ToList();
            }
        }
        public List<UserVM> CustomerSelectList()
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.UserDMs.Where(w => w.IsDelete == false && w.PositionId == 1).Select(s => new UserVM
                {
                    Id = s.Id,
                    Version = s.Version,
                    Name = s.Name,
                    Gender = s.Gender,
                    DOBStr = s.DOBStr,
                    NRC = s.NRC,
                    FatherName = s.FatherName,
                    FullAddress = s.FullAddress,
                    PhoneNo = s.PhoneNo,
                    Email = s.Email,

                
               }).ToList();
           
        }
        }
        public UserVM SelectById(int id)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.UserDMs.Where(w => w.IsDelete == false && w.Id == id).Select(s => new UserVM
                {
                    Id = s.Id,
                    Version = s.Version,

                    PositionId = s.PositionId,
                    Name = s.Name,
                    Password = s.Password,
                    Gender = s.Gender,
                    DOBStr = s.DOBStr,
                    NRC = s.NRC,
                    FatherName = s.FatherName,

                    FullAddress = s.FullAddress,
                    PhoneNo = s.PhoneNo,
                    Email = s.Email,

                })
                .FirstOrDefault();
            }
        }

        public int CheckUser(int UserId)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.UserDMs.Where(w => w.IsDelete == false && w.Id == UserId).Count();
            }
        }

    }
}
