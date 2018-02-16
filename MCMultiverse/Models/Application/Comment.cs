using MCMultiverse.Data;
using MCMultiverse.Models.Application.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Models.Application
{
    public class Comment
    {
        public ApplicationUser Author { get; set; }
        public int Id { get; set; }
        public int TimeStamp { get; }
        public string Text { get; set; }
        public ICollection<Comment> Replies { get; set; }

        // What is this a comment on? Server, Comment...
        public MCServer ServerParent { get; set; }
        public Comment CommentParent { get; set; }
        public string Type { get; set; }
        public int OnId { get; set; }

        public Comment()
        {
            TimeStamp = Clock.Time();
        }
    }
}
