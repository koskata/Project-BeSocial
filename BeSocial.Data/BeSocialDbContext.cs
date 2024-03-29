﻿using BeSocial.Data.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeSocial.Data
{
    public class BeSocialDbContext : IdentityDbContext
    {
        public BeSocialDbContext(DbContextOptions<BeSocialDbContext> options)
            : base(options)
        {
        }


        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupCategory> GroupCategories { get; set; }
        public DbSet<GroupParticipant> GroupParticipants { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostLiker> PostLikers { get; set; }

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
            

            base.OnModelCreating(builder);
        }
    }
}