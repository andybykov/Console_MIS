using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.BLL.Profiles;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;
using MIS.DAL;

namespace MIS.BLL
{
    public class DoctorManager
    {
        private DoctorRepository _doctorRepository;
        private Mapper _mapper;
        public DoctorManager()
        {
            // при создании класса создаем экземпляр DoctorRepository
            _doctorRepository = new DoctorRepository();

            // Создаем MapperConfiguration и передаем DoctorMapperProfile
            MapperConfiguration configuration = new MapperConfiguration((cfg =>
            {
                cfg.AddProfile(new DoctorMapperProfile());
            }), new LoggerFactory());

            _mapper = new Mapper(configuration);
        }

        public void AddDoctor(DoctorInputModel doctor)
        {
            var dto = _mapper.Map<DoctorDto>(doctor);
            _doctorRepository.AddDoctor(dto);

        }

        public DoctorOutputModel GetDoctorById(int id) //возвращаем OutputModel

        {
            //var p = _doctorRepository.GetDoctorById(id); // но метод возвравщет DTO,а не OutputModel
            // Можно решить это так:
            //DoctorOutputModel docOutput = new DoctorOutputModel();
            //{
            //    Id = p.Id;
            //    FullName = p.FirstName + p.LastName;
            //    // итд
            //};
            // С помощью mapper
            //var dr = _doctorRepository.GetDoctorById(id);

            //var docOutMod = _mapper.Map<DoctorOutputModel>(dr);

            //return docOutMod;
            var doctorDto = _doctorRepository.GetDoctorById(id);
            return _mapper.Map<DoctorOutputModel>(doctorDto);
        }

        public List<DoctorOutputModel> GetAllDoctors()
        {
            var doctorDto = _doctorRepository.GetAllDoctors();

            return _mapper.Map<List<DoctorOutputModel>>(doctorDto);
        }

        public void UpdateDoctor(DoctorInputModel doctor)
        {
            var dto = _mapper.Map<DoctorDto>(doctor);
            _doctorRepository.UpdateDoctor(dto);
        }

        public void DeleteDoctorById(int id)
        {
            _doctorRepository.DeleteDoctorById(id);

        }
    }
}
