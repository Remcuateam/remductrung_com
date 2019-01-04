using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AspNetMvc.Data.EF.Configurations;
using AspNetMvc.Data.EF.Extensions;
using AspNetMvc.Data.Entities;
using AspNetMvc.Data.Entities.Advertistment;
using AspNetMvc.Data.Entities.Content;
using AspNetMvc.Data.Entities.System;
using AspNetMvc.Data.Interfaces;
using AspNetMvc.Data.Entities.ECommerce;
using AspNetMvc.Infrastructure.SharedKernel;

namespace AspNetMvc.Data.EF
{
    /// <summary>
    /// AppDbContext inherit from IdentityDbContext:
    /// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    /// (NuGet Packages)
    /// Microsoft.AspNetCore.Identity (2.0.0)
    /// Microsoft.AspNetCore.Identity.EntityFrameworkCore (2.0.0)
    /// </summary>
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        /// DbContextOptions:
        /// using Microsoft.EntityFrameworkCore;
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// public DbSet<TEntity> where TEntity : class
        /// using Microsoft.EntityFrameworkCore;
        /// </summary>
        #region DbSet
        #region System
        public DbSet<AppRole> AppRoles { set; get; }
        public DbSet<AppUser> AppUsers { set; get; }
        public DbSet<Function> Functions { set; get; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Setting> SystemConfigs { get; set; }
        //public DbSet<Menu> Menus { set; get; }
        public DbSet<Error> Errors { set; get; }
        public DbSet<Language> Languages { set; get; }
        public DbSet<Announcement> Announcements { set; get; }
        public DbSet<AnnouncementUser> AnnouncementUsers { set; get; }
        #endregion System

        #region Production
        public DbSet<ProductCategory> ProductCategories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }   
        public DbSet<ProductImage> ProductImages { set; get; }
        public DbSet<ProductWishlist> ProductWishlists { set; get; }
        public DbSet<ProductQuantity> ProductQuantities { set; get; }
        public DbSet<Size> Sizes { set; get; }
        public DbSet<Color> Colors { set; get; }
        public DbSet<Bill> Bills { set; get; }
        public DbSet<BillDetail> BillDetails { set; get; }
        public DbSet<WholePrice> WholePrices { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { set; get; }
        public DbSet<Entities.ECommerce.Attribute> Attributes { set; get; }
        public DbSet<AttributeDescription> AttributeDescriptions { set; get; }
        public DbSet<AttributeGroup> AttributeGroups { set; get; }
        public DbSet<AttributeGroupDescription> AttributeGroupDescription { set; get; }
        #endregion Production

        #region Content
        public DbSet<PostCategory> PostCategories { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<PostTag> PostTags { set; get; }     
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<Page> Pages { set; get; }
        public DbSet<Slide> Slides { set; get; }
        public DbSet<Feedback> Feedbacks { set; get; }
        public DbSet<Footer> Footers { set; get; }
        #endregion Content

        #region Advertistment
        public DbSet<Advertistment> Advertistments { get; set; }
        public DbSet<AdvertistmentPage> AdvertistmentPages { get; set; }
        public DbSet<AdvertistmentPosition> AdvertistmentPositions { get; set; }
        #endregion Advertistment      
        #endregion DbSet

        /// <summary>
        /// ModelBuilder
        /// using Microsoft.EntityFrameworkCore;
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /// IdentityUserClaim, IdentityRoleClaim, IdentityUserLogin, IdentityUserRole, IdentityUserToken
            /// using Microsoft.AspNetCore.Identity;        
            #region Identity Config
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });
            #endregion Identity Config

            builder.AddConfiguration(new AdvertistmentPageConfiguration());
            builder.AddConfiguration(new AdvertistmentPositionConfiguration());         
            builder.AddConfiguration(new ContactConfiguration());
            builder.AddConfiguration(new ErrorConfiguration());
            builder.AddConfiguration(new FooterConfiguration());
            builder.AddConfiguration(new FunctionConfiguration());
            builder.AddConfiguration(new LanguageConfiguration());
            builder.AddConfiguration(new SystemConfigConfiguration());
            builder.AddConfiguration(new TagConfiguration());

            //base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            try
            {
                /// Using Linq:
                /// using System.Linq;

                /// enum EntityState
                /// using Microsoft.EntityFrameworkCore;
                var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

                /// EntityEntry
                /// using Microsoft.EntityFrameworkCore.ChangeTracking;
                foreach (EntityEntry item in modified)
                {
                    //var changedOrAddedItem = item.Entity as IDateTracking;
                    //if (changedOrAddedItem != null)
                    if(item.Entity is IDateTracking changedOrAddedItem)
                    {
                        if(item.State == EntityState.Added)
                        {
                            changedOrAddedItem.CreatedDate = DateTime.Now;
                        }                       
                            changedOrAddedItem.UpdatedDate = DateTime.Now;                                             
                            //changedOrAddedItem.DeletedDate = DateTime.Now;                       
                    }
                }
                return base.SaveChanges();
            }
            /// DbUpdateException
            /// using Microsoft.EntityFrameworkCore;
            catch (DbUpdateException entityException)
            {
                throw new ModelValidationException(entityException.Message);
            }
            //return base.SaveChanges();
        }

        /// <summary>
        /// IDesignTimeDbContextFactory
        /// using Microsoft.EntityFrameworkCore.Design;
        /// </summary>
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                /// Iconfiguration
                /// ConfigurationBuilder
                /// using Microsoft.Extensions.Configuration;
                IConfiguration configuration = new ConfigurationBuilder()
                
                /// SetBasePath
                /// using Microsoft.Extensions.Configuration.FileExtensions
                /// using Microsoft.Extensions.Configuration.Json
                /// 
                /// Directory
                /// using Sytem.IO
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();

                /// DbContextOptionsBuilder
                /// using Microsoft.EntityFrameworkCore;
                var builder = new DbContextOptionsBuilder<AppDbContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new AppDbContext(builder.Options);
            }
        }
    }
}
