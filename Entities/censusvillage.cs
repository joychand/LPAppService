namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("censusvillage")]
    public partial class censusvillage
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string DistCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string SubDivCode { get; set; }

        [StringLength(50)]
        public string CircleCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string VillCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string VillName { get; set; }

        [StringLength(255)]
        public string TRU { get; set; }
    }
}
