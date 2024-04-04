using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DTO;

namespace BusinessLogicLayer.Contracts
{
     public interface  IVehicleService
    {
        IEnumerable<VehicleDTO> GetAll();
        VehicleDTO GetById(Guid id);
        VehicleDTO Create(VehicleDTO vehicle);
        void Update(VehicleDTO vehicle);
        void DeleteById(Guid id);
    }
}
