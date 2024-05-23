using PatientManagementSystem.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Model.Entites
{
    public class PatientInformation
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        public int DiseaseId { get; set; }
        public Epilepsy? Epilepsy { get; set; }

    }
}
