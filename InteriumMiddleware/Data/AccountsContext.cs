using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InteriumMiddleware.Models;

    public class AccountsContext : DbContext
    {
        public AccountsContext (DbContextOptions<AccountsContext> options)
            : base(options)
        {
        }

        public DbSet<InteriumMiddleware.Models.Account> Account { get; set; }
    }
