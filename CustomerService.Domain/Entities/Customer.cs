using CustomerService.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }

        public  Gender Gender { get; set; }


    }

    public enum Gender : int
    {
        Male = 0,
        Female = 1,
       
    }

}
