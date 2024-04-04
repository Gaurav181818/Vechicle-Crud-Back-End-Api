using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Contracts;
using DataAccessLayer.DTO;
using DataAccessLayer.IRepository;

namespace BusinessLogicLayer.Implementation
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository VehicleRepository, IMapper mapper)
        {
            _vehicleRepository = VehicleRepository;
            _mapper = mapper;
        }


        public VehicleDTO Create(VehicleDTO vehicleDTO)
        {
            var vehicles = _mapper.Map<VehicleDTO>(vehicleDTO);
            _vehicleRepository.Create(vehicles);

            return vehicleDTO;
        }

        public void DeleteById(Guid id)
        {
            _vehicleRepository.DeleteById(id);
        }

        public IEnumerable<VehicleDTO> GetAll()
        {
            var vehicle = _vehicleRepository.GetAll();
            return _mapper.Map<IEnumerable<VehicleDTO>>(vehicle);
        }

        public VehicleDTO GetById(Guid id)
        {
            var vehicleModel = _vehicleRepository.GetById(id);

            if (vehicleModel == null)
            {
                return null;
            }

            var vehicle = _mapper.Map<VehicleDTO>(vehicleModel);
            return vehicle;
        }

        public void Update(VehicleDTO vehicle)
        {
            var vehicleModel = _mapper.Map<VehicleDTO>(vehicle);
            _vehicleRepository.Update(vehicleModel);
        }
    }
}
