using System;
using System.ComponentModel.DataAnnotations;
using static Common.Contant;

namespace Blog.Entities
{
    public class Block
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool status { get; set; }
        public BlockPosition Position { get; set; }
    }
}