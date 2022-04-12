using Beyond.IntegrationServices.PostsService.Payloads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Beyond.IntegrationServices.PostsService
{
    public class PostService
    {
        public static PostResponseVModel GetPosts()
        {
            PostResponseVModel result = new PostResponseVModel();
            try
            {
                result.result = new List<Post>();
                string url = string.Format("https://jsonplaceholder.typicode.com/posts");
                WebRequest webRequest = WebRequest.Create(url);
                webRequest.Method = "GET";
                //webRequest.Timeout = 3000; //milliseconds - can be set as per integration team discussion
                HttpWebResponse response = null;
                response = (HttpWebResponse)webRequest.GetResponse();
                string rawResponse = null;
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(stream);
                    rawResponse = streamReader.ReadToEnd();
                    stream.Close();
                }
                result.StatusCode = 200;
                result.result = JsonConvert.DeserializeObject<List<Post>>(rawResponse);
            }
            catch (Exception ex)
            {
                result.StatusCode = 400;
                //should be logged using the logger
            }
            return result;
        }
    }
}
