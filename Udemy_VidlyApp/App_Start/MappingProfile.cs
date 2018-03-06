using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Udemy_VidlyApp.Dtos;
using Udemy_VidlyApp.Models;

namespace Udemy_VidlyApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

        }

    }
}