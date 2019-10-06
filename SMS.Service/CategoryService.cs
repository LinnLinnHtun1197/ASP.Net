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
   public class CategoryService
    {
        public List<CategoryVM> SelectList()
        {
            List<CategoryVM> list = new List<CategoryVM>();
            using (OBS_DBContext context = new OBS_DBContext())
            {
                list = context.CategoryDMs.Where(w => w.IsDelete == false).Select(s => new CategoryVM
                {
                    Id = s.Id,
                    Name = s.Name

                }).ToList();
            }
            return list;
        }



        public int Save(CategoryVM inputVM)
        {

            CategoryDM inputDM = new CategoryDM();
            inputDM.Id = inputVM.Id;
            inputDM.Name = inputVM.Name;
            inputDM.Remark = inputVM.Remark;
            inputDM.CreatedUserId = inputVM.CreatedUserId;

            long time = DateTime.Now.Ticks;
            inputDM.Version = time;
            inputDM.CreatedDate = time;
            inputDM.UpdatedDate = time;

            int result = 0;
            using (OBS_DBContext context = new OBS_DBContext())
            {
                context.CategoryDMs.Add(inputDM);
                result = context.SaveChanges();
            }

            return result;
        }

        public List<CategoryVM> selectList()
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.CategoryDMs.Where(w => w.IsDelete == false).Select(s => new CategoryVM
                {
                    Id = s.Id,
                    Name = s.Name,
                    Remark = s.Remark,
                    Version = s.Version
                }).ToList();
            }
        }

        public CategoryVM selectById(int id)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.CategoryDMs.Where(w => w.IsDelete == false && w.Id == id).Select(s => new CategoryVM
                {
                    Id = s.Id,
                    Version = s.Version,
                    Name = s.Name,
                    Remark = s.Remark,
                }).FirstOrDefault();
            }
        }

        public int Update(CategoryVM inputVM)
        {
            long time = DateTime.Now.Ticks;
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.CategoryDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                   .Update(u => new CategoryDM
                   {
                       Name = inputVM.Name,
                       Remark = inputVM.Remark,
                       Version = time,
                       UpdatedUserId = inputVM.UpdatedUserId,
                       UpdatedDate = time
                   });
            }
        }


        public int Delete(CategoryVM inputVM)
        {
            long time = DateTime.Now.Ticks;
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.CategoryDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                    .Update(u => new CategoryDM
                    {
                        IsDelete = true,
                        Version = time,
                        UpdatedUserId = inputVM.UpdatedUserId,
                        UpdatedDate = time
                    });
            }
        }

    }
}
