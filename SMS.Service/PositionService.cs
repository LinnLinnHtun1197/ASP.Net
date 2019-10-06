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
   public class PositionService
    {
        public int Save(PositionVM inputVM)
        {

            PositionDM inputDM = new PositionDM();
            inputDM.Name = inputVM.Name;
            inputDM.Description = inputVM.Description;
            long time = DateTime.Now.Ticks;
            int result = 0;

            inputDM.Version = time;
            inputDM.CreatedDate = time;
            inputDM.UpdatedDate = time;
            inputDM.CreatedUserId = inputVM.CreatedUserId;
            inputDM.UpdatedUserId = inputVM.UpdatedUserId;
            using (OBS_DBContext context = new OBS_DBContext())
            {
                context.PositionDMs.Add(inputDM);
                result = context.SaveChanges();
            }
            return result;
        }
        public List<PositionVM> SelectList()
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.PositionDMs.Where(w => w.IsDelete == false).Select(s => new PositionVM
                {
                    Id = s.Id,
                    Version = s.Version,
                    Name = s.Name,
                    Description = s.Description,
                }).ToList();
            }
        }
        public int Update(PositionVM inputVM)
        {

            using (OBS_DBContext context = new OBS_DBContext())
            {
                long time = DateTime.Now.Ticks;

                return context.PositionDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                        .Update(u => new PositionDM
                        {
                            Name = inputVM.Name,
                            Description = inputVM.Description,
                            Version = time,
                            UpdatedUserId = inputVM.UpdatedUserId,
                            UpdatedDate = time
                        });
            }
        }
        public PositionVM SelectById(int id)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                return context.PositionDMs.Where(w => w.IsDelete == false && w.Id == id).Select(s => new PositionVM
                {
                    Id = s.Id,
                    Version = s.Version,
                    Name = s.Name,
                    Description = s.Description,
                })
                .FirstOrDefault();
            }
        }
        public int Delete(PositionVM inputVM)
        {
            using (OBS_DBContext context = new OBS_DBContext())
            {
                long time = DateTime.Now.Ticks;

                return context.PositionDMs.Where(w => w.Id == inputVM.Id && w.Version == inputVM.Version)
                        .Update(u => new PositionDM
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
