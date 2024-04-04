using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DTO;
using DataAccessLayer.Models;


namespace DataAccessLayer.Mapper
{
    public  class VehicleProfile:Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDTO>();


        }
    }
}
