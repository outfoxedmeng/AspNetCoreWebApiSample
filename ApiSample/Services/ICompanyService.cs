using ApiSample.Entity;
using ApiSample.QueryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Services
{
    public interface ICompanyService
    {
        public Task<IEnumerable<Company>> GetCompaniesAsync();
        public Task<Company> GetCompanyAsync(int companyId);

        public Task<Employee> GetCompanyEmployeeAsync(int companyId, int employeeId);

        public Task<IEnumerable<Employee>> GetEmployeesAsync(int companyId, EmployeeQueryDto queryDto);
    }
}
