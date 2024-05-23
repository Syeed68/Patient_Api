using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagementSystem.Model.IRepositories;
using PatientManagementSystem.Model.ViewModel;

namespace PatientManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInformationController : ControllerBase
    {
        private readonly IPatientInformationRepository _patientInformationRepository;
        public PatientInformationController(IPatientInformationRepository patientInformationRepository)
        {
            _patientInformationRepository = patientInformationRepository;
        }

        //[HttpPost("Create")]
        //public async Task<IActionResult> Create(VmPatient Vm)
        //{
        //    var response = await _patientInformationRepository.CreateAsync(Vm);
        //    return Ok();
        //}
        [HttpPost("Create")]
        public async Task<ActionResult<VmResponseMessage>> Create(VmPatient patientInformation)
        {
            var response = await _patientInformationRepository.CreateAsync(vm);
            return Ok();
        }
    }
}
