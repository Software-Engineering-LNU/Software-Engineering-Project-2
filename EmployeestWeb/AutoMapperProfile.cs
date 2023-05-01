namespace EmployeestWeb
{
    using AutoMapper;
    using EmployeestWeb.BLL.Models;
    using EmployeestWeb.DAL.Models;
    using EmployeestWeb.Models;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<AddEmployeeViewModel, User>().ReverseMap();
            this.CreateMap<Models.FireEmployeeModel, User>().ReverseMap();
            this.CreateMap<Models.FireEmployeeModel, BLL.Models.FireEmployeeModel>().ReverseMap();
        }
    }
}
