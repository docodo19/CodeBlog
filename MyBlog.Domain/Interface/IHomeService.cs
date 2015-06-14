using MyBlog.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Interface
{
    public interface IHomeService
    {
        HomeIndexViewModel GetHomeIndexViewModel(string userId);
    }
}
