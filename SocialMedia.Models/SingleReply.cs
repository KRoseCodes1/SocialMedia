using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class SingleReply
    {
        public int Id { get; set; }
        [Display(Name="reply")]
        public string Text { get; set; }
        public int CommentId { get; set; }
    }
}
