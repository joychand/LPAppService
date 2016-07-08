namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Circle")]
    public partial class Circle
    {
        [StringLength(3)]
        public string DistCode { get; set; }

        [StringLength(3)]
        public string SubDivCode { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string CircleCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CircleName { get; set; }
    }
}
