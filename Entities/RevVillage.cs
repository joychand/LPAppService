namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RevVillage")]
    public partial class RevVillage
    {
        [StringLength(2)]
        public string DistCode { get; set; }

        [StringLength(2)]
        public string SubDivCode { get; set; }

        [StringLength(10)]
        public string CircleCode { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string VillCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string VillName { get; set; }
    }
}
