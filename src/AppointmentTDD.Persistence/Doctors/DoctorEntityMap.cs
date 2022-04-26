using AppointmentTDD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Persistence.EF.Doctors
{
    public class DoctorEntityMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> b)
        {
            b.ToTable("Doctors");

            b.HasKey(_ => _.Id);
            b.Property(_ => _.Id)
                .ValueGeneratedOnAdd();

            b.Property(_ => _.NationalCode)
                .IsRequired();

            b.Property(_ => _.FirstName)
                .IsRequired();

            b.Property(_ => _.LastName)
                .IsRequired();

            b.Property(_ => _.Field)
                .IsRequired();
        }
    }
}
