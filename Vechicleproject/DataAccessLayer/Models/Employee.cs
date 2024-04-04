using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Employee
    {
        public Guid ID { get; set; }

        public string CarModel {  get; set; }

        public string CarMaker { get; set; }

        public DateTime YearofMfg { get; set; }

        public string BasePrice { get; set; }

    }
}
