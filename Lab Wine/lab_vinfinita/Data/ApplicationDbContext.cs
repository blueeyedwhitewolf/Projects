using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace lab_vinfinita.Data
{
    public class ProjetoContext : IdentityDbContext
    {
        public ProjetoContext(DbContextOptions<ProjetoContext> options)
            : base(options)
        {
        }
    }
}
