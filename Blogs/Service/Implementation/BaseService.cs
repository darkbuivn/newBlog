using Blog.Repository.Implementation;
using Blog.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Implementation
{
    public class BaseService
    {
        protected ITopicRepository _topicRepository;
        protected ICategoryRepository _categoryRepository;
        protected IBlockRepository _blockRepository;
        public BaseService(ITopicRepository topicRepository, ICategoryRepository categoryRepository, IBlockRepository blockRepository)
        {
            _topicRepository = topicRepository;
            _categoryRepository = categoryRepository;
            _blockRepository = blockRepository;
        }
    }
}
