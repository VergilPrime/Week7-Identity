using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Models
{
    public class ServerPage : PreServerPage
    {

        // Used to determine uptime, uptime is successfulqueries / totalqueries.
        public long TotalQueries { get; set; }
        
        public long SuccessfulQueries { get; set; }

        public long CreatedDate { get; set; }

        public ServerPage()
        {
            
        }
    }
}
