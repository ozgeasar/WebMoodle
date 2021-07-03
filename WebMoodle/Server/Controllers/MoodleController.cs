using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMoodle.Server.Data;
using WebMoodle.Shared;

namespace WebMoodle.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodleController : ControllerBase
    {
        private readonly DataContext _context;


        public MoodleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<MoodlePost>> GimmeAllTheMoodlePosts()
        {
            return Ok(_context.MoodlePosts);
        }

        [HttpGet("{url}")]
        public ActionResult<MoodlePost> GimmeThatSingleMoodlePost(string url)
        {
            var post = _context.MoodlePosts.FirstOrDefault(p => p.Url.ToLower().Equals(url.ToLower()));
            if (post == null)
            {
                return NotFound("not exist");
            }
            return Ok(post);
        }
    }
}
