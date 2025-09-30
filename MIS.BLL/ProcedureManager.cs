using AutoMapper;
using Microsoft.Extensions.Logging;
using MIS.BLL.Profiles;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;
using MIS.DAL;

namespace MIS.BLL
{
    public class ProcedureManager
    {
        private readonly ProcedureRepository _repository;
        private readonly Mapper _mapper;

        public ProcedureManager()
        {
            _repository = new ProcedureRepository();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProcedureMapperProfile>();
            }, new LoggerFactory());

            _mapper = new Mapper(configuration);
        }

        public int AddProcedure(ProcedureInputModel input)
        {
            var dto = _mapper.Map<ProcedureDto>(input);
            return _repository.AddProcedure(dto);
        }

        public ProcedureOutputModel GetProcedureById(int id)
        {
            var dto = _repository.GetProcedureById(id);
            return _mapper.Map<ProcedureOutputModel>(dto);
        }

        public List<ProcedureOutputModel> GetAllProcedures()
        {
            var dtos = _repository.GetAllProcedures();
            return _mapper.Map<List<ProcedureOutputModel>>(dtos);
        }

        public void UpdateProcedure(int id, ProcedureInputModel input)
        {
            var dto = _mapper.Map<ProcedureDto>(input);
            dto.Id = id;
            _repository.UpdateProcedure(dto);
        }

        public void DeleteProcedure(int id)
        {
            _repository.DeleteProcedure(id);
        }
    }
}