using quickTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quickTask.Contracts
{
    public class PaitentsRepository :IPaitentsRepository 
    {

        private readonly ApplicationDBContext _context;
        public PaitentsRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Patient entity)
        {
            await _context.Patients.AddAsync(entity);
            return 1;
        }

        public async Task<int> Delete(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            return 1;
        }

        public async Task<Patient> Get(int? id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<int> Update(Patient entity)
        {
            var patient = await _context.Patients.FindAsync(entity);
            this._context.Entry(patient).CurrentValues.SetValues(entity);
            return 1;
        }
    }

}

