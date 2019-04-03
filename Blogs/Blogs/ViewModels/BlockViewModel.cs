using System;
using static Common.Contant;

namespace Blogs.ViewModels
{
    public class BlockViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool status { get; set; }
        public BlockPosition Position { get; set; }
    }
}