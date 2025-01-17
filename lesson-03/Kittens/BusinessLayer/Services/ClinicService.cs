﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstraction.Dto;
using BusinessLayer.Abstraction.Services;
using DataLayer.Abstraction.Repositories;


namespace BusinessLayer.Services
{
    public class ClinicService : IClinicService
    {
        private IClinicRepository _repository;

        public ClinicService(IClinicRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClinicDto> AddAsync(ClinicDto clinic)
        {
            return Mapper.Map(await _repository.AddAsync(Mapper.Map(clinic)));
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task<ClinicDto> GetByIdAsync(int id)
        {
            var clinic = await _repository.GetAsync(id);
            return Mapper.Map(clinic);
        }

        public async Task<IEnumerable<ClinicDto>> GetAsync(string search, int page, int size)
        {
            var result = await _repository.GetAsync(search, page, size);
            return result?.Select(k => Mapper.Map(k)).ToArray();
        }

        public async Task UpdateAsync(ClinicDto clinic)
        {
            await _repository.UpdateAsync(Mapper.Map(clinic));
        }
    }
}
