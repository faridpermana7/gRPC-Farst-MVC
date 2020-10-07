using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcFarstMvc.Models
{
    public class EmployeeDTO
    {
        public long EmployeeID { get; set; }
        public string NIK { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
    }
}
