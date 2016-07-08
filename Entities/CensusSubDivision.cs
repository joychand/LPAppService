namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CensusSubDivision")]
    public partial class CensusSubDivision
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string DistCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string SubDivCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(40)]
        public string SubDivName { get; set; }
    }
}
