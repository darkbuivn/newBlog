using System.Collections.Generic;

namespace Blog.Service.Business.Topic
{
    public class TopicsSearchResult
    {
        public IEnumerable<Entities.Topic> Topics { get; set; }
        public int TotalTopics { get; set; }
    }
}
