using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Models
{
    public class Blog : AuditObject
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }


        public int BlogGroup_Id { get; set; }
        [ForeignKey("BlogGroup_Id")]
        public BlogGroup BlogGroup { get; set; }



        //Relationship
        
        
    }
}
