using ApiNewSample.Data;
using ApiNewSample.DtoParameters;
using ApiNewSample.Entities;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNewSample.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly RoutineDbContext _dbContext;

        public CompanyRepository(RoutineDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Company>> GetCompaniesAsync(CompanyDtoParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
            var query = _dbContext.Companies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                query = query.Where(x => x.Name.Contains(parameters.Name.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                var term = parameters.SearchTerm.Trim();
                query = query.Where(x => x.Product.Contains(term)
                                        || x.Industry.Contains(term));

            }

            var res = await query.ToListAsync();
            return res;

        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<int> companyIds)
        {
            if (companyIds == null)
            {
                throw new ArgumentNullException(nameof(companyIds));
            }
            return await _dbContext.Companies
                .Where(c => companyIds.Contains(c.Id))
                .ToListAsync();
        }

        public async Task<Company> GetCompanyAsync(int componyId)
        {

            return await _dbContext.Companies.FindAsync(componyId);
        }

        public async Task<bool> CompanyExistsAsync(int companyId)
        {
            return await _dbContext.Companies.AnyAsync(c => c.Id == companyId);

        }

        public void AddCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            _dbContext.Add<Company>(company);
        }

        public void AddEmployee(int companyId, Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            employee.CompanyId = companyId;
            _dbContext.Add<Employee>(employee);
        }



        public void DeleteCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            _dbContext.Remove<Company>(company);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _dbContext.Remove<Employee>(employee);
        }


        public async Task<Employee> GetEmployeeAsync(int companyId, int employeeId)
        {
            return await _dbContext.Employees
                .Where(_ => _.CompanyId == companyId && _.Id == employeeId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(
            int companyId,
            string genderDisplay, //这里要跟dto一致，而不是与Entity P18
            string q)
        {
            var query = _dbContext.Employees.AsQueryable<Employee>();
            query = query.Where(_ => _.CompanyId == companyId);

            if (!string.IsNullOrWhiteSpace(genderDisplay))
            {
                genderDisplay = genderDisplay.Trim();
                var gender = Enum.Parse<Gender>(genderDisplay, true);
                query = query.Where(_ => _.Gender == gender);
            }
            if (!string.IsNullOrWhiteSpace(q))
            {
                q = q.Trim();

                query = query.Where(_ => _.EmployeeNo.Contains(q) ||
                                         _.FirstName.Contains(q) ||
                                         _.LastName.Contains(q));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() >= 0;
        }

        public void UpdateCompany(Company company)
        {

        }

        public void UpdateEmployee(Employee employee)
        {
        }
    }
}
