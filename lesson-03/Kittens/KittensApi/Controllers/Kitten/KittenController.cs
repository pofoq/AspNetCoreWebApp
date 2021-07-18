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
            response.Kittens = await _service.GetAsync(request.Search, request.Page, request.Size);
            return response;
        }

        [HttpGet("id/{id}")]
        public async Task<KittenDto> GetByIdAsync([FromRoute] int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpDelete]
        public async Task DeleteAsync([FromQuery] int id)
        {
            await _service.DeleteAsync(id);
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
            return await _service.AddAsync(serviceRequest);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] KittenDto kitten)
        {
            await _service.UpdateAsync(kitten);
        }

        [HttpPut("{catId}/clinic/{clinicId}")]
        public async Task AddClinicAsync([FromRoute] int catId, int clinicId)
        {
            await _service.AddClinicAsync(catId, clinicId);
        }

        [HttpGet("{catId}/clinic")]
        public async Task<KittenDto> GetClinicAsync([FromRoute] int catId)
        {
            return await _service.GetKittenClinicAsync(catId);
        }
    }
}
