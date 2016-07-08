namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostOffice")]
    public partial class PostOffice
    {
        [Required]
        [StringLength(2)]
        public string DistCode { get; set; }

        [Key]
        [Column("PostOffice")]
        [StringLength(40)]
        public string PostOffice1 { get; set; }

        [Required]
        [StringLength(6)]
        public string PinCode { get; set; }
    }
}
