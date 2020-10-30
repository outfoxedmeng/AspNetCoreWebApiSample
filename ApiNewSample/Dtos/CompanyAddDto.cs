using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNewSample.Dtos
{
    //P21
    public class CompanyAddDto
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public string Product { get; set; }
        public string Introduction { get; set; }

        public DateTime? BankruptTime { get; set; }
    }
}
