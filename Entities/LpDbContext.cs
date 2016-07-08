namespace LPAppService.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LpDbContext : DbContext
    {
        public LpDbContext()
            : base("name=LpDbConnection")
        {
        }

        public virtual DbSet<LPAppService.Entities.Uniowner> Uniowners { get; set; }
        public virtual DbSet<Uniplot> Uniplots { get; set; }
        public virtual DbSet<UniDistrict> UniDistrict { get; set; }
        public virtual DbSet<UniCircle> UniCircle { get; set; }
        public virtual DbSet<UniLocation> UniLocation { get; set; }
        //public virtual DbSet<MasterLandValue> MasterLandValue { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uniowner>()
                .Property(e => e.MutNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Uniowner>()
                .Property(e => e.SocialClass)
                .IsUnicode(false);

            modelBuilder.Entity<Uniplot>()
                .Property(e => e.EntryDate)
                .IsFixedLength();

            modelBuilder.Entity<Uniplot>()
                .Property(e => e.RemarkType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Uniplot>()
                .Property(e => e.usr)
                .IsUnicode(false);

            modelBuilder.Entity<Uniplot>()
                .Property(e => e.MutNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Uniplot>()
                .Property(e => e.MutOld)
                .HasPrecision(18, 0);
        }
    }
}
