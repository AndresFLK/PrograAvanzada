﻿using AutoMapper;
using Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Students
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {

            CreateMap<CreateStudent, Student>().ForMember(destination => destination.PhoneNumber, source => source.MapFrom(s => s.MobileNumber));

            CreateMap<UpdateStudent, Student>().ForMember(destination => destination.Id, source => source.MapFrom(s => s.Id));
            
            CreateMap<Student, UpdateStudent>();

            CreateMap<Student, StudentDTO>().ConstructUsing(source => new StudentDTO(source.Id, source.Batch, string.Concat(source.FirstName, " ", source.LastName)));
        
        }
    }
}
