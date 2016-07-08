namespace eSiroi.Resource.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class eSiroiReSrcDbContext : DbContext
    {
        public eSiroiReSrcDbContext()
            : base("eSiroiReSrcDbConnection")
        {
        }

        public virtual DbSet<eSiroi.Resource.Entities.CensusSubDivision> CensusSubDivisions { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.District> Districts { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.MajorTrans_code> MajorTrans_code { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Occupation> Occupation { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.onlineapplication> onlineapplication { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.OnlineClaimant> OnlineClaimant { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.OnlineExecutant> OnlineExecutant { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.OnlineIdentifier> OnlineIdentifier { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.onlinePlot> onlinePlot { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.PoliceStation> PoliceStation { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.PostOffice> PostOffice { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Presentant> Presentant { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.State> State { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.TransactionStatu> TransactionStatus { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.censusvillage> CensusVillage { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Circle> Circle { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Claimant> Claimant { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Class> Class { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Deed> Deed { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Executant> Executant { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Identifier> Identifier { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.LandType> LandType { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Plot> Plot { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.RegistarOffice> RegistarOffice { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.RevVillage> RevVillage { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.RO> RO { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.SubDivision> SubDivision { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Exempt_Reason> Exempt_Reason { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Application> Application { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.Appointment> Appointment { get; set; }
        public virtual DbSet<eSiroi.Resource.Entities.MasterLandValue> MasterLandValue { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CensusSubDivision>()
                .Property(e => e.DistCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CensusSubDivision>()
                .Property(e => e.SubDivCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CensusSubDivision>()
                .Property(e => e.SubDivName)
                .IsUnicode(false);

            modelBuilder.Entity<MajorTrans_code>()
                .Property(e => e.tran_maj_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MajorTrans_code>()
                .Property(e => e.Book)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MajorTrans_code>()
                .Property(e => e.tran_name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MajorTrans_code>()
                .Property(e => e.StampFee)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Occupation>()
                .Property(e => e.Occupation_Name)
                .IsUnicode(false);

            modelBuilder.Entity<onlineapplication>()
                .Property(e => e.trans_maj_code)
                .IsFixedLength()
                .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.ExecSurName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.ExecMiddleName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.ExecLastName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.Alias)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.Sex)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.FatherSurName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.FatherMiddleName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.FatherLastName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.State)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.District)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.SubDivision)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.Circle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.Village)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.Street)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.PostOffice)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.PoliceSt)
            //    .IsUnicode(false);

            //modelBuilder.Entity<OnlineExecutant>()
            //    .Property(e => e.EnterBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<onlinePlot>()
            //    .Property(e => e.DagNo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<onlinePlot>()
            //    .Property(e => e.PattaNo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<onlinePlot>()
            //    .Property(e => e.Unit)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<onlinePlot>()
            //    .Property(e => e.State)
            //    .IsUnicode(false);

            //modelBuilder.Entity<onlinePlot>()
            //    .Property(e => e.District)
            //    .IsUnicode(false);

            //modelBuilder.Entity<onlinePlot>()
            //    .Property(e => e.Subdivision)
            //    .IsUnicode(false);

            //modelBuilder.Entity<onlinePlot>()
            //    .Property(e => e.Circle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<onlinePlot>()
            //    .Property(e => e.Village)
            //    .IsUnicode(false);

            modelBuilder.Entity<PoliceStation>()
                .Property(e => e.DistCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PoliceStation>()
                .Property(e => e.SubDivCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PoliceStation>()
                .Property(e => e.PolStation)
                .IsUnicode(false);

            modelBuilder.Entity<PostOffice>()
                .Property(e => e.DistCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PostOffice>()
                .Property(e => e.PostOffice1)
                .IsUnicode(false);

            modelBuilder.Entity<PostOffice>()
                .Property(e => e.PinCode)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.PresentSurName)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.PresentMiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.PresentLastName)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.FatherSurName)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.FatherMiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.FatherLastName)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.District)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.SubDivision)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.Circle)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.Village)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.PostOffice)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.PoliceSt)
                .IsUnicode(false);

            modelBuilder.Entity<Presentant>()
                .Property(e => e.EnterBy)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStatu>()
                .Property(e => e.StatusCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionStatu>()
                .Property(e => e.StatusName)
                .IsUnicode(false);

            modelBuilder.Entity<Claimant>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Claimant>()
                .Property(e => e.EnterBy)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.MajTransCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.TransType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.Municipal)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.OutJuri)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.VisitComm)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.ConValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Deed>()
                .Property(e => e.FeeExempt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.ExempReason)
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.Paid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.verified)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.Pending)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.PendingReason)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.PaymentMode)
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.TrDrChNo)
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.EnterBy)
                .IsUnicode(false);

            modelBuilder.Entity<Deed>()
                .Property(e => e.Printed)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.ExecSurName)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.ExecMiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.ExecLastName)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.FatherSurName)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.FatherMiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.FatherLastName)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.District)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.SubDivision)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.Circle)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.Village)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.PostOffice)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.PoliceSt)
                .IsUnicode(false);

            modelBuilder.Entity<Executant>()
                .Property(e => e.EnterBy)
                .IsUnicode(false);

            modelBuilder.Entity<Identifier>()
                .Property(e => e.Identify)
                .IsUnicode(false);

            modelBuilder.Entity<Identifier>()
                .Property(e => e.Sex)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Identifier>()
                .Property(e => e.EnterBy)
                .IsUnicode(false);

            modelBuilder.Entity<LandType>()
                .Property(e => e.LandTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<Plot>()
                .Property(e => e.DagNo)
                .IsUnicode(false);

            modelBuilder.Entity<Plot>()
                .Property(e => e.PattaNo)
                .IsUnicode(false);

            modelBuilder.Entity<Plot>()
                .Property(e => e.TransactedArea)
                .HasPrecision(18, 6);

            modelBuilder.Entity<Plot>()
                .Property(e => e.Unit)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Plot>()
                .Property(e => e.EnterBy)
                .IsUnicode(false);

            modelBuilder.Entity<RegistarOffice>()
                .Property(e => e.RegOfficeName)
                .IsUnicode(false);

            modelBuilder.Entity<RegistarOffice>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<RO>()
                .Property(e => e.ROName)
                .IsUnicode(false);

            modelBuilder.Entity<RO>()
                .Property(e => e.Designation)
                .IsUnicode(false);
        }
    }
}
