using System;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Secure_API.Models.Domain;
using Secure_API.Models.DTO;

namespace Secure_API.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //ReverseMap() is used in case if we want to map DTO to the Domain Model
            CreateMap<Secure_API.Models.Domain.Request, RequestDTO>()
                .ReverseMap();

            CreateMap<Secure_API.Models.Domain.Request, GetRequestDTO>()
                .ReverseMap();

            CreateMap<Secure_API.Models.Domain.Visitor, VisitorDTO>()
                .ReverseMap();

            CreateMap<Secure_API.Models.Domain.User, GetUserDTO>()
                .ReverseMap();

            CreateMap<Secure_API.Models.Domain.User, UserDTO>()
                .ReverseMap();

            CreateMap<Secure_API.Models.Domain.Request, EditRequestDTO>()
                .ReverseMap();
        }
    }
}