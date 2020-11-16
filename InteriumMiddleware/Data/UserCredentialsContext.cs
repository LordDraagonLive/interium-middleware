using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InteriumMiddleware.Models;

    public class UserCredentialsContext : DbContext
    {
        public UserCredentialsContext (DbContextOptions<UserCredentialsContext> options)
            : base(options)
        {

        }
    //    protected override void OnModelCreating(ModelBuilder builder)
    //    {
    //        builder.Entity<UserCredential>().HasKey(t => new { t.ClientId, t.AccessToken, t.ExchangeCode });
    //}

    public DbSet<InteriumMiddleware.Models.UserCredential> UserCredential { get; set; }
}
