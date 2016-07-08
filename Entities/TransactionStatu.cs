namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TransactionStatu
    {
        [Key]
        [StringLength(1)]
        public string StatusCode { get; set; }

        [StringLength(50)]
        public string StatusName { get; set; }
    }
}
