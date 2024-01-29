using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickResponder.Domain;
using QuickResponder.Infrastructure;

namespace QuickResponder.API.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _appContext;

        public UsersController(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _appContext.Users.ToListAsync();
        }

        [HttpGet("id:guid")]
        public async Task<User> GetUser(Guid id)
        {
            return await _appContext.Users.FindAsync(id);

            // return await _appContext.Patients.SingleAsync(e => e.ID == id);
        }

        [HttpPost]
        public async Task CreateUser(User user)
        {
            await _appContext.AddAsync(user);
            await _appContext.SaveChangesAsync();
        }
    }
}
