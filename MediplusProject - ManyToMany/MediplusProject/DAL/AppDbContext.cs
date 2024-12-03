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
		public DbSet<Hosbital> Hosbitals { get; set; }
		public DbSet<HosbitalDoctor> HosbitalDoctors { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


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

            modelBuilder.Entity<HosbitalDoctor>()
          .HasKey(hd => hd.Id); 

            modelBuilder.Entity<HosbitalDoctor>()
            .HasOne(hd => hd.Hosbital)
            .WithMany(h => h.HosbitalDoctors) 
            .HasForeignKey(hd => hd.HosbitalId);

            modelBuilder.Entity<HosbitalDoctor>()
                .HasOne(hd => hd.Doctor)
                .WithMany(d => d.HosbitalDoctors) 
                .HasForeignKey(hd => hd.DoctorId);

        }

    }
}
