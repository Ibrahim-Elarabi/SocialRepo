using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTaskDB.DAL.ViewModels
{
    public  class GroupVM
    {
        public int GroupID { get; set; }
       
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
