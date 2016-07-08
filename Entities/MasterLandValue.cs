namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MasterLandValue")]
    public partial class MasterLandValue
    {
        public short? SN { get; set; }

        [Key]
        [StringLength(50)]
        public string Unit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rate1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rate2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rate3 { get; set; }

        [StringLength(200)]
        public string Details { get; set; }

        [StringLength(50)]
        public string Remark1 { get; set; }

        [StringLength(50)]
        public string Remark2 { get; set; }

        [StringLength(50)]
        public string Remark3 { get; set; }
    }
}
