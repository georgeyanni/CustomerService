using CustomerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Domain.Dtos
{
    public class CustomerUpdateDto
    {
       
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }

        public Gender Gender { get; set; }
    }
}
