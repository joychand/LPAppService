namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Last_Record
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NonEncNo { get; set; }
    }
}
