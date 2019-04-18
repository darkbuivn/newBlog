using Blog.Service.Interface;
using System;
using System.Collections.Generic;
using Blog.Entities;
using Blog.Repository.Interface;

namespace Blog.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepository = categoryRepo;
        }

        public Category Create(string name)
        {
           return _categoryRepository.Create(name);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(Guid id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetByIdIncludeTopic(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExisting(string categoryName)
        {
            return _categoryRepository.IsExisting(categoryName);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
