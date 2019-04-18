using Blog.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Repository.Interface
{
    public interface ICategoryRepository
    {
        Category GetById(Guid id);
        List<Category> GetAll();
        Category Create(string name);
        void Update(Category category);
        void Delete(Category category);
        bool IsExisting(string name);
    }
}
