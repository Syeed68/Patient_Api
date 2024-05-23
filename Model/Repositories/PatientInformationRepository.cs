using Azure;
using PatientManagementSystem.Model.Entites;
using PatientManagementSystem.Model.IRepositories;
using PatientManagementSystem.Model.ViewModel;
using System.Transactions;

namespace PatientManagementSystem.Model.Repositories
{
    public class PatientInformationRepository:IPatientInformationRepository
    {
        private readonly ApplicationDbContext _db;
        public PatientInformationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<VmResponseMessage> CreateAsync(VmPatient Vm)
        {
            var response = new VmResponseMessage();
            using(var transaction=new TransactionScope())
            {
                try
                {
                    var Patient = new PatientInformation
                    {
                        Name = Vm.Name,
                        DiseaseId = Vm.DiseaseId,
                        //Epilepsy = (int)Vm.Epilepsy
                    };
                    await _db.PatientInformation.AddAsync(Patient);
                    await _db.SaveChangesAsync();
                    response.Type = "Success";
                    response.Message = "Created Successfully";
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    response.Type = "Success";
                    response.Message = ex.Message;
                    throw;
                }
               
            }
            return response;
        }
    }
}
