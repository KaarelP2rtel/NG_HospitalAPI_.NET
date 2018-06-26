using DAL.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly AppDbContext _context;

        public DiseaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Disease> AddAsync(Disease d)
        {
            await _context.Diseases.AddAsync(d);
            await _context.SaveChangesAsync();
            return d;

        }

        public async Task<List<Disease>> AllAsync()
        {
            return await _context
                .Diseases
                .Include(d=> d.DiseaseSymptoms)
                    .ThenInclude(ds => ds.Symptom)
                .ToListAsync();
        }

        public async Task<Disease> FindWithSymptomsAsync(int id)
        {
            return await _context
                .Diseases
                .Include(d => d.DiseaseSymptoms)
                    .ThenInclude(ds => ds.Symptom)
                .SingleOrDefaultAsync(d => d.Id == id);
        }
    }
}
