﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(IGenericServis<Course> _courseService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _courseService.TGetById(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteById(int id)
        {
            _courseService.TDelete(id);
            return Ok("Course  Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {

            var newValue = _mapper.Map<Course>(createCourseDto);
            _courseService.TCreate(newValue);
            return Ok("Yeni Course  Alanı Oluşturuldu");


        }
        [HttpPut]

        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var value = _mapper.Map<Course>(updateCourseDto);
            _courseService.TUpdate(value);
            return Ok("Course  alanı düzeltildi");


        }
    }
}
