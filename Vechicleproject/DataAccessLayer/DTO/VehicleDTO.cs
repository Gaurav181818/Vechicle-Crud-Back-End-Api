using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;



namespace DataAccessLayer.DTO
{
    public class VehicleDTO
    {
        public Guid ID { get; set; }

        public string CarModel { get; set; }

        public string CarMaker { get; set; }

        public string YearofMfg { get; set; }

        public string BasePrice { get; set; }
    }
}
