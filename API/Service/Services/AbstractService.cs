using Domain.Interfaces.Services;
using Domain.Models.Helps;
using System.Net;

namespace Service.Services
{
    public abstract class AbstractService : IService
    {
        public ResponseService GenerateErroServiceResponse
            (string message, HttpStatusCode status = HttpStatusCode.BadRequest) =>
            new ResponseService
            {
                Message = message,
                Status = status,
                Success = false
            };
        public ResponseService<T> GenerateErroServiceResponse<T>
            (string message, HttpStatusCode status = HttpStatusCode.BadRequest) =>
            new ResponseService<T>
            {
                Message = message,
                Status = status,
                Success = false,
                Value = default
            };
        public ResponseService GenerateSuccessServiceResponse
            (HttpStatusCode status = HttpStatusCode.OK) =>
            new ResponseService
            {
                Success = true,
                Status = status,
                Message = string.Empty
            };
        public ResponseService<T> GenerateSuccessServiceResponse<T>
            (T value, HttpStatusCode status = HttpStatusCode.OK) =>
            new ResponseService<T>
            {
                Message = string.Empty,
                Status = status,
                Success = true,
                Value = value
            };
    }
}
