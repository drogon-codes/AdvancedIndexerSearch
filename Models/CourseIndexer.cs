using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAPICoreClientAppCS.Models
{
    public class CourseIndexer
    {
        private static List<MyCourse> courses = new List<MyCourse>();

        private HttpClient httpClient = new HttpClient();

        private string url = "";
        public CourseIndexer()
        {
            url = @"http://localhost:12737/api/CourseAPI";
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _ = getCourses();
        }

        private async Task getCourses()
        {
            var msg = await httpClient.GetAsync(url);
            var CourseResponse = msg.Content.ReadAsStringAsync();

            courses = JsonConvert.DeserializeObject<List<MyCourse>>(CourseResponse.Result);
        }
        public List<MyCourse> this[string courseName]
        {
            get
            {
                return (from c in courses
                        where c.CourseName.StartsWith(courseName)
                        select c).ToList();
            }
        }

        public List<MyCourse> this[int min, int max]
        {
            get
            {
                return (from c in courses
                        where c.CourseId >= min && c.CourseId <= max
                        select c).ToList();
            }
        }
    }
}
