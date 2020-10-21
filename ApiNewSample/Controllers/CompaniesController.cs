using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNewSample.DtoParameters;
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
        [HttpHead]//一个方法可以同时支持Get与Head，相同的是，方法都会正常执行；不同的是，HttpHead不用传输body内容。
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies(
            [FromQuery] CompanyDtoParameters parameters//复杂类型，默认从body绑定，因此需要手动指定从query绑定，否则415错误
            )
        {
            var companies = await _repository.GetCompaniesAsync(parameters);
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
