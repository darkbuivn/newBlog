using Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Implementation
{
    public class BaseRepository
    {
        protected DbCon dbCon = new DbCon();
    }
}
