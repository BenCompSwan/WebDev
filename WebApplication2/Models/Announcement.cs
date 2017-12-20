using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Announcement
    {
        public int AnnouncementId { get; set; }
        public string AnnouncementTitle { get; set; }
        public string AnnouncementBody { get; set; }
        //public int NumberOfViews { get; set; }

        public string ApplicationUserForeignKey { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
