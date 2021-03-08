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
            var hasUserWithEmail = await _userRepository
                .GetAll(x => x.Crm == createUserInput.Crm);

            if (hasUserWithEmail != null && hasUserWithEmail.Any())
                return GenerateErroServiceResponse("A crm já está em uso.");

            if (createUserInput.Password != createUserInput.ConfirmPassword)
                return GenerateErroServiceResponse("As senhas não coincidem.");

            User newUser;
            switch (createUserInput.Role)
            {
                case DtoUserRoleType.Resident:
                    newUser = _mapper.Map<Resident>(createUserInput);
                    break;
                case DtoUserRoleType.Professor:
                    newUser = _mapper.Map<Professor>(createUserInput);
                    break;
                case DtoUserRoleType.Doctor:
                    newUser = _mapper.Map<Doctor>(createUserInput);
                    break;
                default:
                    return GenerateErroServiceResponse("O cargo informado não existe.");
            }
            newUser.Password = _cryptograph.EncryptPassword(newUser.Password);

            var createdUser = await _userRepository.Insert(newUser);
            try
            {
                await _userRepository.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return GenerateErroServiceResponse("Erro na criação do usuário.");
            }

            return GenerateSuccessServiceResponse(HttpStatusCode.Created);
        }
    }
}
