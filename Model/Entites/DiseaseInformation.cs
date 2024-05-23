using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Model.Entites
{
    public class DiseaseInformation
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
