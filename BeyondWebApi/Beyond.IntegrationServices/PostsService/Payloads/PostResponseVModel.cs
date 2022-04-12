using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.IntegrationServices.PostsService.Payloads
{

    public class PostResponseVModel
    {
        public List<Post> result { get; set; }
        public int StatusCode { get; set; }
    }
    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
