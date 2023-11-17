using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EcoJardimProject.Domain.IdentityBase;

namespace EcoJardimProject.Data.Context;

public class EcoJardimProjectContextBase<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey>
    where TUser : IdentityUser<TKey>
    where TRole : IdentityRole<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly ISessaoUsuario _sessaoUsuario;

    public EcoJardimProjectContextBase(DbContextOptions options, ISessaoUsuario sessaoUsuario) : base(options)
    {
        _sessaoUsuario = sessaoUsuario;
    }
}
