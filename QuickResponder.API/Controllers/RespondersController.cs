using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickResponder.Domain;
using QuickResponder.Infrastructure;

namespace QuickResponder.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RespondersController : ControllerBase
{
    private readonly ApplicationDbContext _appContext;

    public RespondersController(ApplicationDbContext appContext)
    {
        _appContext = appContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Responder>> GetResponders()
    {
        return await _appContext.Responders.ToListAsync();
    }

    [HttpGet("id:guid")]
    public async Task<Responder> GetResponder(Guid id)
    {
        return await _appContext.Responders.FindAsync(id);
    }

    [HttpPost]
    public async Task CreateResponder(Responder responder)
    {
        await _appContext.AddAsync(responder);
        await _appContext.SaveChangesAsync();
    }
}
