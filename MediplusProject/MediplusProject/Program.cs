using MediplusProject.DAL;
using Microsoft.EntityFrameworkCore;

namespace MediplusProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<AppDbContext>(
				options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("MsSQL")));

			var app = builder.Build();
            app.UseStaticFiles();

			app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
		  );
	

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
#region Data

/*
 
 INSERT INTO Doctors (Name, Surname, Finkod, PhoneNumber, Email, Username, IsActive)
VALUES 
('Sarah', 'Connor', 'FIN22334', '5551122334', 'sarah.connor@example.com', CONCAT('Sarah', 'FIN22334'), 1),
('James', 'Bond', 'FIN33445', '5552233445', 'james.bond@example.com', CONCAT('James', 'FIN33445'), 1),
('Linda', 'Taylor', 'FIN44556', '5553344556', 'linda.taylor@example.com', CONCAT('Linda', 'FIN44556'), 1),
('Robert', 'Miller', 'FIN55667', '5554455667', 'robert.miller@example.com', CONCAT('Robert', 'FIN55667'), 1),
('Anna', 'Clark', 'FIN66778', '5555566778', 'anna.clark@example.com', CONCAT('Anna', 'FIN66778'), 1);



INSERT INTO Patients (Name, Surname, Finkod, PhoneNumber, Username, IsDelete)
VALUES 
('John', 'Doe', 'FIN12345', '5551234567', CONCAT('John', 'FIN12345'), 0),
('Jane', 'Smith', 'FIN67890', '5559876543', CONCAT('Jane', 'FIN67890'), 0),
('Michael', 'Brown', 'FIN54321', '5555678901', CONCAT('Michael', 'FIN54321'), 0),
('Emily', 'Davis', 'FIN98765', '5556789012', CONCAT('Emily', 'FIN98765'), 0),
('Chris', 'Wilson', 'FIN11223', '5553456789', CONCAT('Chris', 'FIN11223'), 0);
select * from Doctors
select * from Patients

INSERT INTO Appointments (DoctorId, PatientId, AppointmentDate, CreatedAt, UpdatedAt, IsActive)
VALUES
(1, 1, '2024-12-05 10:00:00', GETDATE(), NULL, 1),
(2, 2, '2024-12-06 11:00:00', GETDATE(), NULL, 1),
(3, 3, '2024-12-07 12:00:00', GETDATE(), NULL, 1),
(4, 4, '2024-12-08 13:00:00', GETDATE(), NULL, 1),
(5, 5, '2024-12-09 14:00:00', GETDATE(), NULL, 1);

 */

#endregion