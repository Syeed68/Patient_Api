using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagementSystem.Model.Enum;
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

        [HttpPost("Create")]
        public async Task<ActionResult<VmResponseMessage>> Create(VmPatient patientInformation)
        {
            patientInformation.Epilepsies = (Epilepsy)Enum.Parse(typeof(Epilepsy), patientInformation.Epilepsy);
            var response = await _patientInformationRepository.CreateAsync(patientInformation);
            return Ok(response);
        }
    }
}
