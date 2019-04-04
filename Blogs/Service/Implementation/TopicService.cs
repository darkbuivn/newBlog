using Blog.Service.Interface;
using System;
using System.Collections.Generic;
using Blog.Entities;
using Blog.Repository.Interface;
using Blog.Service.Business;

namespace Blog.Service.Implementation
{
    public class TopicService : ITopicService
    {
        private ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }
        public void Create(Topic topic)
        {
            _topicRepository.Create(topic);
        }

        public TopicsSearchResult GetAll(int size, int skip)
        {
            TopicsSearchResult res = new TopicsSearchResult()
            {
                Topics = _topicRepository.GetAll(size, skip),
                TotalTopics = _topicRepository.Count()
            };

            return res;
        }

        public IEnumerable<Topic> GetByCategoryId(Guid categoryId)
        {
            return _topicRepository.GetByCategoryId(categoryId);
        }

        public Topic GetById(Guid Id)
        {
            return _topicRepository.GetById(Id);
        }

        public IEnumerable<Topic> GetMore(Guid id)
        {
            Topic topic = _topicRepository.GetById(id);
            return _topicRepository.GetMore(topic.CreatedDate);
        }

        public IEnumerable<Topic> GetNew()
        {
            return _topicRepository.GetNew();
        }

        public Topic GetNewest()
        {
            return _topicRepository.GetNewest();
        }

        public IEnumerable<Topic> Search(string keyword)
        {
            return _topicRepository.Search(keyword);
        }

        public void Update(Topic topic)
        {
            _topicRepository.Update(topic);
        }
    }
}
