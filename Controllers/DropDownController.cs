using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using PatientManagementSystem.Model.Enum;
using PatientManagementSystem.Model.IRepositories;
using PatientManagementSystem.Model.ViewModel;

namespace PatientManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : ControllerBase
    {
        private readonly IDropdownRepository _dropdownRepository;
        public DropDownController(IDropdownRepository dropdownRepository)
        {
            _dropdownRepository = dropdownRepository;
        }
        [Route("GetDiseaseInformation")]
        [HttpGet]
        public async Task<ActionResult> GetDiseaseInformation()
        {
            return Ok(await _dropdownRepository.GetDrpDiseaseInformation());
        }

        [Route("GetNCD")]
        [HttpGet]
        public async Task<ActionResult> GetNCD()
        {
            return Ok(await _dropdownRepository.GetDrpNCD());
        }

        [Route("GetAllergy")]
        [HttpGet]
        public async Task<ActionResult> GetAllergy()
        {
            return Ok(await _dropdownRepository.GetDrpAllergy());
        }

        [Route("GetEpilepsy")]
        [HttpGet]
        public  ActionResult GetEpilepsy()
        {
            return Ok(Enum.GetValues(typeof(Epilepsy))
                .Cast<Epilepsy>()
                .Select(v => new VmSelectListItem
                {
                    Text = v.GetDisplayName(),
                    Value = v.ToString()

                }).ToList());
        }
    }
}
