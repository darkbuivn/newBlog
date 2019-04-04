using Blog.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Repository.Interface
{
    public interface ITopicRepository
    {
        Topic GetById(Guid Id);
        IEnumerable<Topic> GetAll(int size, int skip);        
        IEnumerable<Topic> GetAllIncludeCategory();
        IEnumerable<Topic> GetByCategoryId(Guid categoryId);
        IEnumerable<Topic> GetOrthersWithCategoryId(Guid categoryId, Guid Id);
        IEnumerable<Topic> GetNew();
        void Create(Topic topic);
        IEnumerable<Topic> GetMoreSameCategory(Guid CategoryId);
        IEnumerable<Topic> GetMore(DateTime CreatedDate);
        Topic GetNewest();
        IEnumerable<Topic> Search(string searchstr);
        int Count(string searchstr = null);
        void Update(Topic topic);
    }
}
