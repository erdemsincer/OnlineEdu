using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.SocialMediaDtos;
using OnlineEdu.DTO.DTOs.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericServis<Subscriber>_SubscriberService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _SubscriberService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _SubscriberService.TGetById(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteById(int id)
        {
            _SubscriberService.TDelete(id);
            return Ok("subscriber Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateSubscriberDto createSubscriberDto)
        {

            var newValue = _mapper.Map<Subscriber>(createSubscriberDto);
            _SubscriberService.TCreate(newValue);
            return Ok("Yeni subscriber  Alanı Oluşturuldu");


        }
        [HttpPut]

        public IActionResult Update(UpdateSubscriberDto updateSubscriberDto)
        {
            var value = _mapper.Map<Subscriber>(updateSubscriberDto);
            _SubscriberService.TUpdate(value);
            return Ok("subscriber alanı düzeltildi");

        }
    }
}
