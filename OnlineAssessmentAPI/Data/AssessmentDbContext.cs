using System;
using Microsoft.EntityFrameworkCore;
using OnlineAssessmentAPI.Models;

namespace OnlineAssessmentAPI.Data;

public class AssessmentDbContext: DbContext
    {
        public AssessmentDbContext(DbContextOptions<AssessmentDbContext> options) : base(options) { }

        public DbSet<JobDetailsModel> JobDetails { get; set; }
        public DbSet<HrCandidateDetailsModel> CandidateDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobDetailsModel>()
                .HasMany(j => j.Candidates)
                .WithOne()
                .HasForeignKey(c => c.RequestId)
                .HasPrincipalKey(j => j.RequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

