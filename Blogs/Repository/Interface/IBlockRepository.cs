using Blog.Entities;
using System;
using System.Collections.Generic;

namespace Blog.Repository.Interface
{
    public interface IBlockRepository
    {
        Block GetById(Guid id);
        List<Block> GetAll();
        void Create(Block block);
        void Active(Guid id);
        void Deactive(Guid id);
        void Update(Block block);
        void Delete(Block block);
    }
}
