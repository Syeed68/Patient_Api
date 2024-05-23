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
                        Epilepsy = Vm.Epilepsies
                    };
                    await _db.PatientInformation.AddAsync(Patient);
                    await _db.SaveChangesAsync();
                    foreach (var i in Vm.NCD_Details)
                    {
                        NCD_Details NCD_Details = new NCD_Details();
                        NCD_Details.NDCId = i.NDCId;
                        NCD_Details.PatientId = Patient.Id;
                        await _db.NCD_Details.AddAsync(NCD_Details);
                    }

                    foreach(var i in Vm.Allergy_Details)
                    {
                        Allergy_Details Allergy = new Allergy_Details();
                        Allergy.AllergyId = i.AllergyId;
                        Allergy.PatientId = Patient.Id;
                        await _db.Allergy_Details.AddAsync(Allergy);
                    }

                    await _db.SaveChangesAsync();
                    response.Type = "Success";
                    response.Message = "Created Successfully";
                    transaction.Complete();
                }
                catch (Exception ex)
                {
                    transaction.Dispose();
                    response.Type = "Error";
                    response.Message = ex.Message;
                    throw;
                }
               
            }
            return response;
        }
    }
}
