using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Models
{
    public enum Topic
    {
        [DescriptionAttribute("ASP.NET")]
        ASPNET,
        JavaScript,
        AngularJS,
        HTML,
        CSS,
        Bootstrap,
        Other
    }
}
