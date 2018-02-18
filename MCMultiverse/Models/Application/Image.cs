using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Models.Application
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string DataContentType { get; set; }
        public MCServer MCServer { get; set; }
    }
}
