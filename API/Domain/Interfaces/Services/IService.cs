using Domain.Models.Helps;
using System.Net;

namespace Domain.Interfaces.Services
{
    public interface IService
    {
        ResponseService GenerateErroServiceResponse
            (string message, HttpStatusCode status = HttpStatusCode.BadRequest);
        ResponseService<T> GenerateErroServiceResponse<T>
            (string message, HttpStatusCode status = HttpStatusCode.BadRequest);
        ResponseService GenerateSuccessServiceResponse
            (HttpStatusCode status = HttpStatusCode.OK);
        ResponseService<T> GenerateSuccessServiceResponse<T>
            (T value, HttpStatusCode status = HttpStatusCode.OK);
    }
}
