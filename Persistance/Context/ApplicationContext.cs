using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umb.Domain;

namespace Umb.Persistance.Context
{
    public class ApplicationContext:IdentityDbContext<IdentityUser>
    {
        
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer("Server=UTKU\\SQLEXPRESS; Initial Catalog=UmbDb; Trusted_Connection = True; TrustServerCertificate = True; Encrypt = True; MultipleActiveResultSets = true;",
                     options => options.EnableRetryOnFailure()));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(b => !b.IsDeleted);

            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.DeletedTime).HasColumnName("DeletedTime");
                a.Property(p => p.CreatedTime).HasColumnName("CreatedTime");
                a.Property(p => p.CreatedTime).HasColumnName("CreatedTime");
                a.Property(p => p.IsDeleted).HasColumnName("IsDeleted");
                a.Property(p => p.Name).HasColumnName("Name");





            });
            User[] userEntitySeeds = {
                new(1,"bora",DateTime.Now,null,false),
                new(2,"cetin",DateTime.Now,null,false),
            };

            modelBuilder.Entity<User>().HasData(userEntitySeeds);

        }

    }
    
}
