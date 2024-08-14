using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesCategoryController(IGenericServis<CourseCategory> _CourseCategoryService,IMapper _mapper) : ControllerBase
    {
       
            [HttpGet]
            public IActionResult Get()
            {
                var values = _CourseCategoryService.TGetList();
                return Ok(values);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var values = _CourseCategoryService.TGetById(id);
                return Ok(values);
            }

            [HttpDelete("{id}")]

            public IActionResult DeleteById(int id)
            {
                _CourseCategoryService.TDelete(id);
                return Ok("Course category Alanı Silindi");
            }
            [HttpPost]
            public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
            {

                var newValue = _mapper.Map<CourseCategory>(createCourseCategoryDto);
                _CourseCategoryService.TCreate(newValue);
                return Ok("Yeni Course category Alanı Oluşturuldu");


            }
            [HttpPut]

            public IActionResult Update(UpdateCourseCategoryDto updateCourseCategoryDto)
            {
                var value = _mapper.Map<CourseCategory>(updateCourseCategoryDto);
                _CourseCategoryService.TUpdate(value);
                return Ok("Course Category alanı düzeltildi");
            
        }
}
}
