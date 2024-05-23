using Microsoft.AspNetCore.Mvc.Rendering;
using PatientManagementSystem.Model.ViewModel;

namespace PatientManagementSystem.Model.IRepositories
{
    public interface IDropdownRepository
    {
        Task<List<VmSelectListItem>> GetDrpDiseaseInformation();
        Task<List<VmSelectListItem>> GetDrpNCD();
        Task<List<VmSelectListItem>> GetDrpAllergy();
    }
}
