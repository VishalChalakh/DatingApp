using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : ControllerBase
{
    private readonly DataContext context;

    public UsersController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
   public async Task<ActionResult<IEnumerable<AppUser>>> GertUsers()
   {
       var users = await context.Users.ToListAsync();
       return users;
   }

   [HttpGet("{id:int}")] // /api/users/id
   public async Task<ActionResult<AppUser>> GertUsers(int id)
   {
       var user = await context.Users.FindAsync(id);

       if (user == null)
       {
        return NotFound();
       }

       return user;
   }
}
