using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Model.Entites
{
    public class Allergy_Details
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AllergyCId { get; set; }
    }
}
