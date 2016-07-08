namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Occupation")]
    public partial class Occupation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Occupation_Code { get; set; }

        [Required]
        [StringLength(30)]
        public string Occupation_Name { get; set; }
    }
}
