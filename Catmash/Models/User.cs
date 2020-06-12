using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Catmash.Models
{
    public class User : IdentityUser<int>
    {
        public IList<Vote> Votes { get; set; }
    }
}
