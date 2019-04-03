using System;

namespace Blogs.ViewModels
{
    public class TopicViewModel
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}