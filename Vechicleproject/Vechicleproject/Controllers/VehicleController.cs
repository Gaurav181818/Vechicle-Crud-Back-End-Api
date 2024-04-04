using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Contracts;
using BusinessLogicLayer.Implementation;
using DataAccessLayer.DTO;
using Microsoft.Extensions.Logging;


namespace Vechicleproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IMapper _mapper;




        public VehicleController(IVehicleService vehicleService, IMapper mapper)

        {
            _vehicleService = vehicleService;
            _mapper = mapper;

            
        }

        [Route("GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<VehicleDTO>> GetAll()
        {
           
            try
            {
                var vehicles = _vehicleService.GetAll();
                if (vehicles == null)
                {
                    return NotFound();
                }
                return Ok(vehicles);
            }
            catch (Exception)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("GetById")]
        [HttpGet]

        public ActionResult GetById(Guid id) 
        {
            try
            {
                var vehicle = _vehicleService.GetById(id);

                if (vehicle == null)
                {
                    return NotFound();
                }

                return Ok(vehicle);
            }
            catch (Exception ex)
            {
         
                return StatusCode(500, "Internal server error");
            }



        }


        [Route("Create")]
        [HttpPost]
        public VehicleDTO Create([FromBody] VehicleDTO vehicle)
        {
            var vehicles = _mapper.Map<VehicleDTO>(vehicle);
            return _vehicleService.Create(vehicles);
        }



        [Route("Delete/{id}")]
        [HttpDelete]
        public ActionResult DeleteById(Guid id)
        {
            var existingVehicle = _vehicleService.GetById(id);

            if (existingVehicle == null)
            {
                return NotFound();
            }

            _vehicleService.DeleteById(id);

            return Ok(new { Message = "Vehicle deleted successfully" });
        }




        [Route("Update")]
        [HttpPut]
        public ActionResult Update(VehicleDTO vehicleDTO)
        {
            var vehicle = _mapper.Map<VehicleDTO>(vehicleDTO);
            _vehicleService.Update(vehicle);
            return Ok(new { Message = "Vehicle updated successfully" });
        }

        [HttpPut("Update/{id}")]
        public ActionResult<VehicleDTO> Update(Guid id, [FromBody] VehicleDTO vehicle)
        {
            try
            {
                var existingVehicle = _vehicleService.GetById(id);
                if (existingVehicle == null)
                {
                    return NotFound($"Vehicle with ID {id} not found.");
                }

                vehicle.ID = id;
                var employeeDTO = _mapper.Map<VehicleDTO>(vehicle);
                _vehicleService.Update(vehicle);
                return Ok(new { Message = "Vehicle updated successfully" });
            }
            catch (Exception ex)
            {
              
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

    }
}
