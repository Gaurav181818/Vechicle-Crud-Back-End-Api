using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Vehicle
    {
        public Guid ID { get; set; }

        public string CarModel { get; set; }

        public string CarMaker { get; set; }

        public string YearofMfg { get; set; }

        public string BasePrice { get; set; }
    }
}
