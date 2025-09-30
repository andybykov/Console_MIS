using AutoMapper;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;

namespace MIS.BLL.Profiles
{
    public class DrugMapperProfile:Profile
    {
        public DrugMapperProfile()
        {
            // на вход 2 типа даннымх source, destination т.е. откуда и куда перекладыать
            CreateMap<DrugDto, DrugOutputModel>();        

            CreateMap<DrugInputModel, DrugDto>(); // Маппинг для InputModel
        }

    }
}
