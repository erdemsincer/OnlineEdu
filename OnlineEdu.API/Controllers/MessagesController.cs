﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.DTO.DTOs.MessageDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IGenericServis<Message>_messageService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _messageService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var values = _messageService.TGetById(id);
            return Ok(values);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteById(int id)
        {
            _messageService.TDelete(id);
            return Ok("Message  Alanı Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateMessageDto createMessageDto)
        {

            var newValue = _mapper.Map<Message>(createMessageDto);
            _messageService.TCreate(newValue);
            return Ok("Yeni Message  Alanı Oluşturuldu");


        }
        [HttpPut]

        public IActionResult Update(UpdateMessageDto updateMessageeDto)
        {
            var value = _mapper.Map<Message>(updateMessageeDto);
            _messageService.TUpdate(value);
            return Ok("Message  alanı düzeltildi");


        }
    }
}
