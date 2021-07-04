using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMoodle.Shared;

namespace WebMoodle.Client.Services
{
    interface IMoodleService
    {
        Task<List<MoodlePost>> GetMoodlePosts();
        Task<MoodlePost> GetMoodlePostByUrl(string url);
        Task<MoodlePost> CreateNewMoodlePost(MoodlePost request);

    }
}
