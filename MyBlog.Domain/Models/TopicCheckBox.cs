using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Models
{
    public class TopicCheckBox
    {
        public string TopicName { get; set; }
        public bool IsSelected { get; set; }
        public TopicCheckBox()
        {
            this.IsSelected = false;
        }
    }
}
