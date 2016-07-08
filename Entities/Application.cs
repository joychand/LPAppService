
using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace eSiroi.Resource.Entities
{
    public class Application
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

              
        
        public string ackno { get; set; }

        
       

        [StringLength(2)]
        public string trans_maj_code { get; set; }

        

        [StringLength(50)]
        public string Entrydate { get; set; }

        [StringLength(50)]
        public string status { get; set; }
        [StringLength(50)]
        public string remarks { get; set; }
        [StringLength(50)]
        public string filePath { get; set; }
    }
    }
