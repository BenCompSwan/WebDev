using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public string CommentBody { get; set; }

        public string ApplicationUserForeignKey { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int AnnouncementForeignKey { get; set; }
        public Announcement Announcement { get; set; }
    }
}
