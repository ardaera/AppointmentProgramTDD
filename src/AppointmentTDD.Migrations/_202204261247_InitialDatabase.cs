using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentTDD.Migrations
{
    [Migration(202204261247)]
    public class _202204261247_InitialDatabase : Migration
    {
        public override void Up()
        {
            Create.Table("Doctors").WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("NationalCode").AsString(10).NotNullable()
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("LastName").AsString(50).NotNullable()
                .WithColumn("Field").AsString(50).NotNullable();

            Create.Table("Patients").WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("NationalCode").AsString(10).NotNullable()
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("LastName").AsString(50).NotNullable();

            Create.Table("Appointments").WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("Date").AsDate().NotNullable()
                .WithColumn("DoctorId").AsInt32().NotNullable()
                .ForeignKey("FK_Doctors_Appointments", "Doctors", "Id")
                .WithColumn("PatientId").AsInt32().NotNullable()
                .ForeignKey("FK_Patients_Appointments", "Patients", "Id");
        }

        public override void Down()
        {
            Delete.Table("Appoinments");
            Delete.Table("Doctors");
            Delete.Table("Patients");
        }
    }
}
