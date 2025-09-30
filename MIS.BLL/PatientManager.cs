using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.BLL.Profiles;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;
using MIS.DAL;

namespace MIS.BLL
{
    public class PatientManager
    {
        private readonly PatientRepository _pRepository;
        private readonly Mapper _mapper;

        public PatientManager()
        {
            _pRepository = new PatientRepository();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PatientMapperProfile>();
            }, new LoggerFactory());

            _mapper = new Mapper(configuration);
        }

        public void AddPatient(PatientInputModel patient)
        {
            var dto = _mapper.Map<PatientDto>(patient);
            _pRepository.AddPatient(dto);
        }

        public PatientOutputModel GetPatientById(int id)
        {
            var dto = _pRepository.GetPatientById(id);
            return _mapper.Map<PatientOutputModel>(dto);
        }

        public List<PatientOutputModel> GetAllPatients()
        {
            var dtos = _pRepository.GetAllPatients();
            return _mapper.Map<List<PatientOutputModel>>(dtos);
        }

        public void UpdatePatientName(int id, PatientInputModel patient)
        {
            var dto = _mapper.Map<PatientDto>(patient);
            dto.Id = id;          // подменяем Id тем, что пришло в URL
            _pRepository.UpdatePatientName(dto);
        }

        public void DeletePatientById(int id)
        {           
            _pRepository.DeletePatientById(id);
        }
    }
}