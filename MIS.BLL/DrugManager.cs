using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.BLL.Profiles;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;
using MIS.DAL;

namespace MIS.BLL
{
    public class DrugManager
    {
        private DrugRepository _dRepository;
        private Mapper _mapper;

        // Конструктор
        public DrugManager()
        {
            // при создании класса создаем экземпляр DoctorRepository
            // это не создавать DoctorRepository, в каждом следующем методе
            _dRepository = new DrugRepository();

            // Создаем MapperConfiguration и передаем DoctorMapperProfile
            MapperConfiguration configuration = new MapperConfiguration((cfg => {
                cfg.AddProfile(new DrugMapperProfile());
            }), new LoggerFactory());

            _mapper = new Mapper(configuration);
        }

        public void AddDrug(DrugInputModel drug)
        {
            var dto = _mapper.Map<DrugDto>(drug);
            _dRepository.AddDrug(dto);

        }

        public DrugOutputModel GetDrugById(int id) //возвращаем OutputModel

        {           
            var dto = _dRepository.GetDrugById(id);
            return _mapper.Map<DrugOutputModel>(dto);
        }

        public List<DrugOutputModel> GetAllDrugs()
        {
            var dto = _dRepository.GetAllDrugs();
            return _mapper.Map<List<DrugOutputModel>>(dto);
        }

        public void UpdateDrug(DrugInputModel drug)
        {
            var dto = _mapper.Map<DrugDto>(drug);
            _dRepository.UpdateDrug(dto);
        }

        public void DeleteDrugById(int id)
        {
            _dRepository.DeleteDrugById(id);
        }
    }
}
