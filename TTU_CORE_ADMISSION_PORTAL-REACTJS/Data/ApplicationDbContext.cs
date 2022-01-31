using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using TTU_CORE_ADMISSION_PORTAL_REACTJS.Models;

namespace TTU_CORE_ADMISSION_PORTAL_REACTJS.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }
    public DbSet<ApplicantModel> ApplicantModel { get; set; }
       public DbSet<FormNoModel> FormNoModel { get; set; }
        public DbSet<AcademicExperieceModel> AcademicExperieceModel { get; set; }

        public DbSet<BankModel> BankModel { get; set; }

        public DbSet<DenominationModel> DenominationModel { get; set; }

        public DbSet<DepartmentModel> DepartmentModel { get; set; }

        public DbSet<DistrictModel> DistrictModel { get; set; }

        public DbSet<DocumentUploadModel> DocumentUploadModel { get; set; }

        public DbSet<ExamModel> ExamModel { get; set; }

        public DbSet<FacultyModel> FacultyModel { get; set; }

        public DbSet<GradeModel> GradeModel { get; set; }

        public DbSet<HallModel> HallModel { get; set; }

        public DbSet<RegionModel> RegionModel { get; set; }

        public DbSet<ReligionModel> ReligionModel { get; set; }

        public DbSet<RequirementModel> RequirementModel { get; set; }

        public DbSet<SchoolModel> SchoolModel { get; set; }

        public DbSet<SMSModel> SMSModel { get; set; }

        public DbSet<SubjectModel> SubjectModel { get; set; }

        public DbSet<SHSProgrammes> SHSProgrammes { get; set; }

        public DbSet<CountryModel> CountryModel { get; set; }

        public DbSet<ProgrammeModel> ProgrammeModel { get; set; }

        public DbSet<ResultUploadModel> ResultUploadModel { get; set; }


        public DbSet<WorkingExperienceModel> WorkingExperienceModel { get; set; }

        public DbSet<ApplicantIssueModel> ApplicantIssueModel { get; set; }

        public DbSet<FormerSchoolModel> FormerSchoolModel { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(
           bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            OnBeforeSaving();
            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess,
                          cancellationToken));
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.UpdatedOn = utcNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("CreatedOn").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.CreatedOn = utcNow;
                            trackable.UpdatedOn = utcNow;
                            break;
                    }
                }
            }
        }

}