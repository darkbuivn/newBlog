using System;
using System.Collections.Generic;

namespace Blogs.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<TopicViewModel> Topics { get; set; }
    }
}