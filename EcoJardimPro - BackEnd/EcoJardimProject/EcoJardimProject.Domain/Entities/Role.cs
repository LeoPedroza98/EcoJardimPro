using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimProject.Domain.Entities
{
    public class Role: IdentityRole
    {
      public Role() { }
    public Role(string name):base(name) { }
    }
}
