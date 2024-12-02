using MediplusProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MediplusProject.DAL
{
	public class AppDbContext:DbContext
	{
		
		public AppDbContext(DbContextOptions options) : base(options) { }
		public DbSet<SliderItem> SliderItems { get; set; }
		public DbSet<Coursel> Coursels { get; set; }
		public DbSet<HomeCard> HomeCards { get; set; }
		public DbSet<Scores> Scores { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);  

            base.OnModelCreating(modelBuilder);
        }

    }
}
