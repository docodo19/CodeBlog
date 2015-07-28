using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Models
{
    public class BlogGroup : AuditObject
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Blog Group")]
        [Required(ErrorMessage="Group Name is Required")]
        public string GroupName { get; set; }

        [DisplayName("Description")]
        public string GroupDescription { get; set; }

        public string User_Id { get; set; }
        [ForeignKey("User_Id")]
        public ApplicationUser User { get; set; }

        //Relationship
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Topic> Topics { get; set; }


        public BlogGroup()
        {
            this.IsActive = true;
        }
    }
}
