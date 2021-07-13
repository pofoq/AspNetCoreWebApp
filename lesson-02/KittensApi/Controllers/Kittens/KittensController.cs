using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using KittensApi.Controllers.Kittens.Requests;
using KittensApi.Controllers.Kittens.Responses;
using DataLayer.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KittensApi.Controllers.Kittens
{
    [Route("api/[controller]")]
    [ApiController]
    public class KittensController : ControllerBase
    {
        private readonly IKittensRepository _dataProvider;

        // GET: api/<KittensController>
        [HttpGet]
        public GetAllKittensResponse Get()
        {
            var dalResult = _dataProvider.GetKittens();
            var response = new GetAllKittensResponse();
            response.Kittens = dalResult.Kittens.Select(k => new Dto.KittenDto() 
            {
                Id = k.Id,
                NickName = k.NickName,
                Weight = k.Weight,
                Color = k.Color,
                HasCirtificate = k.HasCirtificate,
                Feed = k.Feed
            });
            return response;
        }

        // GET api/<KittensController>/5
        [HttpGet("{id}")]
        public Dto.KittenDto Get(int id)
        {
            var model = _dataProvider.GetKittenById(id);
            var response = new Dto.KittenDto()
            {
                Id = model.Id,
                NickName = model.NickName,
                Weight = model.Weight,
                Color = model.Color,
                HasCirtificate = model.HasCirtificate,
                Feed = model.Feed
            };
            return response;
        }

        // POST api/<KittensController>
        [HttpPost]
        public void Post([FromBody] PostRequest request)
        {
            var dalRequest = new DataLayer.Requests.SaveKittenRequest()
            {
                NickName = request.NickName,
                Weight = request.Weight,
                Color = request.Color,
                HasCirtificate = request.HasCirtificate,
                Feed = request.Feed
            };
            _dataProvider.SaveKitten(dalRequest);
        }
    }
}
