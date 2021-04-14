using Moq;
using System;
using Xunit;
using Util.Cryptograph;
using Domain.Interfaces.Services;
using Service.Services;
using Domain.Interfaces.Repositories;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using Domain.Entities;
using Domain.Dtos.Inputs;
using Domain.ValueObjects;
using Domain.Dtos.Helps;
using System.Net;

namespace XUnitTestProject
{
    public class CreateUserServiceTests
    {
        private readonly CreateUserService _service;
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        
        public CreateUserServiceTests()
        {
            _service = new CreateUserService(
                _userRepositoryMock.Object,
                new SHA256Cryptograph(),
                null
            );
        }

        [Fact]
        public async Task CreateUserService_ShouldAddUser_WhenUserIsValid()
        {
            var name = "mockName";
            var password = "mockPassword";
            var crm = "mockCrm";
            var login = "mockLogin";
            var dto = new DtoCreateDoctorInput
            {
                CompleteName = name,
                Password = password,
                ConfirmPassword = password,
                Crm = crm,
                Login = login
            };
            var user = dto.ToUser();
            
            _userRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(Enumerable.Empty<User>().AsQueryable());
            _userRepositoryMock.Setup(x => x.Insert(user)).ReturnsAsync(new User());

            var response = await _service.Execute(dto);
            Console.WriteLine(response);

            Assert.Equal(HttpStatusCode.Created, response.Status);
        }

        [Fact]
        public async Task CreateUserService_ShouldReturnError_WhenUserIsInvalid()
        {
            var name = "mockName";
            var password = "mockPassword";
            var invalidConfirmPassword = "ockPasswordxD";
            var crm = "mockCrm";
            var login = "mockLogin";
            var dto = new DtoCreateDoctorInput
            {
                CompleteName = name,
                Password = password,
                ConfirmPassword = invalidConfirmPassword,
                Crm = crm,
                Login = login
            };
            var user = dto.ToUser();

            _userRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(Enumerable.Empty<User>().AsQueryable());
            _userRepositoryMock.Setup(x => x.Insert(user)).ReturnsAsync(new User());

            var response = await _service.Execute(dto);
            Console.WriteLine(response);

            Assert.Equal(HttpStatusCode.BadRequest, response.Status);
        }
    }
}
