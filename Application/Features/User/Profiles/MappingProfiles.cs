using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umb.Application.Features.User.Dtos;

namespace Umb.Application.Features.User.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //GetAll

            CreateMap<List<Umb.Domain.User>, GetUserDto>().ReverseMap();


        }
    }
}
