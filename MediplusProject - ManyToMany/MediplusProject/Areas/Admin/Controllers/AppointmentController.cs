using MediplusProject.DAL;
using MediplusProject.Models;
using MediplusProject.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MediplusProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private AppDbContext _context;
        public AppointmentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Appointment> appointments = _context.Appointments.ToList();
            return View(appointments);
        }
   
    [HttpGet]
    public IActionResult Create()
    {

            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name");
            ViewBag.Doctors = new SelectList(_context.Doctors.Where(m => m.IsActive == true), "Id", "Name");

            return View();

    }

        
        [HttpPost]
    public IActionResult Create(AppointmentVM appointmentVM)
    {
            if (ModelState.IsValid)
            {
                Appointment appointment = new Appointment()
                {
                    DoctorId = appointmentVM.DoctorId,
                    PatientId = appointmentVM.PatientId,
                    AppointmentDate = appointmentVM.AppointmentDate,
                    CreatedAt = appointmentVM.CreatedAt,
                    IsActive = appointmentVM.IsActive,
                   
                };

                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name");
            ViewBag.Doctors = new SelectList(_context.Doctors.Where(m => m.IsActive == true), "Id", "Name");


            return View(appointmentVM);
    }

    }
}
