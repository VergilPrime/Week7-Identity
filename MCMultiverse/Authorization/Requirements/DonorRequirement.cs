using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCMultiverse.Authorization.Requirements
{
    public class DonorRequirement : IAuthorizationRequirement
    {
        public int DonorRank { get; set; }

        public DonorRequirement()
        {

        }


        public DonorRequirement(int donorRank)
        {

        }
    }
}
