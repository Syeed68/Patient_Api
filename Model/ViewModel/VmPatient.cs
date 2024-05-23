using PatientManagementSystem.Model.Entites;
using PatientManagementSystem.Model.Enum;

namespace PatientManagementSystem.Model.ViewModel
{
    public class VmPatient
    {
        public string Name { get; set; }
        public int DiseaseId { get; set; }
        public string Epilepsy { get; set; }
        public Epilepsy Epilepsies { get; set; }
        public List<NCD_Details> NCD_Details { get; set; }
        public List<Allergy_Details> Allergy_Details { get; set; }
    }
}
