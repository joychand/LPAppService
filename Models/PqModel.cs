using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eSiroi.Resource.Models
{
  
        public class PqModel
        {
            [StringLength(10)]
            [RegularExpression(@"^[0-9]*$")]
            public string LocCd { get; set; }

            [StringLength(6)]
            [RegularExpression(@"^[0-9]*$")]
            public string NewDagNo {get;set;}

            [StringLength(6)]
            [RegularExpression(@"^[0-9]*$")]
            public string NewPattaNo{get;set;}
        }
    
}