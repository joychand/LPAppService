namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistarOffice")]
    public partial class RegistarOffice
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short RegOfficeCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(40)]
        public string RegOfficeName { get; set; }

        [StringLength(40)]
        public string Location { get; set; }
    }
}
