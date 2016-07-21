namespace LPAppService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UniLocation")]
    public partial class UniLocation
    {
        [Key]
        [StringLength(10)]
        [RegularExpression(@"^[0-9]*$")]
        public string LocCd { get; set; }

        [StringLength(100)]
        public string LocDesc { get; set; }

        [StringLength(1)]
        public string Issue { get; set; }

        [StringLength(1)]
        public string Unit_Measurement { get; set; }

        public byte? Mandol { get; set; }
    }
}
