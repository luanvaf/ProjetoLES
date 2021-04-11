using AutoMapper;
using Domain.Dtos.Helps;
using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Util;
using Domain.Models.Helps;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CreateUserService : AbstractService, ICreateUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptograph _cryptograph;
        private readonly IMapper _mapper;
        public CreateUserService(IUserRepository userRepository,
                                 ICryptograph cryptograph,
                                 IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _cryptograph = cryptograph;
        }
        /// <summary>
        /// Método responsável por criar o usuário
        /// </summary>
        /// <param name="createUserInput"></param>
        /// <returns></returns>
        public async Task<ResponseService> Execute<T>(T createUserInput)
            where T : DtoCreateUserInput
        {
            var hasUserWithLogin = await _userRepository
                .GetAll(x => x.Login == createUserInput.Login);

            if (hasUserWithLogin != null && hasUserWithLogin.Any())
                return GenerateErroServiceResponse("A login já está em uso.");

            if (createUserInput.Password != createUserInput.ConfirmPassword)
                return GenerateErroServiceResponse("As senhas não coincidem.");

            User newUser = createUserInput.ToUser();

            newUser.Password = _cryptograph.EncryptPassword(newUser.Password);

            var createdUser = await _userRepository.Insert(newUser);

            return GenerateSuccessServiceResponse(HttpStatusCode.Created);
        }
    }
}
