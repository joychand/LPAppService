namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plot")]
    public partial class Plot
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SlNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TSNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short TSYear { get; set; }

        [StringLength(25)]
        public string DagNo { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(25)]
        public string PattaNo { get; set; }

        public short? LandType { get; set; }

        public short? Class { get; set; }

        [StringLength(25)]
        public string SqFeet { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TransactedArea { get; set; }

        [StringLength(1)]
        public string Unit { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [StringLength(50)]
        public string Subdivision { get; set; }

        [StringLength(50)]
        public string Circle { get; set; }

        [StringLength(50)]
        public string Village { get; set; }

        [StringLength(15)]
        public string EnterBy { get; set; }
    }
}
