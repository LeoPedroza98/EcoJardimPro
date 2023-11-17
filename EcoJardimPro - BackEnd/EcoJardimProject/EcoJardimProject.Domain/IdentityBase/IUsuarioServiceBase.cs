using EcoJardimProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimProject.Domain.IdentityBase
{
    public interface IUsuarioManagerBase<TUser> where TUser : Usuario
    {

    }
}
