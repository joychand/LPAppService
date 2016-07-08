namespace eSiroi.Resource.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("onlineapplication")]
    public partial class onlineapplication
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ackno { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string year { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string sro { get; set; }

        [StringLength(50)]
        public string mobile { get; set; }

        [StringLength(50)]
        public string aadhar { get; set; }

        [StringLength(2)]
        public string trans_maj_code { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(50)]
        public string date { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(50)]
        public string remarks { get; set; }
    }
}
