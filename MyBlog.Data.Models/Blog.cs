using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? LastModified { get; set; }
        public Topic Topic { get; set; }

        public string User_Id { get; set; }
        [ForeignKey("User_Id")]
        public ApplicationUser User { get; set; }
    }
}
