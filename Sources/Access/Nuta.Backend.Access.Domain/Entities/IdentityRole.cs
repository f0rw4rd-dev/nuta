using System.Diagnostics.CodeAnalysis;

namespace Nuta.Backend.Access.Domain.Entities;

public class IdentityRole : Microsoft.AspNetCore.Identity.IdentityRole<Guid>
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public IdentityRole()
    {
    }
    
    public IdentityRole(string roleName) : base(roleName)
    {
    }
};