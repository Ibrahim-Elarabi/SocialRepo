using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTaskDB.DAL.ViewModels
{
    public  class SearchDataVM
    {
        public string SearchText { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        public string [] SelectedIds { get; set; }
        public int GroupID { get; set; }
        public int PageIndex { get; set; }


    }
}
