namespace LPAppService.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UniCircle")]
    public partial class UniCircle
    {
        [StringLength(2)]
        public string distcode { get; set; }

        [StringLength(2)]
        public string subcode { get; set; }

        [Key]
        [StringLength(3)]
        public string circode { get; set; }

        [StringLength(50)]
        public string cirDesc { get; set; }
    }
}
