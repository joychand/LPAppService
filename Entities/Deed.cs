namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deed")]
    public partial class Deed
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TSNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short TSYear { get; set; }

        public int? RegNo { get; set; }

        public short? RegYear { get; set; }

        [StringLength(100)]
        public String RegDate { get; set; }

        [StringLength(2)]
        public string MajTransCode { get; set; }

        [StringLength(2)]
        public string TransType { get; set; }

        public int? SR { get; set; }
         [StringLength(100)]
        public String Date_Exec { get; set; }
         [StringLength(100)]
        public String Date_Time_Present { get; set; }

        [StringLength(1)]
        public string Municipal { get; set; }

        [StringLength(1)]
        public string OutJuri { get; set; }

        [StringLength(1)]
        public string VisitComm { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ConValue { get; set; }

        public int? StampPaid { get; set; }

        [StringLength(1)]
        public string FeeExempt { get; set; }

        [StringLength(50)]
        public string ExempReason { get; set; }

        public int? TotalRegFeePaid { get; set; }

        public int? RegFee { get; set; }

        public int? JuriFee { get; set; }

        public int? CommFee { get; set; }

        [StringLength(1)]
        public string Paid { get; set; }

        [StringLength(1)]
        public string verified { get; set; }

        [StringLength(1)]
        public string Pending { get; set; }

        [StringLength(2)]
        public string PendingReason { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(10)]
        public string PaymentMode { get; set; }

        [StringLength(15)]
        public string TrDrChNo { get; set; }

        public DateTime? TrDrChDate { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }

        [StringLength(15)]
        public string EnterBy { get; set; }

        [StringLength(1)]
        public string Printed { get; set; }

        public DateTime? EntryDt { get; set; }
    }
}
