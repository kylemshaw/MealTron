using MealTron.API.Data;
using MealTron.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MealTron.API.Controllers
{
    // localhost:5001/api/members
    public class MembersController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();
            return members;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetMember(string id) // localhost:5001/api/members/kyle-id
        {
            var member = await context.Users.FindAsync(id);
            if (member == null) return NotFound();
            return member;
        }
    }
}
