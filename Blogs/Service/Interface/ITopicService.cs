using Blog.Entities;
using Blog.Service.Business.Topic;
using System;
using System.Collections.Generic;

namespace Blog.Service.Interface
{
    public interface ITopicService
    {
        Topic GetById(Guid Id);
        TopicsSearchResult GetAll(int size, int skip);
        IEnumerable<Topic> GetByCategoryId(Guid categoryId, int size, int skip);
        IEnumerable<Topic> Search(string keyword);
        void Create(Topic topic);
        IEnumerable<Topic> GetNew();
        void Update(Topic topic);
        IEnumerable<Topic> GetMore(Guid id);
        Topic GetNewest();
    }
}
