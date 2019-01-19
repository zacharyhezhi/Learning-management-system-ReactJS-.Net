using AutoMapper;
using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.App_Start
{
    public class AutomapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Course, CourseDto>();
                config.CreateMap<Student, StudentDto>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)); ;
                config.CreateMap<Lecturer, LecturerDto>();
            });
        }
    }
}