using ApiNewSample.DtoParameters;
using ApiNewSample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNewSample.Services
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompaniesAsync(CompanyDtoParameters parameters);

        Task<Company> GetCompanyAsync(int componyId);

        Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<int> companyIds);

        void AddCompany(Company company);

        void UpdateCompany(Company company);

        void DeleteCompany(Company company);

        Task<bool> CompanyExistsAsync(int companyId);


        Task<IEnumerable<Employee>> GetEmployeesAsync(int companyId, string genderDisplay, //这里要跟dto一致，而不是与Entity P18
            string q);

        Task<Employee> GetEmployeeAsync(int companyId, int employeeId);

        void AddEmployee(int companyId, Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(Employee employee);
        Task<bool> SaveChangesAsync();
    }
}
