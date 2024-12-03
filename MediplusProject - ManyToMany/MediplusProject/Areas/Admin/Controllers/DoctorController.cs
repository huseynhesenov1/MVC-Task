using MediplusProject.Areas.Admin.DTOs.DoctorDTOs;
using MediplusProject.DAL;
using MediplusProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace MediplusProject.Areas.Admin.Controllers;

[Area("Admin")]
public class DoctorController : Controller
{
    private readonly AppDbContext _context;
    public DoctorController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Doctor> doctor = _context.Doctors.ToList();
        return View(doctor);
    }
    public IActionResult Create()
    {
        ViewBag.Hosbitals = new SelectList(_context.Hosbitals, "Id", "Name");
        return View();
    }
    [HttpPost]
    public IActionResult Create(CreateDoctorDto createDoctorDto)
    {
        if (ModelState.IsValid)
        {
            Doctor newDoctor = new Doctor();
            newDoctor.Name = createDoctorDto.Name;
            newDoctor.Surname = createDoctorDto.Surname;
            newDoctor.Finkod = createDoctorDto.Finkod;
            newDoctor.PhoneNumber = createDoctorDto.PhoneNumber;
            newDoctor.Email = createDoctorDto.Email;
            newDoctor.Username = createDoctorDto.Username;
            _context.Doctors.Add(newDoctor);
            
            foreach (int hosbitalID in createDoctorDto.HosbitalDoctorIds)
            {
                _context.HosbitalDoctors.Add( new HosbitalDoctor
                {
                    HosbitalId = hosbitalID,
                    Doctor = newDoctor
                });
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Doctor");
        }

        ViewBag.Hosbitals = new SelectList(_context.Hosbitals, "Id", "Name");

        return View(createDoctorDto);
    }
}
