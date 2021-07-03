using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebMoodle.Shared;

namespace WebMoodle.Client.Services
{
    public class MoodleService : IMoodleService
    {
        private readonly HttpClient _http;

        public MoodleService(HttpClient http)

        {
            _http = http;
        }
    
        public async Task<MoodlePost> GetMoodlePostByUrl(string url)
        {
            

            var result = await _http.GetAsync($"api/Moodle/{url}");
            if(result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new MoodlePost { Title = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<MoodlePost>();
            }

        }

        public async Task<List<MoodlePost>> GetMoodlePosts()
        {
            return await _http.GetFromJsonAsync<List<MoodlePost>>("api/Moodle");
        }
    }
}
