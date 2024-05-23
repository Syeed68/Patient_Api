using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using PatientManagementSystem.Model.IRepositories;
using PatientManagementSystem.Model.ViewModel;

namespace PatientManagementSystem.Model.Repositories
{
    public class DropdownRepository : IDropdownRepository
    {
        protected readonly ApplicationDbContext _db;
        public DropdownRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<VmSelectListItem>> GetDrpDiseaseInformation()
        {
            return await _db.DiseaseInformation
                .Select(x => new VmSelectListItem
                {
                    Text=x.Name,
                    Value=x.Id.ToString()
                }).OrderBy(x => x.Text).ToListAsync();
        }
        public async Task<List<VmSelectListItem>> GetDrpNCD()
        {
            return await _db.NCD
                .Select(x => new VmSelectListItem
                {
                    Text=x.Name,
                    Value=x.Id.ToString()
                }).OrderBy(x => x.Text).ToListAsync();
        } 
        
        public async Task<List<VmSelectListItem>> GetDrpAllergy()
        {
            return await _db.Allergy
                .Select(x => new VmSelectListItem
                {
                    Text=x.Name,
                    Value=x.Id.ToString()
                }).OrderBy(x=>x.Text).ToListAsync();
        }

        

    }
}
