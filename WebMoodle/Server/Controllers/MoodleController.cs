using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMoodle.Shared;

namespace WebMoodle.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodleController : ControllerBase
    {
        public List<MoodlePost> Posts { get; set; } = new List<MoodlePost>()
        {
            new MoodlePost { Url = "semester", Title= "-Spring-Semester Announcement-", Description = "Exams in the spring semester will start from June.", Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."},
            new MoodlePost { Url = "homework", Title= "-About Homework-", Description="The scoring of the assignment has been changed. Detailed information has been shared with you.", Content="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."}
        };

        [HttpGet]
        public ActionResult<List<MoodlePost>> GimmeAllTheMoodlePosts()
        {
            return Ok(Posts);
        }

        [HttpGet("{url}")]
        public ActionResult<MoodlePost> GimmeThatSingleBlogPost(string url)
        {
            var post = Posts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null)
            {
                return NotFound("not exist");
            }
            return Ok(post);
        }
    }
}
