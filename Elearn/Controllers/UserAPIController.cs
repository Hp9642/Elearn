using Elearn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Elearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly OnlineLearningPlatformDBContext context;

        public UserAPIController(OnlineLearningPlatformDBContext context)
        {
            this.context = context;
        }

        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var data = await context.Users.ToListAsync();
            return Ok(data);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return Ok(await context.Courses.ToListAsync());
        }


        [HttpGet("enrollments")]
        public async Task<ActionResult<List<Enrollment>>> GetEnrollments()
        {
            var data = await context.Enrollments.ToListAsync();
            return Ok(data);
        }

        [HttpGet("forumposts")]
        public async Task<ActionResult<List<ForumPost>>> GetForumPosts()
        {
            var data = await context.ForumPosts.ToListAsync();
            return Ok(data);
        }

        [HttpGet("forumthreads")]
        public async Task<ActionResult<List<ForumThread>>> GetForumThreads()
        {
            var data = await context.ForumThreads.ToListAsync();
            return Ok(data);
        }

        [HttpGet("lectures")]
        public async Task<ActionResult<List<Lecture>>> GetLectures()
        {
            var data = await context.Lectures.ToListAsync();
            return Ok(data);
        }

        [HttpGet("quizzes")]
        public async Task<ActionResult<List<Quiz>>> GetQuizzes()
        {
            var data = await context.Quizzes.ToListAsync();
            return Ok(data);
        }

        [HttpGet("quizattempts")]
        public async Task<ActionResult<List<QuizAttempt>>> GetQuizAttempts()
        {
            var data = await context.QuizAttempts.ToListAsync();
            return Ok(data);
        }

        [HttpGet("quizquestions")]
        public async Task<ActionResult<List<QuizQuestion>>> GetQuizQuestions()
        {
            var data = await context.QuizQuestions.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User usr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the email already exists
            bool emailExists = await context.Users.AnyAsync(u => u.Email == usr.Email);
            if (emailExists)
            {
                return BadRequest("Email already exists.");
            }

            // Add the new user
            await context.Users.AddAsync(usr);
            await context.SaveChangesAsync();

            // Return a response with the location of the created resource
            return CreatedAtAction(nameof(GetUsers), new { id = usr.UserId }, usr);
        }


      







    }
}
