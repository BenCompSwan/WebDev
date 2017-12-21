using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class AnnounceCommentViewModel
    {
        public Announcement announcement { get; set; }

        public List<Comment> comments { get; set; }
    }
}
