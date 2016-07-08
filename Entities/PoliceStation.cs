namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PoliceStation")]
    public partial class PoliceStation
    {
        [Required]
        [StringLength(2)]
        public string DistCode { get; set; }

        [StringLength(2)]
        public string SubDivCode { get; set; }

        [Key]
        [StringLength(40)]
        public string PolStation { get; set; }
    }
}
