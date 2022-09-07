using AutoMapper;
using Identity.Application.DataTransferModels.OutPutDtos;
using Identity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<PersonOutputDto, Person>().ReverseMap();
        }
    }
}
