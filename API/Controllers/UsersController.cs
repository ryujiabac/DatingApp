using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        // [HttpGet]
        // //จะเอา ลิสของ DB using IEnumerable
        // public ActionResult<IEnumerable<AppUser>> GetUsers()
        // {

        //     var users = _context.Users.ToList();
        //     return users;
        // }
        //  //api/users/2   เอาทีละตัว
        // [HttpGet("{id}")]
        // //จะเอา ลิสของ DB using IEnumerable
        // public ActionResult<AppUser> GetUser(int id)  //remove IEnumerable because get just one
        // {

        //     var user =  _context.Users.Find(id); // finding primary key  ทำเป็น single line 
        //     return user;
        // }

     //Working on Aysnc Code

       [HttpGet]
        //จะเอา ลิสของ DB using IEnumerable
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {

            var users = await _context.Users.ToListAsync();
            return users;
        }
         //api/users/2   เอาทีละตัว
        [HttpGet("{id}")]
        //จะเอา ลิสของ DB using IEnumerable
        public async Task<ActionResult<AppUser>> GetUser(int id)  //remove IEnumerable because get just one
        {

            var user =  await _context.Users.FindAsync(id); // finding primary key  ทำเป็น single line 
            return user;
        }


    }
}