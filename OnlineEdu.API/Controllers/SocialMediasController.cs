using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.MessageDtos;
using OnlineEdu.DTO.DTOs.SocialMediaDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController(IGenericServis<SocialMedia>SocialMediaService_,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = SocialMediaService_.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = SocialMediaService_.TGetById(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteById(int id)
        {
            SocialMediaService_.TDelete(id);
            return Ok("Sosyal Media  Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateSocialMediaDto createSocialMediaDto)
        {

            var newValue = _mapper.Map<SocialMedia>(createSocialMediaDto);
            SocialMediaService_.TCreate(newValue);
            return Ok("Yeni Sosyal Media  Alanı Oluşturuldu");


        }
        [HttpPut]

        public IActionResult Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            SocialMediaService_.TUpdate(value);
            return Ok("Sosyal Media  alanı düzeltildi");

        }
    }
}
