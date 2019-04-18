using Blog.Entities;
using Blog.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Repository.Implementation
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public Category GetById(Guid id)
        {
            return dbCon.Categories.Find(id);
        }

        public List<Category> GetAll()
        {
            return dbCon.Categories.ToList();
        }

        public Category Create(string name)
        {
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = name                
            };           
            dbCon.Categories.Add(category);
            dbCon.SaveChanges();

            return category;
        }

        public void Update(Category category)
        {
            Category _category = dbCon.Categories.SingleOrDefault(x => x.Id == category.Id);
            if (_category != null)
            {
                _category.Name = category.Name;
                dbCon.SaveChanges();
            }
        }

        public void Delete(Category category)
        {
            dbCon.Categories.Remove(category);
            dbCon.SaveChanges();
        }

        public bool IsExisting(string name)
        {
            return dbCon.Categories.SingleOrDefault(
                x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)) != null;          
        }
    }
}
