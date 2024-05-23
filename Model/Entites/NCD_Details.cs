using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Model.Entites
{
    public class NCD_Details
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int NDCId { get; set; }
    }
}
