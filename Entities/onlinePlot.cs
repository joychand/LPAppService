namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("onlinePlot")]
    public partial class onlinePlot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(50)]
        public string ackno { get; set; }

        [StringLength(25)]
        public string DagNo { get; set; }

        [StringLength(25)]
        public string PattaNo { get; set; }

        public short? LandType { get; set; }

        public short? Class { get; set; }

        [StringLength(1)]
        public string Unit { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        [StringLength(30)]
        public string District { get; set; }

        [StringLength(30)]
        public string Subdivision { get; set; }

        [StringLength(30)]
        public string Circle { get; set; }

        [StringLength(30)]
        public string Village { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TransactedArea { get; set; }

        [StringLength(30)]
        public string address1 { get; set; }

        [StringLength(30)]
        public string address2 { get; set; }

        [StringLength(30)]
        public string address3 { get; set; }
    }
}
