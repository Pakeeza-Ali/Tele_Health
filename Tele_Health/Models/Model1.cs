using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Tele_Health.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ADMIN_tbl> ADMIN_tbl { get; set; }
        public virtual DbSet<APPOINTMENT_tbl> APPOINTMENT_tbl { get; set; }
        public virtual DbSet<DEPARTMENT_tbl> DEPARTMENT_tbl { get; set; }
        public virtual DbSet<DOCTOR_SCHEDULE> DOCTOR_SCHEDULE { get; set; }
        public virtual DbSet<DOCTOR_tbl> DOCTOR_tbl { get; set; }
        public virtual DbSet<FEEDBACK_tbl> FEEDBACK_tbl { get; set; }
        public virtual DbSet<HOSPITAL_tbl> HOSPITAL_tbl { get; set; }
        public virtual DbSet<PATIENT_tbl> PATIENT_tbl { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DEPARTMENT_tbl>()
                .HasMany(e => e.DOCTOR_tbl)
                .WithRequired(e => e.DEPARTMENT_tbl)
                .HasForeignKey(e => e.DEPARTMENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCTOR_SCHEDULE>()
                .HasMany(e => e.APPOINTMENT_tbl)
                .WithRequired(e => e.DOCTOR_SCHEDULE)
                .HasForeignKey(e => e.PATIENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCTOR_tbl>()
                .HasMany(e => e.DOCTOR_SCHEDULE)
                .WithRequired(e => e.DOCTOR_tbl)
                .HasForeignKey(e => e.DOCTOR_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DOCTOR_tbl>()
                .HasMany(e => e.FEEDBACK_tbl)
                .WithRequired(e => e.DOCTOR_tbl)
                .HasForeignKey(e => e.DOCTOR_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOSPITAL_tbl>()
                .HasMany(e => e.DEPARTMENT_tbl)
                .WithRequired(e => e.HOSPITAL_tbl)
                .HasForeignKey(e => e.HOSPITAL_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOSPITAL_tbl>()
                .HasMany(e => e.DOCTOR_tbl)
                .WithRequired(e => e.HOSPITAL_tbl)
                .HasForeignKey(e => e.HOSPITAL_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT_tbl>()
                .HasMany(e => e.APPOINTMENT_tbl)
                .WithRequired(e => e.PATIENT_tbl)
                .HasForeignKey(e => e.PATIENT_FID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT_tbl>()
                .HasMany(e => e.FEEDBACK_tbl)
                .WithRequired(e => e.PATIENT_tbl)
                .HasForeignKey(e => e.PATIENT_FID)
                .WillCascadeOnDelete(false);
        }
    }
}
