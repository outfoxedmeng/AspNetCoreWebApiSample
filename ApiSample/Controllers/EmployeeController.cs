using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.Dto;
using ApiSample.Entity;
using ApiSample.QueryDto;
using ApiSample.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Controllers
{
    [Route("api/company/{companyId}/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;

        public EmployeeController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyService = companyService ?? throw new ArgumentNullException();
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<EmployeeDto>> GetCompanyEmployee(int companyId, int employeeId)
        {
            var employee = await _companyService.GetCompanyEmployeeAsync(companyId, employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            var eDto = _mapper.Map<EmployeeDto>(employee);

            return Ok(eDto);
        }

        [HttpGet]
        //注意，queryDto为复杂参数，ApiController默认其绑定源为body
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmpoyees(int companyId, [FromQuery] EmployeeQueryDto queryDto)
        {
            var employees = await _companyService.GetEmployeesAsync(companyId, queryDto);

            var result = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return Ok(result);
        }

    }
}
