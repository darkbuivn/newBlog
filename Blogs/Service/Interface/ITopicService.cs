using Blog.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Service.Interface
{
    public interface ITopicService
    {
        Topic GetById(Guid Id);
        IEnumerable<Topic> GetAll();
        IEnumerable<Topic> GetByCategoryId(Guid categoryId);
        IEnumerable<Topic> Search(string keyword);
        void Create(Topic topic);
        IEnumerable<Topic> GetNew();
        void Update(Topic topic);
        IEnumerable<Topic> GetMore(Guid id);
        Topic GetNewest();
    }
}
