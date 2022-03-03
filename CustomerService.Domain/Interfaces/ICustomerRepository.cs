using CustomerService.Domain.Entities;
using CustomerService.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Domain.Interfaces
{
    public interface ICustomerRepository: IGenericRepository<Customer>
    {


    }
}
