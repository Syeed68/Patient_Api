using Microsoft.EntityFrameworkCore;
using PatientManagementSystem.Model.Entites;

namespace PatientManagementSystem.Model
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions option) : base(option)
        {

        }
        public DbSet<PatientInformation> PatientInformation { get; set; }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<NCD> NCD { get; set; }
        public DbSet<NCD_Details> NCD_Details { get; set; }
        public DbSet<Allergy> Allergy { get; set; }
        public DbSet<Allergy_Details> Allergy_Details { get; set; }
        
    }
}
