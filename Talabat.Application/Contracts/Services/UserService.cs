using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Contracts.Interfaces;
using Talabat.Application.DTO.User;
using Talabat.Application.Repository.Interfaces;

namespace Talabat.Application.Contracts.Services
{
    public class UserService : IuserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository _userRepository, IMapper mapper) 
        {
            userRepository = _userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDTO> CreateUser(CreateUserDTO userDTO, IEnumerable<string>? roles)
        {
            var user = await userRepository.createUser(userDTO);

            var response = _mapper.Map<UserResponseDTO>(user);
            return response;


        }
    }
}
