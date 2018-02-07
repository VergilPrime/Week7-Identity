using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Models
{
    public class PreServerPage
    {

        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Tagline { get; set; }
        
        public string Url { get; set; }
    }
}
