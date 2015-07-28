using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Models
{
    public class Topic : AuditObject
    {
        [Key]
        public int Id { get; set; }
        public string TopicName { get; set; }
        public bool IsSpecific { get; set; }
        

        //Relationship
        public ICollection<BlogGroup> BlogGroups { get; set; }


        public Topic()
        {
            this.IsActive = true;
        }


    }
}
