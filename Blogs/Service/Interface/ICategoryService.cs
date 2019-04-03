using Blog.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Service.Interface
{
    public interface ICategoryService
    {
        bool IsExisting(string categoryName);
        Category GetById(Guid id);
        Category GetByIdIncludeTopic(int id);
        IEnumerable<Category> GetAll();
        void Create(string name);
        void Update(Category category);
    }
}
