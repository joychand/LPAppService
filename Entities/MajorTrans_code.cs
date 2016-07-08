namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MajorTrans_code
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string tran_maj_code { get; set; }

        [StringLength(4)]
        public string Book { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(80)]
        public string tran_name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? StampFee { get; set; }
    }
}
