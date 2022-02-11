using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstraction.Services;
using BusinessLayer.Abstraction.Dto;
using System.Collections.Generic;
using KittensApi.Controllers.Clinic.Requests;

namespace KittensApi.Controllers.Clinic
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private IClinicService _service;

        public ClinicController(IClinicService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ClinicDto>> GetAsync([FromQuery] GetClinicRequest request)
        {
            return await _service.GetAsync(request.Search, request.Page, request.Size);
        }

        [HttpGet("id/{id}")]
        public async Task<ClinicDto> GetByIdAsync([FromRoute] int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpDelete("id/{id}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
        }

        [HttpPost]
        public async Task<ClinicDto> AddAsync([FromBody] AddClinicRequest request)
        {
            var serviceRequest = new ClinicDto()
            {
                Name = request.Name
            };
            return await _service.AddAsync(serviceRequest);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] ClinicDto clinic)
        {
            await _service.UpdateAsync(clinic);
        }
    }
}
