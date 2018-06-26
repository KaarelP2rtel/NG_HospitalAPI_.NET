using Domain;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<DiseaseSymptom> DiseaseSymptoms { get; set; }

    }
}
