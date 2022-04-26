using AppointmentTDD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Persistence.EF.Appointments
{
    public class AppointmentEntityMap : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> b)
        {
            b.ToTable("Appointments").HasKey(b => b.Id);
                b.Property(b=>b.Id).IsRequired();

            b.Property(b=>b.Date).IsRequired();

            b.HasOne(b => b.Doctor).WithMany(b => b.Appointments)
                .HasForeignKey(b => b.DoctorId);
            
            b.HasOne(b => b.Patient).WithMany(b => b.Appointments)
                .HasForeignKey(b => b.PatientId);
        }
    }
}
