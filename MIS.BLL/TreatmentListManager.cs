using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.BLL.Profiles;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;
using MIS.DAL;

namespace MIS.BLL
{
    public class TreatmentListManager
    {
        private readonly TreatmentListRepository _repository;
        private readonly Mapper _mapper;

        public TreatmentListManager()
        {
            _repository = new TreatmentListRepository();

            var cfg = new MapperConfiguration(c =>
            {
                c.AddProfile<TreatmentListMapperProfile>();
            }, new LoggerFactory());

            _mapper = new Mapper(cfg);
        }

        public int AddTreatmentList(TreatmentListInputModel inputModel)
        {
            var dto = _mapper.Map<TreatmentListDto>(inputModel);
            return _repository.AddTreatmentList(dto);
        }

        public TreatmentListOutputModel GetTreatmentListById(int id)
        {
            var dto = _repository.GetTreatmentListById(id);
            return _mapper.Map<TreatmentListOutputModel>(dto);
        }

        public List<TreatmentListOutputModel> GetAllTreatmentLists()
        {
            var dtos = _repository.GetAllTreatmentLists();
            return _mapper.Map<List<TreatmentListOutputModel>>(dtos);
        }

        public List<TreatmentListOutputModel> GetTreatmentListsByDoctorId(int doctorId)
        {
            var dtos = _repository.GetTreatmentListsByDoctorId(doctorId);
            return _mapper.Map<List<TreatmentListOutputModel>>(dtos);
        }

        public List<TreatmentListOutputModel> GetTreatmentListsByPatientId(int patientId)
        {
            var dtos = _repository.GetAllTreatmentListsByPatientId(patientId);
            return _mapper.Map<List<TreatmentListOutputModel>>(dtos);
        }

        public void UpdateTreatmentList(TreatmentListInputModel inputModel)
        {
            var dto = _mapper.Map<TreatmentListDto>(inputModel);            
            _repository.UpdateTreatmentList(dto);
        }

        public void DeleteTreatmentListById(int id)
        {
            _repository.DeleteTreatmentListById(id);
        }

        public int CreatePatientDoctorId(TreatmentListInputModel inputModel)
        {
            var dto = _mapper.Map<TreatmentListDto>(inputModel);
            //Console.WriteLine($"[BLL] PatientId = {dto.PatientId}, DoctorId = {dto.DoctorId}");
            var res = _repository.CreatePatientDoctorId(dto);        
            return res;
        }       
    }
}