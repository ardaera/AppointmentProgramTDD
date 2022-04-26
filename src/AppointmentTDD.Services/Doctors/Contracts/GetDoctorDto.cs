namespace AppointmentTDD.Services.Doctors.Contracts
{
    public class GetPatientDto
    {
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Field { get; set; }
    }
}