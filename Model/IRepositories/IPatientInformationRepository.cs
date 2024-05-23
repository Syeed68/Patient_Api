using PatientManagementSystem.Model.Entites;
using PatientManagementSystem.Model.ViewModel;

namespace PatientManagementSystem.Model.IRepositories
{
    public interface IPatientInformationRepository
    {
        Task<VmResponseMessage> CreateAsync(VmPatient Vm);
    }
}
