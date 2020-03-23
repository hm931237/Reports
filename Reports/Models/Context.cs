namespace Reports.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustType> CustTypes { get; set; }
        public virtual DbSet<FundRight> FundRights { get; set; }
        public virtual DbSet<Fund> Funds { get; set; }
        public virtual DbSet<FundTime> FundTimes { get; set; }
        public virtual DbSet<GroupRight> GroupRights { get; set; }
        public virtual DbSet<ICPrice> ICPrices { get; set; }
        public virtual DbSet<LastCode> LastCodes { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Redemption> Redemptions { get; set; }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Tran> Trans { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserIdentityType> UserIdentityTypes { get; set; }
        public virtual DbSet<UserSecurity> UserSecurities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUsers1)
                .WithOptional(e => e.AspNetUser1)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.CustTypes)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Funds)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.FundTimes)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.GroupRights)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.ICPrices)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Nationalities)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Redemptions)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Sponsors)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Subscriptions)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.UserSecurities)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Redemptions)
                .WithRequired(e => e.Branch)
                .HasForeignKey(e => e.branch_id);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.Subscriptions)
                .WithOptional(e => e.Branch)
                .HasForeignKey(e => e.branch_id);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Redemptions)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.cust_id);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Subscriptions)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.cust_id);

            modelBuilder.Entity<CustType>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.CustType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fund>()
                .HasMany(e => e.Redemptions)
                .WithRequired(e => e.Fund)
                .HasForeignKey(e => e.fund_id);

            modelBuilder.Entity<Fund>()
                .HasMany(e => e.Subscriptions)
                .WithOptional(e => e.Fund)
                .HasForeignKey(e => e.fund_id);

            modelBuilder.Entity<ICPrice>()
                .Property(e => e.Price)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Nationality>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Nationality)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Redemption>()
                .Property(e => e.units)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Redemption>()
                .Property(e => e.sub_fees)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Redemption>()
                .Property(e => e.NAV)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Redemption>()
                .Property(e => e.other_fees)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Screen>()
                .HasMany(e => e.GroupRights)
                .WithRequired(e => e.Screen)
                .HasForeignKey(e => e.FormID);

            modelBuilder.Entity<Subscription>()
                .Property(e => e.sub_fees)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Subscription>()
                .Property(e => e.total)
                .HasPrecision(25, 2);

            modelBuilder.Entity<Subscription>()
                .Property(e => e.NAV)
                .HasPrecision(18, 5);

            modelBuilder.Entity<Subscription>()
                .Property(e => e.other_fees)
                .HasPrecision(18, 5);

            modelBuilder.Entity<UserIdentityType>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.UserIdentityType)
                .HasForeignKey(e => e.idType)
                .WillCascadeOnDelete(false);
        }
    }
}
