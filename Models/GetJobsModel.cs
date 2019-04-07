namespace GetJobsv3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GetJobsModel : DbContext
    {
        public GetJobsModel()
            : base("name=GetJobsModel")
        {
        }

        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobFair> JobFairs { get; set; }
        public virtual DbSet<JobFairBranch> JobFairBranches { get; set; }
        public virtual DbSet<JobPosting> JobPostings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.Phone1)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.Phone2)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.BestWay2contact)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.LinkedIn)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.ResumeName)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.ResumePath)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.ASign)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .Property(e => e.WhoEmailed)
                .IsUnicode(false);

            modelBuilder.Entity<Applicant>()
                .HasMany(e => e.EduList)
                .WithRequired(e => e.Applicant)
                .HasForeignKey(e => e.ApplicantID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Applicant>()
                .HasMany(e => e.EmpList)
                .WithRequired(e => e.Applicant)
                .HasForeignKey(e => e.ApplicantID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.BranchName)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .Property(e => e.LastEditedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.JobPostings)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.JobFairs)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.JobFairBranches)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.SchoolName)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.Degree)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.StartY)
                .IsUnicode(false);

            modelBuilder.Entity<Education>()
                .Property(e => e.EndY)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.Company)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.SuperFName)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.SuperLName)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.JobDuties)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.ReasonLeave)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.StartSal)
                .IsUnicode(false);

            modelBuilder.Entity<Employer>()
                .Property(e => e.EndSal)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.JobTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.PreferredSkills)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.EoeMessage)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.LastEditedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .HasMany(e => e.JobPostings)
                .WithRequired(e => e.Job)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobFair>()
                .Property(e => e.FairDate)
                .IsUnicode(false);

            modelBuilder.Entity<JobPosting>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<JobPosting>()
                .Property(e => e.LastEditedBy)
                .IsUnicode(false);

            modelBuilder.Entity<JobPosting>()
                .Property(e => e.HireMgrEmail)
                .IsUnicode(false);

            modelBuilder.Entity<JobPosting>()
                .HasMany(e => e.Applicants)
                .WithRequired(e => e.JobPosting)
                .WillCascadeOnDelete(false);
        }
    }
}
