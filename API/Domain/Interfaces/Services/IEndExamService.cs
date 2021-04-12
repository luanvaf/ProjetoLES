using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Models.Helps;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEndExamService : IService
    {
        Task<ResponseService<MedicalExam>> Execute(Guid userId, DtoEndExamInput input);
    }
}
