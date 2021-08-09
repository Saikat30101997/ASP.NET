using AutoMapper;
using ProjectEntityFrameWork.Areas.Admin.Models;
using ProjectEntityFrameWork.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEntityFrameWork.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<CreateCourseModel, Course>().ReverseMap();
            CreateMap<EditCourseModel, Course>().ReverseMap();
        }
    }
}
