﻿using ProjectEntityFrameWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using ProjectEntityFrameWork.Training.BusinessObjects;
using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace ProjectEntityFrameWork.Areas.Admin.Models
{
    public class EditCourseModel
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        [Required,MaxLength(200)]
        public string Title { get; set; }
        [Required,Range(1000,50000,ErrorMessage ="Fees must be between 1000 and 50000")]
        public int Fees { get; set; }
        [Required,Range(typeof(DateTime),"1/1/1971","1/1/2045")]
        public DateTime StartDate { get; set; }
        public EditCourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }
        public EditCourseModel(ICourseService courseService,IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        public void LoadModelData(int id)
        {
            var course = _courseService.GetCourse(id);
            _mapper.Map(course,this);
        }

        public void Update()
        {
            var course = _mapper.Map<Course>(this);

            _courseService.Update(course);
        }
    }
}
