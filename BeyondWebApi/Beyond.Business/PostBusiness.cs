using System;
using System.Collections.Generic;
using System.Linq;
using Beyond.IntegrationServices.PostsService;
using Beyond.IntegrationServices.PostsService.Payloads;

namespace Beyond.Business
{
    public class PostBusiness
    {
        public PostResponseVModel CallExternalPostApi(string keyword)
        {
            PostResponseVModel posts = PostService.GetPosts();
            List<Post> filteredPosts = new List<Post>();
            if (posts.StatusCode == 200 && posts.result != null && !string.IsNullOrEmpty(keyword))
            {
                filteredPosts = posts.result.Where(p => p.body.Contains(keyword)).ToList();
                posts.result = filteredPosts.OrderBy(p => p.id).ToList();
            }
            return posts;
        }
    }
}
