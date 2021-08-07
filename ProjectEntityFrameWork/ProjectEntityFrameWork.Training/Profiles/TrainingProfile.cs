using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = ProjectEntityFrameWork.Training.Entities;
using BO = ProjectEntityFrameWork.Training.BusinessObjects;

namespace ProjectEntityFrameWork.Training.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<EO.Course, BO.Course>().ReverseMap();
        }
    }
}
