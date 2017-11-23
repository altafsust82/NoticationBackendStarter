using AutoMapper;
using NotificationBackend.Core;
using NotificationBackend.DAL.NotificationEntities;
using NotificationBackend.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationBackend.Models.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Add as many of these lines as you need to map your objects
            CreateMap<Users, UserBaseDto>().ReverseMap();
        }
    }  
}
