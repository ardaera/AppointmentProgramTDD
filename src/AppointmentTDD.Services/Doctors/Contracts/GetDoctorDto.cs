namespace AppointmentTDD.Services.Doctors.Contracts
{
    public class GetDoctorDto
    {
        public string NationalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Field { get; set; }
    }
}