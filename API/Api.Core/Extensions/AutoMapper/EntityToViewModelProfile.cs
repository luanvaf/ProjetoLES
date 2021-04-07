using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Entities;

namespace Api.Core.Extensions.AutoMapper
{
    /// <summary>
    /// Responsável por registrar os mapeamentos de entidade para dto.
    /// </summary>
    public class EntityToViewModelProfile : Profile
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EntityToViewModelProfile()
        {
            CreateMap<DtoCreatePatientInput, Patient>();
            CreateMap<DtoAddress, Address>();
        }
    }
}
