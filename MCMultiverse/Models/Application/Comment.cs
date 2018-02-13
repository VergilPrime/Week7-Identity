﻿using MCMultiverse.Data;
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
        public int Id { get; set; }
        public int Timestamp { get; set; }
        public string Text { get; set; }
        [NotMapped]
        public List<Comment> Replies { get; set; }

        // What is this a comment on? Server, Comment...
        public string Type { get; set; }
        public int OnId { get; set; }
    }
}
