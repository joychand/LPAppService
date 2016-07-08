namespace LPAppService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UniDistrict")]
    public partial class UniDistrict
    {
        [Key]
        [StringLength(2)]
        public string distcode { get; set; }

        [StringLength(50)]
        public string distDesc { get; set; }
    }
}
