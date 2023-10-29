using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Utils;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly SymphonyContext _context;

        public UserController(SymphonyContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.User.Where(u => u.DeletedAt == null).ToListAsync();

            if (users == null || users.Count == 0)
            {
                return NotFound();
            }

            return users;
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _context.User
                .Where(u => u.Id == id && u.DeletedAt == null)
                .Include(u => u.UserCourses)
                .ThenInclude(uc => uc.Course)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/User/SignUp
        [HttpPost("SignUp")]
        public ActionResult<string> SignUp([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.User.Any(u => u.Email == user.Email))
            {
                return BadRequest("Email already in use.");
            }

            // Encrypt the password using SHA1
            if (user.Password != null)
            {
                user.Password = PasswordUtils.EncryptPassword(user.Password);
            }
            else
            {
                return BadRequest("Password cannot be null.");
            }

            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            _context.User.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully.");
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = await _context.User
                .Where(u => u.Id == id && u.DeletedAt == null)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Birthday = updatedUser.Birthday;

            user.UpdatedAt = DateTime.Now;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Update success!");
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> SoftDeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.UserCourse.RemoveRange(user.UserCourses);
            user.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok("Delete success!");
        }

        [HttpPost("CreateUserCourse")]
        [Authorize]
        public async Task<IActionResult> CreateUserCourse(UserCourseCreateModel model)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.Id == model.UserId);
                var course = await _context.Course.FirstOrDefaultAsync(c => c.Id == model.CourseId);

                if (user == null || course == null)
                {
                    return NotFound("User or course not found.");
                }

                var userCourse = new UserCourse
                {
                    UserId = model.UserId,
                    CourseId = model.CourseId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                _context.UserCourse.Add(userCourse);
                await _context.SaveChangesAsync();

                return Ok("Add Course successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while adding course: " + ex.Message);
            }
        }

        // DELETE: api/User/DeleteUserCourse/{id}
        [HttpDelete("DeleteUserCourse/{userId}/{courseId}")]
        public async Task<IActionResult> DeleteUserCourse(int userId, int courseId)
        {
            var userCourse = await _context.UserCourse.FindAsync(userId, courseId);

            if (userCourse == null)
            {
                return NotFound();
            }

            _context.UserCourse.Remove(userCourse);
            await _context.SaveChangesAsync();

            return Ok("Remove course deleted successfully.");
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
