using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoutingAspNetCoreDemo.RazorPages.Areas.Blog.Pages
{
    public class DateArticleModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Year { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Month { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Day { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }

        public DateTime PublishDate { get; set; }
        public void OnGet()
        {
            PublishDate = new DateTime(Year, Month, Day);
        }
    }
}
