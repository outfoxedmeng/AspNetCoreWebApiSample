using ApiSample.Data;
using ApiSample.Entity;
using ApiSample.QueryDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSample.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly MyDbContext _dbContext;

        public CompanyService(MyDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _dbContext.Set<Company>().ToListAsync();
        }

        public async Task<Company> GetCompanyAsync(int companyId)
        {
            return await _dbContext.Set<Company>().FindAsync(companyId);
        }

        public async Task<Employee> GetCompanyEmployeeAsync(int companyId, int employeeId)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.CompanyId == companyId && e.Id == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int companyId, EmployeeQueryDto queryDto)
        {
            var query = _dbContext.Employees.Where(e => e.CompanyId == companyId);

            if (!string.IsNullOrWhiteSpace(queryDto?.Name))
            {
                queryDto.Name = queryDto.Name.Trim();

                query = query.Where(e => e.Name.Contains(queryDto.Name));
            }

            if (!string.IsNullOrWhiteSpace(queryDto?.Gender))
            {
                var gender = Enum.Parse<Gender>(queryDto.Gender.Trim(),true);
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }
    }
}
