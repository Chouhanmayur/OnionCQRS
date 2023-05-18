using Employee.Management.Application.Contracts.Persistence;
using Employee.Management.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Management.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EmployeeDatabaseContext _context;

        public GenericRepository(EmployeeDatabaseContext context) {
            this._context = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
           await  _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAsync()
        {
          return await  _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
