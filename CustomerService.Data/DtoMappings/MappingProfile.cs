using AutoMapper;
using CustomerService.Domain.Dtos;
using CustomerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.DtoMappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerNewDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
        }
    }
}
