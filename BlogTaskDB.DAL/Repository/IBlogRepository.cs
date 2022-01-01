using BlogTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Repository
{
   public interface IBlogRepository
    {
        IEnumerable<Blog> GetAll();
        Blog GetByID(int id);
        void Add(Blog blog);
        void Delete(int id);
        void Update(Blog blog);
        bool Save();
    }
}
