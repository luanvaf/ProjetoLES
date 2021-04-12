using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Domain.Dtos.Helps;
using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.ValueObjects;

namespace Api.Core.Extensions.AutoMapper
{
    /// <summary>
    /// Responsável por registrar os mapeamentos de entidade para dto.
    /// </summary>
    public class ViewModelToEntityProfile : Profile
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ViewModelToEntityProfile()
        {
            CreateMap<DtoCreateResidentInput, Resident>()
                .ForMember(x => x.Name, y => y.MapFrom(src => src.CompleteName))
                .ForMember(x => x.Crm, y => y.MapFrom(src => src.Crm))
                .ForMember(x => x.Password, y => y.MapFrom(src => src.Password))
                .ForMember(x => x.ResidenceYear, y => y.MapFrom(src => src.ResidenceYear));

            CreateMap<DtoCreateProfessorInput, Professor>()
                .ForMember(x => x.Name, y => y.MapFrom(src => src.CompleteName))
                .ForMember(x => x.Crm, y => y.MapFrom(src => src.Crm))
                .ForMember(x => x.Password, y => y.MapFrom(src => src.Password));

            CreateMap<DtoCreateDoctorInput, Doctor>()
                .ForMember(x => x.Name, y => y.MapFrom(src => src.CompleteName))
                .ForMember(x => x.Crm, y => y.MapFrom(src => src.Crm))
                .ForMember(x => x.Password, y => y.MapFrom(src => src.Password));

            CreateMap<DtoResidenceYearType, ResidenceYear>()
                .ConvertUsingEnumMapping(opt => opt
                        .MapValue(DtoResidenceYearType.FirstYear, ResidenceYear.FirstYear)
                        .MapValue(DtoResidenceYearType.SecondYear, ResidenceYear.SecondYear)
                        .MapValue(DtoResidenceYearType.ThirdYear, ResidenceYear.ThirdYear)
                        .MapValue(DtoResidenceYearType.ForthYear, ResidenceYear.ForthYear))
                .ReverseMap();

            CreateMap<DtoAddMedicalEquipamentInput, MedicalEquipament>();
        }
    }
}
