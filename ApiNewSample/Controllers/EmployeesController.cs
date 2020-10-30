using ApiNewSample.Dtos;
using ApiNewSample.Entities;
using ApiNewSample.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNewSample.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _repository;

        public EmployeesController(IMapper mapper, ICompanyRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }



        [HttpGet(Name = nameof(GetEmployees))]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees(int companyId, string genderDisplay, string q)
        {
            //检测父关系数据是否存在  P13
            if (!await _repository.CompanyExistsAsync(companyId))
            {
                return NotFound();
            }
            var employees = await _repository.GetEmployeesAsync(companyId, genderDisplay, q);
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet(template: "{employeeId}", Name = nameof(GetEmployee))]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int companyId, int employeeId)
        {
            var employee = await _repository.GetEmployeeAsync(companyId, employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(int companyId, EmployeeCreateDto employeeCreateDto)
        {
            if (!await _repository.CompanyExistsAsync(companyId))
            {
                return NotFound();
            }

            var employee = _mapper.Map<Employee>(employeeCreateDto);

            _repository.AddEmployee(companyId, employee);

            await _repository.SaveChangesAsync();

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return CreatedAtRoute(nameof(GetEmployee),
                new
                {
                    companyId,
                    employeeId = employee.Id //注意此匿名类中的参数名一定要对应正确
                },
                employeeDto);

        }

    }
}
