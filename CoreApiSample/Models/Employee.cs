using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiSample.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocationName { get; set; }
        public string DesignationName { get; set; }
        public int DesignationId { get; set; }
        public int LocationId { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
    }
}
