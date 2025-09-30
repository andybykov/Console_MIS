using AutoMapper;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL.Profiles
{
    public class ProcedureMapperProfile:Profile
    {
        public ProcedureMapperProfile()
        {
            // на вход 2 типа даннымх source, destination т.е. откуда и куда перекладыать
            // мы можем преобразовывать Dto в OutputModel
            CreateMap<ProcedureDto, ProcedureOutputModel>();                
            CreateMap<ProcedureInputModel, ProcedureDto>(); // Маппинг для InputModel
        }
    }
}
