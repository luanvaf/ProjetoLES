using AutoMapper;
using Domain.Dtos.Inputs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models.Helps;
using System;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AddMedicalEquipamentService : AbstractService, IAddMedicalEquipamentService
    {
        private readonly IMedicalEquipamentRepository _medicalEquipamentRepository;
        private readonly IMapper _mapper;
        public AddMedicalEquipamentService(IMedicalEquipamentRepository medicalConsultationRepository,
                                    IMapper mapper)
        {
            _medicalEquipamentRepository = medicalConsultationRepository;
            _mapper = mapper;
        }
        public async Task<ResponseService<MedicalEquipament>> Execute(DtoAddMedicalEquipamentInput equipament)
        {
            var newEquipament = _mapper.Map<MedicalEquipament>(equipament);

            try
            {
                var createdEquipament = await _medicalEquipamentRepository.Insert(newEquipament);

                return GenerateSuccessServiceResponse(createdEquipament);
            }
            catch
            {
                return GenerateErroServiceResponse<MedicalEquipament>("Erro ao adicionar novo equipamento.");
            }

        }
    }
}
