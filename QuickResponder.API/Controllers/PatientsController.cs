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

// notice how ApplicationDbContext gets injected into the controller, not newed up, the DI does that for us

    public PatientsController(ApplicationDbContext appContext)
    {
        _appContext = appContext;
    }

    // Couldn't you do this?: yes, but usually ActionResult is more for MVC, not apis
    // Okay, why is that?  actionresult returns a response that is like Ok, BadRequset, View,
    // those work more for MVC, in webapi you have a lighter controller, you return normally
    // JSON  that would be more like you do if you want to use the async stuff and yes
    // that would be better than the other lines
    
    // Let's do that then if yo're okay with that.
    // I don't know if it adds more code later down the line
    [HttpGet]
    public async Task<IEnumerable<Patient>> GetPatients()
    {
        return await _appContext.Patients.ToListAsync();
    }

    [HttpGet("id:guid")]
    public async Task<Patient> GetPatient(Guid id)
    {   
        return await _appContext.Patients.FindAsync(id);

        // don't know the diference, you can e
        // return await _appContext.Patients.SingleAsync(e => e.ID == id);
    }

    [HttpPost]
    public async Task CreatePatient(Patient patient) {
        await _appContext.AddAsync(patient);
        await _appContext.SaveChangesAsync();
    }
}