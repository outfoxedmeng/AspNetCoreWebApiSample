using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNewSample.Dtos;
using ApiNewSample.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNewSample.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await _repository.GetCompaniesAsync();
            var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return Ok(companyDtos);
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetCompany(int companyId)
        {
            var company = await _repository.GetCompanyAsync(companyId);

            if (company == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CompanyDto>(company));
        }
    }
}
