using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatMashAPI.Models
{
    public class User : IdentityUser<int>
    {
        public IList<Vote> Votes { get; set; }
    }
}
