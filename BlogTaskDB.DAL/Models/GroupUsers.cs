using BlogTask.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Models
{
    public enum StatusRequset:byte
    {
        Pending =1,
        Accept = 2,
        Reject =3
    }

    public class GroupUser
    { 
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Group))]
        public int?  GroupID { get; set; }
        [ForeignKey("IdentityUser")]
        public string UserId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        //public bool IsRequest { get; set; }
        //this Is enum 
        public StatusRequset? StatusRequset { get; set; }
  
        public virtual Group Group { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
