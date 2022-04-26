using AppointmentTDD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Persistence.EF.Patients
{
    public class PatientEntityMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> b)
        {
            b.ToTable("Patients");
            b.HasKey(b => b.Id);
            b.Property(b => b.Id).ValueGeneratedOnAdd();

            b.Property(b=>b.FirstName).IsRequired();

            b.Property(b => b.LastName).IsRequired();   

            b.Property(b => b.NationalCode).IsRequired();   
        }
    }
}
