using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.SubscriberDtos;
using OnlineEdu.DTO.DTOs.TestimonialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IGenericServis<Testimonial>_TesimonialService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _TesimonialService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _TesimonialService.TGetById(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteById(int id)
        {
            _TesimonialService.TDelete(id);
            return Ok("Testimonial Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateTestimonialDto createTestimonialDto)
        {

            var newValue = _mapper.Map<Testimonial>(createTestimonialDto);
            _TesimonialService.TCreate(newValue);
            return Ok("Yeni Testimonial  Alanı Oluşturuldu");


        }
        [HttpPut]

        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _TesimonialService.TUpdate(value);
            return Ok("Testimonial alanı düzeltildi");

        }
    }
}
