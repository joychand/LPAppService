namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exempt_Reason
    {
        [Key]
        [StringLength(2)]
        public string p_code { get; set; }

        [StringLength(100)]
        public string p_desc { get; set; }
    }
}
