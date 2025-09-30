using AutoMapper;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;

namespace MIS.BLL.Profiles
{
    public class PatientMapperProfile:Profile
    {
        public PatientMapperProfile()
        {
            // на вход 2 типа даннымх source, destination т.е. откуда и куда перекладыать
            // мы можем преобразовывать Dto в OutputModel
            CreateMap<PatientDto, PatientOutputModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}".Trim()));
            CreateMap<PatientInputModel, PatientDto>(); // Маппинг для InputModel
        }
    }
}
