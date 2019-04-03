using Blog.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Service.Interface
{
    public interface IBlockService
    {
        Block GetById(Guid id);
        IEnumerable<Block> GetAll();
        void Create(Block block);
        void Active(Guid id);
        void Deactive(Guid id);
        void Update(Block block);
        void Delete(Block block);
    }
}
