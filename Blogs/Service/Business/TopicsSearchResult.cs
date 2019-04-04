using Blog.Entities;
using System.Collections.Generic;

namespace Blog.Service.Business
{
    public class TopicsSearchResult
    {
        public IEnumerable<Topic> Topics { get; set; }
        public int TotalTopics { get; set; }
    }
}
