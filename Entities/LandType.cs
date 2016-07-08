namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LandType")]
    public partial class LandType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short LandTypeCode { get; set; }

        [StringLength(30)]
        public string LandTypeName { get; set; }
    }
}
