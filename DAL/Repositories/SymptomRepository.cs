﻿using DAL.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SymptomRepository : ISymptomRepository
    {
        private readonly AppDbContext _context;

        public SymptomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Symptom> AddAsync(Symptom symptom)
        {
            await _context.Symptoms.AddAsync(symptom);
            await _context.SaveChangesAsync();
            return symptom;
        }

        public async Task<List<Symptom>> AllAsync()
        {
            return await _context.Symptoms.ToListAsync();
        }

        public async Task<List<Symptom>> AllWithDiseasesAsync()
        {
            return await _context
                .Symptoms
                .Include(s => s.DiseaseSymptoms)
                    .ThenInclude(ds => ds.Disease)
                .ToListAsync();
        }

        public async Task<List<Symptom>> GreatestAsync()
        {
            return await _context.Symptoms
                .Include(s => s.DiseaseSymptoms)
                    .ThenInclude(ds => ds.Disease)
                .OrderByDescending(s => s.DiseaseSymptoms.Count)
                .ThenBy(s => s.Name)
                .Take(3)
                .ToListAsync();
        }

        public async Task<int> SymptomsCount()
        {
            return await _context.Symptoms.CountAsync();
        }
    }
}
