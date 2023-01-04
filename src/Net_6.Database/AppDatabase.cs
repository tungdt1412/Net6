﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Net_6.Database.Entities;

namespace Net_6.Database
{
    public class AppDatabase : IdentityDbContext<User>
    {
        public AppDatabase()
        {

        }

        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlServer();

        public virtual DbSet<Author> Authors => Set<Author>();
        public virtual DbSet<Category> Categories => Set<Category>();
        public virtual DbSet<Comment> Comments => Set<Comment>();
        public virtual DbSet<PlayList> PlayLists => Set<PlayList>();
        public virtual DbSet<PlayListVideo> PlayListVideos => Set<PlayListVideo>();
        public virtual DbSet<Post> Post => Set<Post>();
        public virtual DbSet<PostCategory> PostCategories => Set<PostCategory>();
        public virtual DbSet<PostRelated> PostRelateds => Set<PostRelated>();
        public virtual DbSet<PostTag> PostTags => Set<PostTag>();
        public virtual DbSet<PostType> PostTypes => Set<PostType>();
        public virtual DbSet<SitePage> SitePages => Set<SitePage>();
        public virtual DbSet<Tag> Tags => Set<Tag>();
        public virtual DbSet<Video> Videos => Set<Video>();
        public virtual DbSet<VideoTag> VideoTags => Set<VideoTag>();
    }
}