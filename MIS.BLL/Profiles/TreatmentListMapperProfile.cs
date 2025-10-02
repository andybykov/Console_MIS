using AutoMapper;
using MIS.Core.Dtos;
using MIS.Core.InputModels;
using MIS.Core.OutputModels;


namespace MIS.BLL.Profiles
{
    public class TreatmentListMapperProfile:Profile
    {
        public TreatmentListMapperProfile()
        {
            // Input to DTO
            CreateMap<TreatmentListInputModel, TreatmentListDto>();
                //.ForMember(d => d.Id, opt => opt.Ignore())   // БД сама назначит
                //.ForMember(d => d.ProcedureName, opt => opt.Ignore())   // приходят только Id
                //.ForMember(d => d.DrugName, opt => opt.Ignore())
                //.ForMember(d => d.DrugDose, opt => opt.Ignore())
                //.ForMember(d => d.DrugUnits, opt => opt.Ignore())
                //.ForMember(d => d.DrugComment, opt => opt.Ignore())
                //.ForMember(d => d.PatientName, opt => opt.Ignore())
                //.ForMember(d => d.DoctorName, opt => opt.Ignore())
                //.ForMember(d => d.PatientId, opt => opt.Ignore())   // берем из PatientDoctor
                //.ForMember(d => d.DoctorId, opt => opt.Ignore());  // 

            // DTO to Output
            CreateMap<TreatmentListDto, TreatmentListOutputModel>();
        }
    }
}