namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RO")]
    public partial class RO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ROCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short OfficeCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string ROName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string Designation { get; set; }

        public DateTime? St_Date { get; set; }

        public DateTime? End_Date { get; set; }

        public string Address { get; set; }
    }
}
