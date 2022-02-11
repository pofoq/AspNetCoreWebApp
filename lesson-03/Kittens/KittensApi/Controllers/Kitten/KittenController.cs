using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KittensApi.Controllers.Kitten.Responses;
using KittensApi.Controllers.Kitten.Requests;
using BusinessLayer.Abstraction.Services;
using BusinessLayer.Abstraction.Dto;

namespace KittensApi.Controllers.Kitten
{
    [Route("api/[controller]")]
    [ApiController]
    public class KittenController : ControllerBase
    {
        private IKittenService _service;

        public KittenController(IKittenService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<GetKittenResponse> GetAsync([FromQuery] GetKittenRequest request)
        {
            var response = new GetKittenResponse();
            response.Kittens = await _service.GetKittensAsync(request.Serach, request.Page, request.Size);
            return response;
        }

        [HttpGet("id/{id}")]
        public async Task<KittenDto> GetByIdAsync([FromRoute] int id)
        {
            return await _service.GetKittenByIdAsync(id);
        }

        [HttpDelete]
        public async Task DeleteAsync([FromQuery] int id)
        {
            await _service.DeleteKittenAsync(id);
        }

        [HttpPost]
        public async Task<KittenDto> AddAsync([FromBody] AddKittenRequest request)
        {
            var serviceRequest = new KittenDto()
            {
                Color = request.Color,
                HasCirtificate = request.HasCirtificate,
                Feed = request.Feed,
                NickName = request.NickName,
                Weight = request.Weight
            };
            return await _service.AddKittenAsync(serviceRequest);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] KittenDto kitten)
        {
            await _service.UpdateKittenAsync(kitten);
        }
    }
}
