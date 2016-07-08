using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace eSiroi.Resource.Entities
{
    public class Appointment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TSNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short TSYear { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string sro { get; set; }

        public DateTime date1 { get; set; }
        public DateTime? date2 { get; set; }
        public DateTime? date3 { get; set; }
    }
}