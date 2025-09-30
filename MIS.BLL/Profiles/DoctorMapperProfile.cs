using AutoMapper;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;

namespace MIS.BLL.Profiles
{
    public class DoctorMapperProfile:Profile // явно наследуем от класса Profile
    {
        // Можем описать конструктор DoctorMapperProfile 
        // внутри котого вызывать методы Profile,гланвый метод - CreateMap()
        public DoctorMapperProfile() 
        {
            // на вход 2 типа даннымх source, destination т.е. откуда и куда перекладыать
            CreateMap<DoctorDto, DoctorOutputModel>()
                .ForMember(
                dest => dest.FullName, // куда
                opt => opt.MapFrom(
                        src => $"{src.FirstName}" +
                               $" {src.LastName}"
                                   )); // откуда; // мы можем преобразовывать DoctorDto в DoctorOutputModel

            CreateMap<DoctorInputModel, DoctorDto>(); // Маппинг для InputModel
        }

        

    }
}
