using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTask.Models
{
    public class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }
        [Key]
        public int BlogId { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="Must Be less Than 20 Char")]
        public string Name { get; set; }
        public string  Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

    }
}
