using ApiNewSample.Data;
using ApiNewSample.Entities;
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
        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            var res = await _dbContext.Companies.ToListAsync();
            return res;

        }


        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

    }
}
