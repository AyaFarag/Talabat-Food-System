using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.DTO.User;
using Talabat.Infrastructure.Models;

namespace Talabat.Infrastructure.Automapper
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<ApplicationUser, CreateUserDTO>()
              .ReverseMap();

            CreateMap<ApplicationUser, UserResponseDTO>()
              .ReverseMap();

        }
    }
}
