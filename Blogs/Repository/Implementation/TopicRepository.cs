using Blog.Entities;
using Blog.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Repository.Implementation
{
    public class TopicRepository : BaseRepository, ITopicRepository
    {
        public Topic GetById(Guid Id)
        {
            return dbCon.Topics.Where(x => x.Id == Id).FirstOrDefault();
        }

        //public Topic GetByIdWithCategory(Guid Id)
        //{
        //    return dbCon.Topics.Where(x => x.Id == Id).FirstOrDefault();
        //}

        public IEnumerable<Topic> GetAll(int size, int skip)
        {
            return dbCon.Topics.Skip(skip).Take(size).ToList();
        }

        public IEnumerable<Topic> GetAllIncludeCategory()
        {
            return dbCon.Topics.ToList();
        }

        public IEnumerable<Topic> GetByCategoryId(Guid categoryId, int size, int skip)
        {
            return dbCon.Topics.Where(x => x.CategoryId == categoryId)
                .OrderByDescending(x => x.CreatedDate).Skip(skip).Take(size).ToList();
        }

        public IEnumerable<Topic> GetOrthersWithCategoryId(Guid categoryId, Guid Id)
        {
            return dbCon.Topics.Where(x => x.CategoryId == categoryId).Where(x => x.Id != Id).ToList();
        }

        public IEnumerable<Topic> GetNew()
        {
            return dbCon.Topics.OrderByDescending(x => x.CreatedDate).Take(5).ToList();
        }

        public void Create(Topic topic)
        {
            topic.CreatedDate = DateTime.UtcNow;
            topic.UpdatedDate = DateTime.UtcNow;
            dbCon.Topics.Add(topic);
            dbCon.SaveChanges();
        }

        public IEnumerable<Topic> GetMoreSameCategory(Guid categoryId, DateTime createdDate)
        {
            return dbCon.Topics.Where(x => x.CategoryId == categoryId && x.CreatedDate > createdDate)
                .OrderByDescending(x => x.CreatedDate).Take(5).ToList();
        }
        public IEnumerable<Topic> GetMore(DateTime CreatedDate)
        {
            return dbCon.Topics.Where(x => x.CreatedDate > CreatedDate).OrderByDescending(x => x.CreatedDate).Take(5).ToList();
        }

        public Topic GetNewest()
        {
            return dbCon.Topics.OrderByDescending(x => x.CreatedDate).FirstOrDefault();
        }

        public IEnumerable<Topic> Search(string searchstr)
        {
            return dbCon.Topics.Where(x => x.Title.Contains(searchstr) || x.ShortDesc.Contains(searchstr) || x.Content.Contains(searchstr)).ToList();
        }

        public void Update(Topic topic)
        {
            Topic _topic = dbCon.Topics.SingleOrDefault(x => x.Id == topic.Id);
            if (_topic != null)
            {
                _topic.ShortDesc = topic.ShortDesc;
                _topic.Content = topic.Content;
                _topic.CategoryId = topic.CategoryId;
                _topic.Title = topic.Title;
                _topic.Image = topic.Image;
                _topic.UpdatedDate = DateTime.UtcNow;
                dbCon.SaveChanges();
            }
        }

        public IEnumerable<Topic> GetMoreSameCategory(Guid CategoryId)
        {
            throw new NotImplementedException();
        }

        public int Count(string searchstr = null)
        {
            if(string.IsNullOrWhiteSpace(searchstr))
            {
                return dbCon.Topics.Count();
            }
            return dbCon.Topics.Count(x => x.Title.Contains(searchstr) || x.ShortDesc.Contains(searchstr) || x.Content.Contains(searchstr));
        }
    }
}
