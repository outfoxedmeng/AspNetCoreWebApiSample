using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNewSample.Dtos;
using ApiNewSample.Entities;
using ApiNewSample.Helper;
using ApiNewSample.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiNewSample.Controllers
{
    [Route("api/companycollections")]
    [ApiController]
    public class CompanyCollectionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _repository;

        public CompanyCollectionsController(IMapper mapper, ICompanyRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        [HttpGet("({ids})", Name = nameof(GetCompanyCollections))]
        public async Task<IActionResult> GetCompanyCollections([FromRoute][ModelBinder(binderType: typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            //注意：null值判断
            if (ids == null)
            {
                return BadRequest();
            }

            var companies = await _repository.GetCompaniesAsync(ids);

            //注意：ids的长度要与数据个数对应，否则返回404
            if (ids.Count() != companies.Count())
            {
                return NotFound();
            }

            var companyDtos = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companyDtos);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCompanies(IEnumerable<CompanyAddDto> addDtos)
        {
            var companies = _mapper.Map<IEnumerable<Company>>(addDtos);

            foreach (var c in companies)
            {
                _repository.AddCompany(c);
            }
            await _repository.SaveChangesAsync();


            var dtosToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            var idsString = string.Join(',', dtosToReturn.Select(x => x.Id));

            return CreatedAtRoute(nameof(GetCompanyCollections), new { ids = idsString }, dtosToReturn);
        }


    }
}
