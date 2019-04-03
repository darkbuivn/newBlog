using Blog.Service.Interface;
using System;
using System.Collections.Generic;
using Blog.Entities;
using Blog.Repository.Interface;

namespace Blog.Service.Implementation
{
    public class BlockService : IBlockService
    {
        IBlockRepository _blockRepository;

        public BlockService(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public void Active(Guid id)
        {
            _blockRepository.Active(id);
        }

        public void Create(Block block)
        {
            _blockRepository.Create(block);
        }

        public void Deactive(Guid id)
        {
            _blockRepository.Deactive(id);
        }

        public void Delete(Block block)
        {
            _blockRepository.Delete(block);
        }

        public IEnumerable<Block> GetAll()
        {
            return _blockRepository.GetAll();
        }

        public Block GetById(Guid id)
        {
            return _blockRepository.GetById(id);
        }

        public void Update(Block block)
        {
            _blockRepository.Update(block);
        }
    }
}
