using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickResponder.Domain;
using QuickResponder.Infrastructure;

namespace QuickResponder.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController : ControllerBase
{
    private readonly ApplicationDbContext _appContext;

    public PatientsController(ApplicationDbContext appContext)
    {
        _appContext = appContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Patient>> GetPatients()
    {
        return await _appContext.Patients.ToListAsync();
    }

    [HttpGet("id:guid")]
    public async Task<Patient> GetPatient(Guid id)
    {   
        return await _appContext.Patients.FindAsync(id);
    }

    [HttpPost]
    public async Task CreatePatient(Patient patient) 
    {
        await _appContext.AddAsync(patient);
        await _appContext.SaveChangesAsync();
    }
}