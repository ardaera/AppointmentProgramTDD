namespace AppointmentTDD.Services.Doctors.Contracts
{
    public class UpdateDoctorDto
    {
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Field { get; set; }
    }
}