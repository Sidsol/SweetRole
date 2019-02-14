using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SweetRole.Areas.Identity.Data;


namespace SweetRole.Models
{
    public class SweetRoleContext : IdentityDbContext<SweetRoleUser>
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Scene> Scenes { get; set; }

        public SweetRoleContext(DbContextOptions<SweetRoleContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<CharacterScene>()
                .HasKey(bc => new { bc.CharacterId, bc.SceneId });

            builder.Entity<CharacterScene>()
                .HasOne(bc => bc.Character)
                .WithMany(b => b.CharacterScenes)
                .HasForeignKey(bc => bc.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<CharacterScene>()
                .HasOne(bc => bc.Scene)
                .WithMany(c => c.CharacterScenes)
                .HasForeignKey(bc => bc.SceneId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
