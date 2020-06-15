using AutoMapper;
using Common;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiJwtProj1
{
    class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDTO>(); // means you want to map from User to UserDTO
        }
    }
}
