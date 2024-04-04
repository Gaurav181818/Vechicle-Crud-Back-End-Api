using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public  interface IVehicleRepository
    {
        IEnumerable<VehicleDTO> GetAll();
        VehicleDTO GetById(Guid id);
        VehicleDTO Create(VehicleDTO vehicle);
        VehicleDTO Update(VehicleDTO vehicle);
        void DeleteById(Guid id);
    }
}
