using BeSocial.Data.Configuration;
using BeSocial.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeSocial.Data
{
    public class BeSocialDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;
        public BeSocialDbContext(DbContextOptions<BeSocialDbContext> options, bool seedDb = true)
            : base(options)
        {
            if (!Database.IsRelational())
            {
                Database.EnsureCreated();
            }
            this.seedDb = seedDb;
        }


        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GroupParticipant> GroupParticipants { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLiker> PostLikers { get; set; }
        public DbSet<PremiumUser> PremiumUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PostLiker>()
                .HasKey(pl => new { pl.LikerId, pl.PostId });

            builder.Entity<PostLiker>()
                .HasOne(x => x.Post)
                .WithMany(x => x.PostLikers)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<GroupParticipant>()
                .HasKey(gp => new { gp.GroupId, gp.ParticipantId });

            builder.Entity<GroupParticipant>()
                .HasOne(x => x.Group)
                .WithMany(x => x.GroupParticipants)
                .HasForeignKey(x => x.GroupId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Comment>()
                .HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);

            if (seedDb)
            {
                builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
                builder.ApplyConfiguration(new CategoryEntityConfiguration());
                builder.ApplyConfiguration(new GroupEntityConfiguration());
                builder.ApplyConfiguration(new PostEntityConfiguration());
                builder.ApplyConfiguration(new PremiumUserEntityConfiguration());
                builder.ApplyConfiguration(new GroupParticipantEntityConfiguration());
            }
            

            base.OnModelCreating(builder);
        }
    }
}