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

        [HttpPut("update_user")]
        public async Task<IActionResult> UpdateUser([FromBody] User updatedUser)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email == updatedUser.Email);
            if (user == null)
            {
                return NotFound(new { error = "User not found" });
            }

            user.Username = updatedUser.Username;
            user.Password = updatedUser.Password;
            user.Role = updatedUser.Role;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(new { message = "User updated successfully", user });
        }

        private bool UserExists(int id)
        {
            return context.Users.Any(e => e.UserId == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { error = "User not found" });
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return Ok(new { message = "User deleted successfully", user });
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return Ok(await context.Courses.ToListAsync());
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCourse(string title, string newDescription, int newInstructorId)
        {
            var course = await context.Courses.FirstOrDefaultAsync(c => c.Title == title);
            if (course == null)
            {
                return NotFound("Course not found");
            }

            course.Description = newDescription;
            course.InstructorId = newInstructorId;

            try
            {
                await context.SaveChangesAsync();
                return Ok("Course updated successfully");
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating course in the database");
            }
        }



        [HttpGet("enrollments")]
        public async Task<ActionResult<List<Enrollment>>> GetEnrollments()
        {
            var data = await context.Enrollments.ToListAsync();
            return Ok(data);
        }

        [HttpDelete("{enrollmentid}")]
        public async Task<IActionResult> DeleteEnrollments(int enrollmentid)
        {
            var enrollment = await context.Enrollments.FindAsync(enrollmentid);
            if (enrollment == null)
            {
                return NotFound(new { error = "User not found" });
            }

            context.Enrollments.Remove(enrollment);
            await context.SaveChangesAsync();

            return Ok(new { message = "Enrollment deleted successfully", enrollment });
        }

        [HttpGet("forumposts")]
        public async Task<ActionResult<List<ForumPost>>> GetForumPosts()
        {
            var data = await context.ForumPosts.ToListAsync();
            return Ok(data);
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeleteForumPosts(int postId)
        {
            var forumpost = await context.ForumPosts.FindAsync(postId);
            if (forumpost == null)
            {
                return NotFound(new { error = "ForumPost not found" });
            }

            context.ForumPosts.Remove(forumpost);
            await context.SaveChangesAsync();

            return Ok(new { message = "ForumPost deleted successfully", forumpost });
        }

        [HttpGet("forumthreads")]
        public async Task<ActionResult<List<ForumThread>>> GetForumThreads()
        {
            var data = await context.ForumThreads.ToListAsync();
            return Ok(data);
        }

        [HttpDelete("{threadid}")]
        public async Task<IActionResult> DeleteForumThreads(int threadid)
        {
            var forumthread = await context.ForumThreads.FindAsync(threadid);
            if (forumthread == null)
            {
                return NotFound(new { error = "ForumThread not found" });
            }

            context.ForumThreads.Remove(forumthread);
            await context.SaveChangesAsync();

            return Ok(new { message = "ForumThread deleted successfully", forumthread });
        }

        [HttpGet("lectures")]
        public async Task<ActionResult<List<Lecture>>> GetLectures()
        {
            var data = await context.Lectures.ToListAsync();
            return Ok(data);
        }


        [HttpDelete("{lectureId}")]
        public async Task<IActionResult> DeleteLectures(int lectureId)
        {
            var lecture = await context.Lectures.FindAsync(lectureId);
            if (lecture == null)
            {
                return NotFound(new { error = "Lecture not found" });
            }

            context.Lectures.Remove(lecture);
            await context.SaveChangesAsync();

            return Ok(new { message = "Lecture deleted successfully", lecture });
        }

        [HttpGet("quizzes")]
        public async Task<ActionResult<List<Quiz>>> GetQuizzes()
        {
            var data = await context.Quizzes.ToListAsync();
            return Ok(data);
        }

        [HttpDelete("{quizId}")]
        public async Task<IActionResult> DeleteQuizzes(int quizId)
        {
            var quiz = await context.Quizzes.FindAsync(quizId);
            if (quiz == null)
            {
                return NotFound(new { error = "Quiz not found" });
            }

            context.Quizzes.Remove(quiz);
            await context.SaveChangesAsync();

            return Ok(new { message = "Quiz deleted successfully", quiz });
        }

        [HttpGet("quizattempts")]
        public async Task<ActionResult<List<QuizAttempt>>> GetQuizAttempts()
        {
            var data = await context.QuizAttempts.ToListAsync();
            return Ok(data);
        }

        [HttpDelete("{attemptId}")]
        public async Task<IActionResult> DeleteQuizAttempts(int attemptId)
        {
            var attempt = await context.QuizAttempts.FindAsync(attemptId);
            if (attempt == null)
            {
                return NotFound(new { error = "QuizAttempt not found" });
            }

            context.QuizAttempts.Remove(attempt);
            await context.SaveChangesAsync();

            return Ok(new { message = "QuizAttempt deleted successfully", attempt });
        }

        [HttpGet("quizquestions")]
        public async Task<ActionResult<List<QuizQuestion>>> GetQuizQuestions()
        {
            var data = await context.QuizQuestions.ToListAsync();
            return Ok(data);
        }

        [HttpDelete("{quizquestionId}")]
        public async Task<IActionResult> DeleteQuizQuestions(int quizquestionId)
        {
            var question = await context.QuizQuestions.FindAsync(quizquestionId);
            if (question == null)
            {
                return NotFound(new { error = "QuizQuestion not found" });
            }

            context.QuizQuestions.Remove(question);
            await context.SaveChangesAsync();

            return Ok(new { message = "Quiz deleted successfully", question });
        }

        [HttpPost("register")]
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
