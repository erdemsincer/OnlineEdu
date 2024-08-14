﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericServis<About> _aboutService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values=_aboutService.TGetList();
            return Ok(values); 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) { 
            var values=_aboutService.TGetById(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteById(int id) {
            _aboutService.TDelete(id);
            return Ok("Hakkımı<da Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateAboutDto createAboutDto) {

            var newValue=_mapper.Map<About>(createAboutDto);
            _aboutService.TCreate(newValue);
            return Ok("Yeni Hakkımızda Alanı Oluşturuldu");

       
        }
        [HttpPut]

        public IActionResult Update(UpdateAboutDto updateAboutDto) {
            var value=_mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(value);
            return Ok("Hakkımda alanı düzeltildi");
        }
    }
}
