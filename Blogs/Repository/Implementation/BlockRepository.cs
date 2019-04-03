using Blog.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Entities;

namespace Blog.Repository.Implementation
{
    public class BlockRepository: BaseRepository, IBlockRepository
    {
        public void Active(Guid id)
        {
            Block block = dbCon.Blocks.SingleOrDefault(x => x.Id == id);
            if (block != null)
            {
                Active(block);
                dbCon.SaveChanges();
            }
        }

        void Active(Block blk)
        {
            blk.status = true;
        }

        public void Create(Block block)
        {
            dbCon.Blocks.Add(block);
            dbCon.SaveChanges();
        }

        public void Deactive(Guid id)
        {
            Block block = dbCon.Blocks.SingleOrDefault(x => x.Id == id);
            if (block != null)
            {
                block.status = false;
                dbCon.SaveChanges();
            }
        }

        public void Delete(Block block)
        {
            dbCon.Blocks.Remove(block);
            dbCon.SaveChanges();
        }

        public List<Block> GetAll()
        {
            return dbCon.Blocks.ToList();
        }

        public Block GetById(Guid id)
        {
            return dbCon.Blocks.Find(id);
        }

        public void Update(Block block)
        {
            Block _block = dbCon.Blocks.SingleOrDefault(x => x.Id == block.Id);
            if (_block != null)
            {
                _block.status = block.status;
                _block.Name = block.Name;
                _block.Content = block.Content;
                dbCon.SaveChanges();
            }
        }
    }
}
