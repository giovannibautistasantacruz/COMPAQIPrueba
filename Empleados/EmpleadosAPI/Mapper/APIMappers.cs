using AutoMapper;
using EmpleadosAPI.Models;
using EmpleadosAPI.Models.DTO;

namespace EmpleadosAPI.Mapper
{
    public class APIMappers: Profile
    {
        public APIMappers() {

            CreateMap<Empleado, EmpleadoDTO>().ReverseMap();
            CreateMap<EmpleadoDTO, Empleado>().ReverseMap();

        }
    }
}
